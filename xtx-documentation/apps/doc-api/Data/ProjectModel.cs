using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XtxDocumentation.DocApi.Data
{
  public class ProjectModel
  {
    [Key]
    [Column(Order = 0)]
    public int ProjectId { get; set; }

    [Column(TypeName = "nvarchar(255)", Order = 2)]
    public string ProjectLeader { get; set; }

    [Column(TypeName = "nvarchar(255)", Order = 1)]
    public string ProjectTitle { get; set; }
  }
}
