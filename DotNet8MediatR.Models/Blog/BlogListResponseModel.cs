namespace DotNet8MediatR.Models.Models;

// api response
public class BlogListResponseModel
{
    public ResponseModel Response { get; set; }
    public PageSettingModel PageSetting { get; set; }
    public List<BlogViewModel> BlogList { get; set; }
}
