using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor_WebAssembly.IServices;
using Blazor_WebAssembly.Pages;

namespace Blazor_WebAssembly.Services
{
    public class SchoolApiClient:ISchoolApiClient
    {
        private readonly HttpClient _httpClient;

        public SchoolApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<School>> GetSchool()
        {
            var result = await _httpClient.GetFromJsonAsync<List<School>>("api/Schools");
            return result;
        }
    }
}
