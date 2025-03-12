using App.Interfaces;
using Data.EF;
using Data.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Notes.Interfaces;
using Notes.Services;
using Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Notes")));
builder.Services.AddScoped<INoteRepository, NoteRepository>();


builder.Services.AddScoped<INoteDomainService, NoteDomainService>();

builder.Services.AddScoped<INoteAppService, NoteAppService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 


builder.Services.AddScoped<IMapperService, MapperService>();
var app = builder.Build();


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
    pattern: "{controller=Notes}/{action=Index}/{id?}");

app.Run();
