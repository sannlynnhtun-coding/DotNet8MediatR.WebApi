using MediatR;

namespace DotNet8MediatR.WebApi.Features.Customer;

public record CustomerCommand(CustomerApiRequestModel reqModel) : IRequest<CustomerApiResponseModel>;
