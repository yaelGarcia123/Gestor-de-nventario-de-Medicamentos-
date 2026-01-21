using Apimedigroup.Data;
using Apimedigroup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // IMPORTANTE: Para ToListAsync() y EntityState

namespace Apimedigroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedicamentosController(AppDbContext context) => _context = context;

        // GET: api/Medicamentos (Incluye búsqueda y filtros)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicamento>>> GetMedicamentos(string? nombre, string? categoria, DateTime? fechaExpiracion)
        {
            var query = _context.Medicamentos.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(m => m.nombre.Contains(nombre));

            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(m => m.categoria == categoria);

            // Filtro por fecha opcional
            if (fechaExpiracion.HasValue)
                query = query.Where(m => m.fecha_expiracion.Date == fechaExpiracion.Value.Date);

            return await query.ToListAsync();
        }

        // POST: api/Medicamentos (Crear)
        [HttpPost]
        public async Task<ActionResult<Medicamento>> PostMedicamento(Medicamento medicamento)
        {
            _context.Medicamentos.Add(medicamento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMedicamentos), new { id = medicamento.Id }, medicamento);
        }

        // PUT: api/Medicamentos/5 (Editar) <--- ESTO TE FALTABA
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamento(int id, Medicamento medicamento)
        {
            if (id != medicamento.Id) return BadRequest();

            _context.Entry(medicamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Medicamentos.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/Medicamentos/5 (Eliminar)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicamento(int id)
        {
            var med = await _context.Medicamentos.FindAsync(id);
            if (med == null) return NotFound();

            _context.Medicamentos.Remove(med);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}