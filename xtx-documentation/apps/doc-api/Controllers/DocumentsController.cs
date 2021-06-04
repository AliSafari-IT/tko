using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XtxDocumentation.DocApi.Data;

namespace XtxDocumentation.DocApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DocumentsController : ControllerBase
  {
    private readonly DocuDbContext _context;

    public DocumentsController(DocuDbContext context)
    {
      _context = context;
    }

    // GET: api/Documents
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocumentModel>>> GetDocumentModels()
    {
      return await _context.DocumentModels.ToListAsync();
    }

    // GET: api/Documents/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DocumentModel>> GetDocumentModel(long id)
    {
      var documentModel = await _context.DocumentModels.FindAsync(id);

      if (documentModel == null)
      {
        return NotFound();
      }

      return documentModel;
    }

    // PUT: api/Documents/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDocumentModel(long id, DocumentModel documentModel)
    {
      if (id != documentModel.DocumentId)
      {
        return BadRequest();
      }

      _context.Entry(documentModel).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DocumentModelExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Documents
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<DocumentModel>> PostDocumentModel(DocumentModel documentModel)
    {
      _context.DocumentModels.Add(documentModel);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetDocumentModel", new { id = documentModel.DocumentId }, documentModel);
    }

    // DELETE: api/Documents/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDocumentModel(long id)
    {
      var documentModel = await _context.DocumentModels.FindAsync(id);
      if (documentModel == null)
      {
        return NotFound();
      }

      _context.DocumentModels.Remove(documentModel);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool DocumentModelExists(long id)
    {
      return _context.DocumentModels.Any(e => e.DocumentId == id);
    }
  }
}
