namespace DotNet8MediatR.Models.Blog;

public class BlogResponseModel
{
    public ResponseModel Response { get; set; } = new();
    public BlogViewModel Blog { get; set; }
}