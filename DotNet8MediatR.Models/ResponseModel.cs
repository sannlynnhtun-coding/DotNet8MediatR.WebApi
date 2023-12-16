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
    public bool IsSuccess => RespType == EnumRespType.Success;
    public bool IsError => !IsSuccess;
    public void Set(string code)
    {
        RespCode = code;
        RespDesp = code;
        RespType = code.GetRespType();
    }
}
public class Codes
{
    public static string Success0001 { get; } = "MS#0001";
    public static string Success0002 { get; } = "MS#0002";

    /// <summary>
    /// Your withdrawal request has been processed successfully.
    /// </summary>
    public static string Success0003 { get; } = "MS#0003";
    /// <summary>
    /// Your deposit request has been processed successfully.
    /// </summary>
    public static string Success0004 { get; } = "MS#0004";

    /// <summary>
    /// CardNumber is required.
    /// </summary>
    public static string Warning0001 { get; } = "MW#0001";

    /// <summary>
    /// Password is required.
    /// </summary>
    public static string Warning0002 { get; } = "MW#0002";

    /// <summary>
    /// No data found.
    /// </summary>
    public static string Warning0003 { get; } = "MW#0003";

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
    public static EnumRespType GetRespType(this string code)
    {
        string[] parts = code.Split('#');
        var respType = parts[0] switch
        {
            "MS" => EnumRespType.Success,
            "MI" => EnumRespType.Information,
            "MW" => EnumRespType.Warning,
            "ME" => EnumRespType.Error,
            _ => throw new Exception("There is no response type.")
        };
        return respType;
    }
}
