using MediatR;

namespace DotNet8MediatR.WebApi.Features.Customer
{
    public class CustomerHandler : IRequestHandler<CustomerCommand, CustomerApiResponseModel>
    {
        public async Task<CustomerApiResponseModel> Handle(CustomerCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
