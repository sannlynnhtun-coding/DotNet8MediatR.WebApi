using DotNet8MediatR.Atm.Features.Customer.Blog;
using DotNet8MediatR.Shared;
using MediatR;

namespace DotNet8MediatR.Atm.Features.Customer
{
    public class CustomerHandler : IRequestHandler<CustomerCommand, CustomerApiResponseModel>
    {
        private readonly BlogBusinessLogic _blogBusinessLogic;

        public CustomerHandler(BlogBusinessLogic blogBusinessLogic)
        {
            _blogBusinessLogic = blogBusinessLogic;
        }

        public async Task<CustomerApiResponseModel> Handle(CustomerCommand request, CancellationToken cancellationToken)
        {
            var model = new CustomerApiResponseModel();
            var reqService = request.reqModel.ReqService.ToEnum<EnumAtmModuleType>();
            object? responseData = null;
            var raw = request.reqModel.ReqData.ToString()!;
            switch (reqService)
            {
                case EnumAtmModuleType.BlogList:
                    responseData = await _blogBusinessLogic.GetBlogs(raw.ToObject<BlogRequestModel>()!);
                    break;
                case EnumAtmModuleType.BlogEdit:
                    break;
                case EnumAtmModuleType.BlogCreate:
                    responseData = await _blogBusinessLogic.CreateBlog(raw.ToObject<BlogRequestModel>()!);
                    break;
                case EnumAtmModuleType.BlogUpdate:
                    break;
                case EnumAtmModuleType.BlogDelete:
                    break;
                case EnumAtmModuleType.None:
                default:
                    throw new ArgumentOutOfRangeException();
            }

            model.Response = responseData!.ChangeResponseModel();
            model.RespData = responseData!;
            return model;
        }
    }
}
