
namespace Babu.Services.Implements
{
    [Serializable]
    internal class LanguageExistException : Exception
    {
        public LanguageExistException()
        {
        }

        public LanguageExistException(string? message) : base(message)
        {
        }

        public LanguageExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}