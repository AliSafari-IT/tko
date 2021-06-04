using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XtxDocumentation.DocApi.Data
{
  public class DocumentModel
  {
    [Key]
    [Column(Order = 0)]
    public long DocumentId { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string DocTitle { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    public string DocContent { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime? DateModified { get; set; }

    public int StateModelId { get; set; }
    public StateModel StateModel { get; set; }

    public int TypeModelId { get; set; }
    public TypeModel TypeModel { get; set; }

    public int ProjectModelId { get; set; }
    public ProjectModel ProjectModel { get; set; }

    public int UserModelId { get; set; }
    public UserModel UserModel { get; set; }
#nullable enable
    public string? DocVersion { get; set; }

    [NotMapped]
    public string? DeletedDocumentIds { get; set; }
#nullable disable 
 }
}
