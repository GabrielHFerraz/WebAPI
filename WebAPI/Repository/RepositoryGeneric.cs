using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interfaces;

namespace WebAPI.Repository;

public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
{
    private readonly DbContextOptions<DataContext> _optionsBuilder;

    public RepositoryGeneric()
    {
        _optionsBuilder = new DbContextOptions<DataContext>();
    }

    public async Task Create(T objeto)
    {
        using (var data = new DataContext(_optionsBuilder))
        {
            await data.Set<T>().AddAsync(objeto);
            await data.SaveChangesAsync();
        }
    }

    public async Task<T> GetById(int id)
    {
        using (var data = new DataContext(_optionsBuilder))
        {
            return await data.Set<T>().FindAsync(id);
        }
    }

    public async Task<IList<T>> GetAll()
    {
        using (var data = new DataContext(_optionsBuilder))
        {
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }
    }

    public async Task Delete(T objeto)
    {
        using (var data = new DataContext(_optionsBuilder))
        {
            data.Set<T>().Remove(objeto);
            await data.SaveChangesAsync();
        }
    }

    public async Task Update(T objeto)
    {
        using (var data = new DataContext(_optionsBuilder))
        {
            data.Set<T>().Update(objeto);
            await data.SaveChangesAsync();
        }
    }
}