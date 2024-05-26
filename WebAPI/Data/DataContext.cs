using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Data;

public class DataContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
        
    }
}