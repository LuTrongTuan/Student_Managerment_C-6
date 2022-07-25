using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor_WebAssembly.IServices;
using Blazor_WebAssembly.Pages;
using DTO.SchoolDto;

namespace Blazor_WebAssembly.Services
{
    public class SchoolApiClient:ISchoolApiClient
    {
        private readonly HttpClient _httpClient;

        public SchoolApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<SchoolViewModel>> GetSchool()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SchoolViewModel>>("api/Schools");
            return result;
        }
    }
}
