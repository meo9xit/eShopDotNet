using AutoMapper;
using eShopData.ConfigMapper;
using eShopData.Context;
using eShopData.Entities;
using eShopData.IService;
using eShopData.Services;
using eShopData.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<ConfigMapper>();
});
builder.Services.AddDbContext<eShopContext>(options => options.UseSqlServer(DbContextHelper.GetConnectionString()));
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<eShopContext>().AddDefaultTokenProviders();
builder.Services.AddSingleton(sp => config.CreateMapper());
builder.Services.AddTransient<IUserService, UserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
