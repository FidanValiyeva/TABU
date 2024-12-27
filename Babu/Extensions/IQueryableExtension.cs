namespace Babu.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Random<T>(this IQueryable<T> query,int randNumber)
        {
            Random random = new Random();
            random.Next(1,randNumber);    

        }
    }
}
