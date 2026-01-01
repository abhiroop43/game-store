using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

var gameStoreApiUrl = builder.Configuration.GetValue<string>("ApiBaseUrl")!;

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddHttpClient<GamesClient>(client => client.BaseAddress = new Uri(gameStoreApiUrl));
builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(gameStoreApiUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Error", true);
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

await app.RunAsync();