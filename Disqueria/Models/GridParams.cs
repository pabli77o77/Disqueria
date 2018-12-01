using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Disqueria.Models
{
    public class GridParams<T>
    {
        public int page { get; set; }
        public int top { get; set; }
        public Expression<Func<T, bool>> where { get; set; }
        public Func<T, object> orderby { get; set; }
        public Func<T, object> orderbydesc { get; set; }

        public GridParams(int _page, int _top)
        {
            this.page = _page;
            this.top = _top;
            this.where = null;
            this.orderby = null;
            this.orderbydesc = null;
        }

    }
}
