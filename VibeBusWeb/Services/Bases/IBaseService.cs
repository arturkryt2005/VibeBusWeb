namespace VibeBusWeb.Services.Bases;

public interface IBaseService<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<HttpResponseMessage> DeleteAsync(int id);

    Task<HttpResponseMessage> CreateAsync(TEntity entity);

    Task<HttpResponseMessage> UpdateAsync(TEntity entity);
}