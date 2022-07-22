using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor_WebAssembly.IServices;
using Microsoft.AspNetCore.Components;

namespace Blazor_WebAssembly.Pages
{
    public partial class School
    {
        [Inject] private ISchoolApiClient SchoolApiClient { get; set; }
        private List<School> Schools = new List<School>();

        protected override async Task OnInitializedAsync()
        {
            Schools = await SchoolApiClient.GetSchool();
        }
    }
}
