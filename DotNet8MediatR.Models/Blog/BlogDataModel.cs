using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet8MediatR.Models.Models;

// database to C#
[Table("Tbl_Blog")]
public class BlogDataModel
{
    [Key]
    public int Blog_Id { get; set; }
    public string Blog_Title { get; set; }
    public string Blog_Author { get; set; }
    public string Blog_Content { get; set; }
}
