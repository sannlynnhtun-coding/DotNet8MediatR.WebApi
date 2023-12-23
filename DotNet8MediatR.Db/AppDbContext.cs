using DotNet8MediatR.Models.Atm;
using DotNet8MediatR.Models.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8MediatR.Db;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<BlogDataModel> Blogs { get; set; }
    public  DbSet<AtmCartDataModel> TblAtmCards { get; set; }
}
