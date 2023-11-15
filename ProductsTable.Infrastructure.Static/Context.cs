using ProductsTable.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductsTable.Infrastructure.Static;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; } = null!;
}