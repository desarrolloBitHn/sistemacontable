// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        ICustomerRepository _customers;
        IProductRepository _products;
        IOrdersRepository _orders;
        IbancosRepository _bancos;
        InaturalezacuentasRepository _naturaleza;



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public InaturalezacuentasRepository Naturaleza
        {
            get
            {
                if (_naturaleza == null)
                    _naturaleza = new naturalezacuentaRepository(_context);

                return _naturaleza;
            }
        }

        public IbancosRepository Bancos
        {
            get {
                if (_bancos == null)
                    _bancos = new bancosRepository(_context);

                return _bancos;
            }
        }


        public ICustomerRepository Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new CustomerRepository(_context);

                return _customers;
            }
        }



        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(_context);

                return _products;
            }
        }



        public IOrdersRepository Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrdersRepository(_context);

                return _orders;
            }
        }




        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
