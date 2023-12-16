using MediatR;

namespace DotNet8MediatR.User.Features.User;

public record UserCommand(UserApiRequestModel reqModel) : IRequest<UserApiResponseModel>;
