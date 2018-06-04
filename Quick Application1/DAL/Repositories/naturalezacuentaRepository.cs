using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    class naturalezacuentaRepository: Repository<naturalezacuenta>, InaturalezacuentasRepository
    {
        public naturalezacuentaRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<IEnumerable<naturalezacuenta>> GetNaturalezas() {
            return await _appContext.naturalezacuenta.ToListAsync();
        }

        public async Task<naturalezacuenta> GetNaturalezaById(int _id) {
            return await _appContext.naturalezacuenta.FindAsync(_id);
        }

        public async Task<Tuple<bool, string>> PutActualizarZaturaleza(naturalezacuenta _naturaleza) {
            try
            {
                _appContext.Entry(_naturaleza).State = EntityState.Modified;
                await _appContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Tuple.Create(false, e.Message);
                throw;
            }
            return Tuple.Create(true, "Modificado");
        }

        public async Task<Tuple<bool, string>> PostNaturaleza(naturalezacuenta _naturaleza) {
            try
            {
                _appContext.naturalezacuenta.Add(_naturaleza);
                await _appContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Tuple.Create(false, e.Message);
                throw;
            }
            return Tuple.Create(true, "Agregado");
        }

        public async Task<Tuple<bool, string>> PutDelete(int _id) {
            try
            {
                var _naturaleza = await this.GetNaturalezaById(_id);
                _naturaleza.deleted = true;
                _appContext.naturalezacuenta.Add(_naturaleza);
                await _appContext.SaveChangesAsync();
                
            }
            catch (Exception e)
            {
                return Tuple.Create(false,e.Message );
                throw;
            }
            return Tuple.Create(true, "Eliminado");
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
