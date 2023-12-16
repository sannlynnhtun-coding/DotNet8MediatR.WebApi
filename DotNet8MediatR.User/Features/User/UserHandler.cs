using DotNet8MediatR.Shared;
using DotNet8MediatR.User.Features.User.Blog;
using MediatR;

namespace DotNet8MediatR.User.Features.User;

public class UserHandler : IRequestHandler<UserCommand, UserApiResponseModel>
{
    private readonly BlogBusinessLogic _blogBusinessLogic;

    public UserHandler(BlogBusinessLogic blogBusinessLogic)
    {
        _blogBusinessLogic = blogBusinessLogic;
    }

    public async Task<UserApiResponseModel> Handle(UserCommand request, CancellationToken cancellationToken)
    {
        var model = new UserApiResponseModel();
        var reqService = request.reqModel.ReqService.ToEnum<EnumUserModuleType>();
        object? responseData = null;
        var raw = request.reqModel.ReqData.ToString()!;
        switch (reqService)
        {
            case EnumUserModuleType.BlogList:
                responseData = await _blogBusinessLogic.GetBlogs(raw.ToObject<BlogRequestModel>()!);
                break;
            case EnumUserModuleType.BlogEdit:
                break;
            case EnumUserModuleType.BlogCreate:
                responseData = await _blogBusinessLogic.CreateBlog(raw.ToObject<BlogRequestModel>()!);
                break;
            case EnumUserModuleType.BlogUpdate:
                break;
            case EnumUserModuleType.BlogDelete:
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