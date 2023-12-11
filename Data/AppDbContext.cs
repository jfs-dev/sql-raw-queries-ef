using Microsoft.EntityFrameworkCore;

using sql_raw_queries_ef.Models;

namespace sql_raw_queries_ef.Data;

public class AppDbContext: DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=Data/SQLite.db;Cache=Shared");
    }    
}