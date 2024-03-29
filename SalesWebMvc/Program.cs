﻿using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Data;
using SalesWebMvc.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcContext"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("SalesWebMvcContext")),
    builder => builder.MigrationsAssembly("SalesWebMvc")));

/*var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(connection)); */


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartamentService>();
builder.Services.AddScoped<SalesRecordService>();



var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
Task<List<SalesWebMvc.Models.Seller>> sellers = app.Services.CreateScope().ServiceProvider.GetRequiredService<SellerService>().FindAllAsync();
Task<List<SalesWebMvc.Models.Departament>> departaments = app.Services.CreateScope().ServiceProvider.GetRequiredService<DepartamentService>().FindAllAsync();




// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{    
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
