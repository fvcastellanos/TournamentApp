using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using TournamentApp.Components;
using Steeltoe.Extensions.Configuration.Placeholder;
using TournamentApp.Services;
using TournamentApp.Hubs;
using Steeltoe.Connector.MongoDb;
using TournamentApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorise(options => 
    {
        options.Immediate = true;
    }).AddBootstrap5Providers()
    .AddFontAwesomeIcons();

builder.Services.AddSignalR();

// MongoDB
builder.Services.AddMongoClient(builder.Configuration);

// Repositories
builder.Services.AddSingleton<TournamentRepository>();

// Services
builder.Services.AddSingleton<ChatService>();

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .AddPlaceholderResolver();

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

app.MapHub<SimpleChatHub>(SimpleChatHub.HubUrl);

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
