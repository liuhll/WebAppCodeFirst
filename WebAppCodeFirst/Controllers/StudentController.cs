using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCodeFirst.DAL;
using WebAppCodeFirst.DAL.Interface;
using Microsoft.Practices.ServiceLocation;
using WebAppCodeFirst.Models;

namespace WebAppCodeFirst.Controllers
{
    public class StudentController : Controller
    {
        private readonly IDbContext _dbContext;
        private readonly IDbSet<Student> _dbSet;

        public StudentController()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<SchoolContext>>()
               as ContextManager<SchoolContext>;

            _dbContext = contextManager.GetContext();
            _dbSet = _dbContext.Set<Student>();
        }

        // GET: Student
        public ActionResult Index()
        {
            IList<Student> students = _dbSet.Where(p => 1 == 1).ToList();

            return View(students);
          
        }
    }
}