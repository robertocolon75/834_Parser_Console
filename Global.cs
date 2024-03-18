using FluentValidation;
using FluentValidation.Results;
using System.Data;
using System.Data.SqlClient;
using _834FilePareserControl.Models;

namespace _834FilePareserControl
{
    public static class Global
    {
        public static long File834Id { get; set; }

        public static bool IsValidFile<TS, T>(T obj, string Conn) where TS : AbstractValidator<T>, new() where T : class
        {
            ValidationResult validationResult = new TS().Validate(obj);
            if (validationResult.Errors.Count > 0)
            {
                List<ValidationError> list = new List<ValidationError>();
                foreach (ValidationFailure error in validationResult.Errors)
                {
                    ValidationError item = new ValidationError
                    {
                        ErrorCode = error.ErrorCode,
                        ErrorMessage = error.ErrorMessage,
                    };
                    list.Add(item);
                }

                using (IDbConnection connection = new SqlConnection(Conn))
                {
                    connection.Insert(list);
                }

                return false;
            }

            return true;
        }
    }
}