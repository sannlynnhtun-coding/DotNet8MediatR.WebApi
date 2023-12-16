using DotNet8MediatR.Shared;
using Newtonsoft.Json.Linq;

namespace DotNet8MediatR.Models;

public class ResponseModel
{
    public ResponseModel()
    {
    }

    public ResponseModel(string respCode, string respDesp, EnumRespType respType)
    {
        RespCode = respCode;
        RespDesp = respDesp;
        RespType = respType;
    }

    public string RespCode { get; set; }
    public string RespDesp { get; set; }
    public EnumRespType RespType { get; set; }
}

public static class ResponseModelExtension
{
    public static ResponseModel ChangeResponseModel(this object reqModel)
    {
        JObject jObject = JObject.FromObject(reqModel);
        if (jObject.ContainsKey("Response"))
        {
            return jObject["Response"].ToJson().ToObject<ResponseModel>()!;
        }

        throw new Exception("Response was not found.");
    }
}
