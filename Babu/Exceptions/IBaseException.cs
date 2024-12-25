namespace Babu.Exceptions
{
    internal interface IBaseException
    {
        int StatusCode { get; }
        string ErrorMessage { get; }
    }
}