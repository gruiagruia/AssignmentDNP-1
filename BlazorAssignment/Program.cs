using BlazorAssignment.Authentication;
using BlazorAssignment.Services;
using BlazorAssignment.Services.Impls;
using FileData.DataAccess;
using Microsoft.AspNetCore.Components.Authorization;
using IPostService = Contracts.Contracts.IPostService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthServiceImpl>();
builder.Services.AddScoped<IUserService,InMemoryUserService>();
builder.Services.AddScoped<FileContext>();
builder.Services.AddScoped<IPostService, PostFileDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();