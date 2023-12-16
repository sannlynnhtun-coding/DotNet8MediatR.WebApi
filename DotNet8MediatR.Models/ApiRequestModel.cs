namespace DotNet8MediatR.Models;

public class ApiRequestModel
{
    public string ReqService { get; set; }
    public object ReqData { get; set; }
    public string GetServiceName()
    {
        return ReqService.Split(':')[1];
    }
}