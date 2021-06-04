using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XtxDocumentation.DocApi.Data;

namespace XtxDocumentation.DocApi.Data
{
  public class DocuDbContext: DbContext
  {
    public DocuDbContext(DbContextOptions<DocuDbContext> options)
    : base(options)
    {
    }


    //entities
    public DbSet<DocumentModel> DocumentModels { get; set; }
    public DbSet<UserModel> UserModels { get; set; }
    public DbSet<StateModel> StateModels { get; set; }
    public DbSet<TypeModel> TypeModels { get; set; }
    public DbSet<FigureModel> FigureModels { get; set; }
    public DbSet<ProjectModel> ProjectModels { get; set; }
    public DbSet<RemarkModel> RemarkModels { get; set; }
  }
}
