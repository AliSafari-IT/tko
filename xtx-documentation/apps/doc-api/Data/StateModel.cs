using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XtxDocumentation.DocApi.Data
{
  public class StateModel
  {
    [Key]
    public int DocEditStateId { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string EditState { get; set; }
  }
}
