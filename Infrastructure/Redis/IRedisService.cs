// namespace Infrastructure.Redis;
//
// public interface IRedisService
// {
//     public Task<T> GetData<T>(string key, CancellationToken cancellationToken = default);
//     public Task SetData<T>(string key, T data,int timeSpan = 10, CancellationToken cancellationToken = default);
//     public Task DeleteData(string key, CancellationToken cancellationToken = default);
// }