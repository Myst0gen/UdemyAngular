using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int maxPageSize = 50;
        public int pageIndex { get; set; } = 1;
        private int _pageSize = 6;
        public int pageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
        public int? brandId { get; set; }
        public int? typeId { get; set; }
        public string sort { get; set; }
        private string _search;
        public string search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}