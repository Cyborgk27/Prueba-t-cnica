using Consultorio_de_seguros.DataAccess;
using Consultorio_de_seguros.DataAccess.Interfaces;
using Consultorio_de_seguros.Models;
using Consultorio_de_seguros.Services;
using Consultorio_de_seguros.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ConsultorioSegurosContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("InsuranceConnection")));

//Repositories
builder.Services.AddScoped<IAseguradoRepository, AseguradoRepository>();
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<IAsignacionRepository, AsignacionRepository>();

//Services
builder.Services.AddScoped<IAseguradoService, AseguradoService>();
builder.Services.AddScoped<ISeguroService, SeguroService>();
builder.Services.AddScoped<IAsignacionService, AsignacionService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Consulta}/{action=Index}/{id?}");

app.Run();
