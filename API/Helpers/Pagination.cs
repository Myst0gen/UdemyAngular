using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int count, IEnumerable<T> data)
        {
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
            this.count = count;
            this.data = data;
        }

        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int count { get; set; }
        public IEnumerable<T> data { get; set; }
    }
}