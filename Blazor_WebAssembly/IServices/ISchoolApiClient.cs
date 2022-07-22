using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor_WebAssembly.Pages;

namespace Blazor_WebAssembly.IServices
{
    public interface ISchoolApiClient
    {
        Task<List<School>> GetSchool();
    }
}
