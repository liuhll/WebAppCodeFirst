using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppCodeFirst.DAL.Interface;

namespace WebAppCodeFirst.DAL
{
    public class ContextManager<TContext> : IContextManager<TContext>
          where TContext : IDbContext, new()
    {
        private static string _contextKey = "ContextManager.Context";

        public ContextManager()
        {
            _contextKey = "ContextKey." + typeof(TContext);
        }

        public IDbContext GetContext()
        {
            if (HttpContext.Current.Items[_contextKey] == null)
            {
                HttpContext.Current.Items[_contextKey] = new TContext();
            }
            return HttpContext.Current.Items[_contextKey] as IDbContext;
        }

        public void Finish()
        {
            if (HttpContext.Current.Items[_contextKey] != null)
            {
                (HttpContext.Current.Items[_contextKey] as IDbContext).Dispose();
            }
        }
    }
}