using Models;
using System.Data;
using System.Data.SqlClient;

namespace _834FilePareserControl
{
    public class DatabaseInserter
    {
        public DatabaseInserter(InterchangeControlHeader file834)
        {
            _File834 = file834;
        }

        private InterchangeControlHeader _File834 { get; set; }

        public void Insert(string Conn)
        {
            using IDbConnection conn = new SqlConnection(Conn);

            conn.Insert(_File834);
            conn.Insert(_File834.FGH);
            var headerId = conn.Insert(_File834.FGH.Headers);
            _File834.FGH.Headers.Dates.ForEach(i => { i.HeaderId = headerId; });
            _File834.FGH.Headers.Sponsor.ParentId = headerId;
            _File834.FGH.Headers.Payer.ParentId = headerId;
            conn.Insert(_File834.FGH.Headers.Dates);
            conn.Insert(_File834.FGH.Headers.Sponsor);
            conn.Insert(_File834.FGH.Headers.Payer);

            //Loop2000
            foreach (var loop2000 in _File834.FGH.Headers.Loop2000)
            {
                var memberId = conn.Insert(loop2000.INS);
                if (loop2000.REF != null)
                {
                    loop2000.REF.MemberId = memberId;
                    conn.Insert(loop2000.REF);
                    loop2000.SupplementalREF.ForEach(item =>
                    {
                        item.MemberId = memberId;
                        //   item.ParentMemberId = memberId;
                        conn.Insert(item);
                    });
                }

                loop2000.DTP.ForEach(item =>
                {
                    item.MemberId = memberId;
                    conn.Insert(item);
                });

                foreach (var loop2100 in loop2000.Loop2100s)
                {
                    loop2100.MemberProviderName.MemberId = memberId;
                    var mpn = loop2100.MemberProviderName;
                    mpn.MemberId = memberId;
                    var memprvId = conn.Insert(mpn);
                    if (loop2100.PER != null)
                    {
                        loop2100.PER.MemberProviderNameId = memprvId;
                        conn.Insert(loop2100.PER);
                    }
                    if (loop2100.N3 != null)
                    {
                        loop2100.N3.MemberProviderNameId = memprvId;
                        conn.Insert(loop2100.N3);
                    }
                    if (loop2100.N4 != null)
                    {
                        loop2100.N4.MemberProviderNameId = memprvId;
                        conn.Insert(loop2100.N4);
                    }
                    if (loop2100.DMG != null)
                    {
                        loop2100.DMG.MemberProviderNameId = memprvId;
                        conn.Insert(loop2100.DMG);
                    }
                    loop2100.AMT.ForEach(item => { item.MemberProviderNameId = memprvId; conn.Insert(item); });
                    loop2100.LUI.ForEach(item => { item.MemberProviderNameId = memprvId; conn.Insert(item); });
                }

                foreach (var loop2300 in loop2000.Loop2300s)
                {
                    var hd = loop2300.HealthCoverage;
                    hd.MemberId = memberId;
                    var hdid = conn.Insert(hd);
                    loop2300.HealthCoverageDates.ForEach(item => { item.HealthCoverageId = hdid; conn.Insert(item); });

                    //2310
                    foreach (var loop2310 in loop2300.Loop2310s)
                    {
                        long memprvId = 0;

                        if (loop2310.NM1 != null)
                        {
                            loop2310.NM1.MemberId = memberId;
                            memprvId = conn.Insert(loop2310.NM1);
                        }

                        if (loop2310.N3 != null)
                        {
                            loop2310.N3.MemberProviderNameId = memprvId;
                            conn.Insert(loop2310.N3);
                        }
                        if (loop2310.N4 != null)
                        {
                            loop2310.N4.MemberProviderNameId = memprvId;
                            conn.Insert(loop2310.N4);
                        }
                        loop2310.PER.ForEach(item => { item.MemberProviderNameId = memprvId; conn.Insert(item); });

                        if (loop2310.PLA != null)
                        {
                            loop2310.PLA.MemberProviderNameId = memprvId;
                            conn.Insert(loop2310.PLA);
                        }
                    }

                    loop2300.Loop2320s.ForEach(item =>
                    {
                        item.COB.MemberId = memberId;
                        var cob = item.COB;
                        cob.MemberId = memberId;
                        var cobId = conn.Insert(cob);
                        item.DPT.ForEach(dpt => { dpt.CoordinationOfBenefitsId = cobId; conn.Insert(dpt); });
                        item.Loop2330s.ForEach(loop2330 =>
                        {
                            loop2330.CoordinationOfBenefitsId = cobId;
                            var cobRefId = conn.Insert(loop2330.NM1);
                            if (loop2330.N3 != null)
                            {
                                loop2330.N3.CoordinationOfBenefitsRefId = cobRefId;
                                conn.Insert(loop2330.N3);
                            }
                            if (loop2330.N4 != null)
                            {
                                loop2330.N4.CoordinationOfBenefitsRefId = cobRefId;
                                conn.Insert(loop2330.N4);
                            }
                        });
                    });
                }

                //2320
                //foreach (var loop2320 in loop2000.Loop2320s)
                //{
                //    //loop2320.COB.MemberId = memberId;
                //    var cob = loop2320.COB;
                //    cob.MemberId = memberId;
                //    var cobId = conn.Insert(cob);

                //    // loop2320.REF.ForEach(item => { item.CoordinationOfBenefitsId = cobId; conn.Insert(item); });
                //    loop2320.DPT.ForEach(item => { item.CoordinationOfBenefitsId = cobId; conn.Insert(item); });
                //    //2330
                //    loop2320.Loop2330s.ForEach(item =>
                //    {
                //        item.CoordinationOfBenefitsId = cobId;
                //        var cobRefId = conn.Insert(item.NM1);
                //        if (item.N3 != null)
                //        {
                //            item.N3.CoordinationOfBenefitsRefId = cobRefId;
                //            conn.Insert(item.N3);
                //        }
                //        if (item.N4 != null)
                //        {
                //            item.N4.CoordinationOfBenefitsRefId = cobRefId;
                //            conn.Insert(item.N4);
                //        }
                //    });
                //}
                //TODO: MAP new 2320

                foreach (var loop2700 in loop2000.loop2700s)
                {
                    loop2700.N1.ParentId = memberId;
                    var n1Id = conn.Insert(loop2700.N1);
                    if (loop2700.REF != null)
                    {
                        loop2700.REF.SponsorPayerId = n1Id;
                        conn.Insert(loop2700.REF);
                    }
                    if (loop2700.DTP != null)
                    {
                        loop2700.DTP.SponsorPayerId = n1Id;
                        conn.Insert(loop2700.DTP);
                    }
                }
            }

            //File834.FGH.File834Id = file834Id;
            //FGH.Headers.File834Id = file834Id;
            //conn.Insert(FGH.Headers);
            //FGH.Headers.Payer.File834Id = file834Id;
            //FGH.Headers.Sponsor.File834Id = file834Id;
        }
    }
}