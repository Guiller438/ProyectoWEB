using Proyetct11.DataAccess.Data;
using Proyetct11.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyetct11.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AplicationDbContext _db;
        public ICategoryRepository Category{ get; private set; }
        public IProductRepository Product { get; private set; }
        public UnitOfWork(AplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }
       
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
