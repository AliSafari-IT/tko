using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XtxDocumentation.DocApi.Data
{
  public class FigureModel
  {
    [Key]
    public int FigureId { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string FigureTitle { get; set; }

    [Column(TypeName = "nvarchar(MAX)")]
    public string FullPath { get; set; }
  }
}
