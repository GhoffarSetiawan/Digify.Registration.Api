using Digify.Registration.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.SelectParameters
{
    public abstract class SelectParameterBase : ISelectParameter
    {     
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? SortBy { get; set; }
        public SortDirection? SortDirection { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
