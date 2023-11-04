using Proyetct11.DataAccess.Data;
using Proyetct11.DataAccess.Repository.IRepository;
using Proyetct11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyetct11.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AplicationDbContext _db;
        public ProductRepository(AplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
           var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Barcode = obj.Barcode;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId= obj.CategoryId;
                objFromDb.Seller= obj.Seller;
                if(obj.ImageUrl != null) {

                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
