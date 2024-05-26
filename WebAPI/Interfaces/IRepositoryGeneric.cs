namespace WebAPI.Interfaces;

public interface IRepositoryGeneric<T> where T : class
{
    Task Create(T objeto);
    Task<T> GetById(int id);
    Task<IList<T>> GetAll();
    Task Delete(T objeto);
    Task Update(T objeto);
}