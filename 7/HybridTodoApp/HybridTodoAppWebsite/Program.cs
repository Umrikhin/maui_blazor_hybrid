using HybridTodoAppComponents.Data;
using HybridTodoAppWebsite.Components;
using Microsoft.Maui.Networking;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<TodoService>();
builder.Services.AddSingleton<IConnectivity, BlazorConnectivity>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode().AddAdditionalAssemblies(typeof(HybridTodoAppComponents.Pages.Todo).Assembly);

app.Run();


public class BlazorConnectivity : IConnectivity
{
    public IEnumerable<ConnectionProfile>? ConnectionProfiles => null;

    public NetworkAccess NetworkAccess => NetworkAccess.Internet;

    public event EventHandler<ConnectivityChangedEventArgs>? ConnectivityChanged;
}