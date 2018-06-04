using System;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DAL.Repositories.Interfaces
{
    public interface InaturalezacuentasRepository: IRepository<naturalezacuenta>
    {
        Task<IEnumerable<naturalezacuenta>> GetNaturalezas();
        Task<naturalezacuenta> GetNaturalezaById(int _id);
        Task<Tuple<bool, string>> PutActualizarZaturaleza(naturalezacuenta _naturaleza);
        Task<Tuple<bool, string>> PostNaturaleza(naturalezacuenta _naturaleza);
        Task<Tuple<bool, string>> PutDelete(int _id);
    }
}
