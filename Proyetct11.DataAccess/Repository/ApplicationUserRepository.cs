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
    public class ApplicationUserRepostory : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private AplicationDbContext _db;
        public ApplicationUserRepostory(AplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
