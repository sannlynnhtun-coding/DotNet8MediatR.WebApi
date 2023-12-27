using DotNet8MediatR.Shared;
using DotNet8MediatR.User.Features.User.Blog;
using MediatR;

namespace DotNet8MediatR.User.Features.User;

public class UserHandler(BlogBusinessLogic blogBusinessLogic) : IRequestHandler<UserCommand, UserApiResponseModel>
{
    public async Task<UserApiResponseModel> Handle(UserCommand request, CancellationToken cancellationToken)
    {
        var model = new UserApiResponseModel();
        var reqService = request.reqModel.ReqService.ToEnum<EnumUserModuleType>();
        object? responseData = null;
        var raw = request.reqModel.ReqData.ToString()!;
        switch (reqService)
        {
            case EnumUserModuleType.BlogList:
                responseData = await blogBusinessLogic.GetBlogs(raw.ToObject<BlogRequestModel>()!);
                break;
            case EnumUserModuleType.BlogEdit:
                responseData = await blogBusinessLogic.EditBlog(raw.ToObject<BlogRequestModel>()!);
                break;
            case EnumUserModuleType.BlogCreate:
                responseData = await blogBusinessLogic.CreateBlog(raw.ToObject<BlogRequestModel>()!);
                break;
            case EnumUserModuleType.BlogUpdate:
                responseData = await blogBusinessLogic.UpdateBlog(raw.ToObject<BlogRequestModel>()!);
                break;
            case EnumUserModuleType.BlogDelete:
                responseData = await blogBusinessLogic.DeleteBlog(raw.ToObject<BlogRequestModel>()!);
                break;
            case EnumUserModuleType.None:
            default:
                throw new ArgumentOutOfRangeException();
        }

        model.Response = responseData!.ChangeResponseModel();
        model.RespData = responseData!;
        return model;
    }
}