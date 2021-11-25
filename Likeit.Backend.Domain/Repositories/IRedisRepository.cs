namespace Likeit.Backend.Domain.Repositories
{
    public interface IRedisRepository
    {
        string GetByKey(string key);
        void SetString(string key, string value);
    }
}
