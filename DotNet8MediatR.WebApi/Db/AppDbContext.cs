namespace DotNet8MediatR.WebApi.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<BlogDataModel> Blogs { get; set; }
}
