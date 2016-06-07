using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using WebAppCodeFirst.DAL;
using WebAppCodeFirst.DAL.Interface;
using WebAppCodeFirst.Models;

namespace WebAppCodeFirst.Controllers.Base
{
    public abstract class BaseController<T> : Controller where T:class 
    {

        protected readonly IDbContext _dbContext;
        protected readonly IDbSet<T> _dbSet;

        protected  BaseController()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<SchoolContext>>()
               as ContextManager<SchoolContext>;
            _dbContext = contextManager.GetContext();
            _dbSet = _dbContext.Set<T>();
        }

    }
}