using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppCodeFirst.DAL.Interface;

namespace WebAppCodeFirst.DAL
{
    public class BaseDbContext:DbContext,IDbContext
    {
        public BaseDbContext(string connectionStringName, int? StudentId = null)
           : base(connectionStringName)
        {
            StudentId = StudentId;
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public int? StudentId { get; private set; }
    }
}