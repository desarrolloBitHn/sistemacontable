using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    class bancosRepository : Repository<bancos>, IbancosRepository
    {
        public bancosRepository(ApplicationDbContext context) : base(context)
        { }


        public async Task<IEnumerable<bancos>> GetBancos()
        {
            return await _appContext.bancos.ToListAsync();
        }

        


        //// GET: api/bancos/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Getbancos([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var bancos = await _context.bancos.SingleOrDefaultAsync(m => m.ID == id);

        //    if (bancos == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(bancos);
        //}

        //// PUT: api/bancos/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Putbancos([FromRoute] int id, [FromBody] bancos banco)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != banco.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(banco).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!bancosExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/bancos
        //[HttpPost]
        //public async Task<IActionResult> Postbancos([FromBody] bancos bancos)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.bancos.Add(bancos);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("Getbancos", new { id = bancos.ID }, bancos);
        //}

        //// DELETE: api/bancos/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Deletebancos([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var bancos = await _context.bancos.SingleOrDefaultAsync(m => m.ID == id);
        //    if (bancos == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.bancos.Remove(bancos);
        //    await _context.SaveChangesAsync();

        //    return Ok(bancos);
        //}

        //private bool bancosExists(int id)
        //{
        //    return _context.bancos.Any(e => e.ID == id);
        //}


        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

    }
}
