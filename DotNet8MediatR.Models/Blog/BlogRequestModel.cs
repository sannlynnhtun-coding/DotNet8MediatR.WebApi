﻿namespace DotNet8MediatR.Models.Blog;

// api request
public class BlogRequestModel
{
    public PageSettingModel? PageSetting { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Content { get; set; }
}