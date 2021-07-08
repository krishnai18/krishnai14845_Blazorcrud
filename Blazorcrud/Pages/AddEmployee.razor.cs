using Blazorcrud.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazorcrud.Pages
{
    public partial class AddEmployee
    {
        [Inject] public ApiService service { get; set; }
        protected async void PostEmployee()
        {
            service.CreateEmployee(obj);
        }
    }
}
