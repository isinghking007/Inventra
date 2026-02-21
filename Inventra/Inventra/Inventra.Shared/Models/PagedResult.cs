using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventra.Shared.Models
{
    public class PagedResult<T>
    {
        public int Page { get;set; }
        public int PageSize { get;set; }
        public int TotalRecords { get;set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; } = new();
    }
}
