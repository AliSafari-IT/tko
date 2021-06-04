using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XtxDocumentation.DocApi.Data
{
  public class TypeModel
  {
    [Key]
    public int TypeModelId { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string ModelType { get; set; }
  }
}
