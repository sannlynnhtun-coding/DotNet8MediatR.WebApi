using DotNet8MediatR.Db;
using Microsoft.EntityFrameworkCore;

namespace DotNet8MediatR.User.Features.User.Blog;

public class BlogDataAccess(AppDbContext appDbContext)
{
    public async Task<BlogListResponseModel> GetBlogs(int pageNo, int pageSize)
    {
        var model = new BlogListResponseModel();
        var pageSetting = new PageSettingModel();
        var lst = await appDbContext.Blogs
            .AsNoTracking()
            .OrderByDescending(x => x.Blog_Id)
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var rowCount = await appDbContext.Blogs.CountAsync();
        var pageCount = rowCount / pageSize;
        if (rowCount % pageSize > 0)
        {
            pageCount++;
        }
        pageSetting.PageNo = pageNo;
        pageSetting.PageSize = pageSize;
        pageSetting.PageCount = pageCount;
        pageSetting.RowCount = rowCount;
        model.PageSetting = pageSetting;
        model.BlogList = lst.Select(x => new BlogViewModel
        {
            Id = x.Blog_Id,
            Author = x.Blog_Author,
            Content = x.Blog_Content,
            Title = x.Blog_Title
        }).ToList();
        model.Response = new ResponseModel("000", "Success", EnumRespType.Success);

        //List<BlogViewModel> blogViewModels = new List<BlogViewModel>();
        //foreach (var item in lst)
        //{
        //    BlogViewModel viewModel = new BlogViewModel
        //    {
        //        Id = item.Blog_Id,
        //        Author = item.Blog_Author,
        //        Content = item.Blog_Content,
        //        Title = item.Blog_Title
        //    };
        //    blogViewModels.Add(viewModel);
        //}
        //model.BlogList = blogViewModels;
        return model;
    }

    public async Task<BlogResponseModel> CreateBlog(BlogRequestModel requestModel)
    {
        var model = new BlogResponseModel();
        var blog = new BlogDataModel
        {
            Blog_Title = requestModel.Title!,
            Blog_Author = requestModel.Author!,
            Blog_Content = requestModel.Content!,
        };

        await appDbContext.Blogs.AddAsync(blog);
        var result = await appDbContext.SaveChangesAsync();

        var respCode = result > 0 ? "000" : "999";
        var respDesp = result > 0 ? "Saving Successful." : "Saving Failed.";
        var respType = result > 0 ? EnumRespType.Success : EnumRespType.Error;
        model.Response = new ResponseModel(respCode, respDesp, respType);
        return model;
    }
}
