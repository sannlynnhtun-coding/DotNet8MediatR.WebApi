namespace DotNet8MediatR.User.Features.User;

public class UserApiResponseModel
{
    public ResponseModel Response { get; set; }
    public object RespData { get; set; }
    public string? Token { get; set; }
}