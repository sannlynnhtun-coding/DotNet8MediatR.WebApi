using DotNet8MediatR.Models.Atm;
using DotNet8MediatR.Models.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8MediatR.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<BlogDataModel> Blogs { get; set; }
    public  DbSet<AtmCartDataModel> TblAtmCards { get; set; }
}
