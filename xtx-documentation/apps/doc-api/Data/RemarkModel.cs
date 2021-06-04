using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XtxDocumentation.DocApi.Data
{
  public class RemarkModel
  {
    [Key]
    public int RemarkId { get; set; }

    [Column(TypeName = "nvarchar(Max)")]
    public string RemarkText { get; set; }

    public int DocumentModelId { get; set; }
    public DocumentModel DocumentModel { get; set; }
  }
}
