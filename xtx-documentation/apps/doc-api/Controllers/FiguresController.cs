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
    public class FiguresController : ControllerBase
    {
        private readonly DocuDbContext _context;

        public FiguresController(DocuDbContext context)
        {
            _context = context;
        }

        // GET: api/Figures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FigureModel>>> GetFigureModels()
        {
            return await _context.FigureModels.ToListAsync();
        }

        // GET: api/Figures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FigureModel>> GetFigureModel(int id)
        {
            var figureModel = await _context.FigureModels.FindAsync(id);

            if (figureModel == null)
            {
                return NotFound();
            }

            return figureModel;
        }

        // PUT: api/Figures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFigureModel(int id, FigureModel figureModel)
        {
            if (id != figureModel.FigureId)
            {
                return BadRequest();
            }

            _context.Entry(figureModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FigureModelExists(id))
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

        // POST: api/Figures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FigureModel>> PostFigureModel(FigureModel figureModel)
        {
            _context.FigureModels.Add(figureModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFigureModel", new { id = figureModel.FigureId }, figureModel);
        }

        // DELETE: api/Figures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFigureModel(int id)
        {
            var figureModel = await _context.FigureModels.FindAsync(id);
            if (figureModel == null)
            {
                return NotFound();
            }

            _context.FigureModels.Remove(figureModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FigureModelExists(int id)
        {
            return _context.FigureModels.Any(e => e.FigureId == id);
        }
    }
}
