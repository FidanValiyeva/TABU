using System.Runtime.Serialization;

namespace Babu.Exceptions
{
    public class LanguagesExistException : Exception, IBaseException
    {
        public string ErrorMessage { get; }
        public LanguagesExistException()
        {
            ErrorMessage = "Dil movcuddur";
        }

        public LanguagesExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public int StatusCode => StatusCodes.Status409Conflict;

       
    }
}
