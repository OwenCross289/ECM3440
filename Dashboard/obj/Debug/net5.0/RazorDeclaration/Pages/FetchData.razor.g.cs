// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Dashboard.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Repos\ECM3440\ECM3440\Dashboard\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Repos\ECM3440\ECM3440\Dashboard\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Repos\ECM3440\ECM3440\Dashboard\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Repos\ECM3440\ECM3440\Dashboard\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Repos\ECM3440\ECM3440\Dashboard\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Repos\ECM3440\ECM3440\Dashboard\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Repos\ECM3440\ECM3440\Dashboard\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Repos\ECM3440\ECM3440\Dashboard\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Repos\ECM3440\ECM3440\Dashboard\_Imports.razor"
using Dashboard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Repos\ECM3440\ECM3440\Dashboard\_Imports.razor"
using Dashboard.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Repos\ECM3440\ECM3440\Dashboard\Pages\FetchData.razor"
using Dashboard.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "D:\Repos\ECM3440\ECM3440\Dashboard\Pages\FetchData.razor"
       
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WeatherForecastService ForecastService { get; set; }
    }
}
#pragma warning restore 1591
