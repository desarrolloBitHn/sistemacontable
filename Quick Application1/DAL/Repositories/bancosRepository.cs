using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
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

        public async Task<bancos> GetBancoById(int _id) {
            return await _appContext.bancos.FindAsync(_id);
        }

        public async Task<Tuple<bool, string>> PutActualizarBanco(bancos _banco) {
            try
            {
                _appContext.Entry(_banco).State = EntityState.Modified;
                await _appContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Tuple.Create(false, e.Message);
                throw;
            }

            return Tuple.Create(true, "Modificado");
        }

        public async Task<Tuple<bool, bancos>> PostBancos(bancos _banco) {
            try
            {
                _appContext.bancos.Add(_banco);
                await _appContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Tuple.Create(false, _banco);
                throw;
            }
            return Tuple.Create(true, _banco);
        }

        public async Task<Tuple<bool, string>> DeleteBancos(int _id) {
            try
            {
                var _banco = await GetBancoById(_id);
                _banco.deleted = true;
                _appContext.Entry(_banco).State = EntityState.Modified;
                await _appContext.SaveChangesAsync();
                return Tuple.Create(false, "Eliminado");
            }
            catch (Exception e)
            {
                return Tuple.Create(false, e.Message);
                throw;
            }
        }


        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

    }
}
