﻿using Proyetct11.DataAccess.Data;
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

        public ICompanyRepository Company { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }

       

        public UnitOfWork(AplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepostory(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
           Company = new CompanyRepository(_db);
        }
       
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
