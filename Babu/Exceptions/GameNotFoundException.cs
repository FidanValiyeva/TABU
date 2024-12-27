using System.Runtime.Serialization;
namespace Babu.Exceptions
{
   public class GameNotFoundException : Exception, IBaseException
    {
        public string ErrorMessage { get; }        

        public GameNotFoundException()
        {
            ErrorMessage = "oyun yoxdur";
        }
        public GameNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }
        public int StatusCode => StatusCodes.Status409Conflict;

    }
}
