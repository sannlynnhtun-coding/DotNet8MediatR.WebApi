namespace DotNet8MediatR.User.Features.User.Blog;

public class BlogBusinessLogic(BlogDataAccess blogDataAccess)
{
    public async Task<BlogListResponseModel> GetBlogs(BlogRequestModel requestModel)
    {
        var pageNo = requestModel.PageSettng!.PageNo;
        var pageSize = requestModel.PageSettng!.PageSize;
        var model = new BlogListResponseModel();
        if (pageNo == 0)
        {
            model.Response = new ResponseModel("999", "Invalid Page No.", EnumRespType.Warning);
            goto result;
        }
        if (pageSize == 0)
        {
            model.Response = new ResponseModel("999", "Invalid Page Size.", EnumRespType.Warning);
            goto result;
        }
        model = await blogDataAccess.GetBlogs(pageNo, pageSize);
    result:
        return model;
    }

    public async Task<BlogResponseModel> CreateBlog(BlogRequestModel requestModel)
    {
        return await blogDataAccess.CreateBlog(requestModel);
    }
}
