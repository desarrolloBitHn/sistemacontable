using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IbancosRepository: IRepository<bancos>
    {
        Task<IEnumerable<bancos>> GetBancos();
        Task<bancos> GetBancoById(int _id);
        Task<Tuple<bool, string>> PutActualizarBanco(bancos _banco);
        Task<Tuple<bool, bancos>> PostBancos(bancos _banco);
        Task<Tuple<bool, string>> DeleteBancos(int _id);

    }
}
