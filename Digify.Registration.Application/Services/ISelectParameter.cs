using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.Services
{
    public interface ISelectParameter
    {   
        string? Code { get; set; }
        string? Name { get; set; }
        string? SortBy { get; set; }
        SortDirection? SortDirection { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
    }
}
