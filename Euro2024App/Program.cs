using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Euro2024App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // Identity options configuration here if needed
})
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

// Add Authorization policy for MVC
builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Add Dependency Injection for services
builder.Services.AddScoped<IMatchService, MatchManager>();
builder.Services.AddScoped<IMatchDal, EfMatchDal>();

builder.Services.AddScoped<ITeamDal, EfTeamDal>();
builder.Services.AddScoped<TeamManager>();

builder.Services.AddScoped<ICoachService, CoachManager>();
builder.Services.AddScoped<ICoachDal, EfCoachDal>();

builder.Services.AddScoped<ITeamService, TeamManager>();


// Add Dependency Injection for Player services and data access
builder.Services.AddScoped<IPlayerService, PlayerManager>(); // IPlayerService için PlayerManager'ý yapýlandýrýr
builder.Services.AddScoped<IPlayerDal, EfPlayerDal>(); // IPlayerDal için EfPlayerDal'ý yapýlandýrýr

builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
