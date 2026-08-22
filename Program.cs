using LinkGate.frontend;
using LinkGate.frontend.Services.Applications;
using LinkGate.frontend.Services.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://api-test-linkgate22.runasp.net/") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7185/") });
builder.Services.AddScoped<ApplicationService>(); 

// أضف هذا السطر مع الـ Services الأخرى
builder.Services.AddScoped<LoadingService>();

await builder.Build().RunAsync();
