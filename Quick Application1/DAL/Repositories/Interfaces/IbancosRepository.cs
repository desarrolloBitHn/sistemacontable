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
    }
}
