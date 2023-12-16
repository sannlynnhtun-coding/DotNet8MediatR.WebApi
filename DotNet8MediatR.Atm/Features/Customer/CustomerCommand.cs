using MediatR;

namespace DotNet8MediatR.Atm.Features.Customer;

public record CustomerCommand(CustomerApiRequestModel reqModel) : IRequest<CustomerApiResponseModel>;
