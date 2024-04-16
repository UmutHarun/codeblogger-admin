using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<Context>(options =>
//                    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("YcdMvcProject")));
// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(
		options =>
		{
			options.LoginPath = "/Account/Login/";
		});

builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
						.RequireAuthenticatedUser()
						.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});


//b => b.MigrationsAssembly("YcdMvcProject") N-Art için eklendi

var app = builder.Build();

app.UseAuthentication();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseStatusCodePagesWithReExecute("/Error/{0}");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}



//var cookiePolicyOptions = new CookiePolicyOptions
//{
//	MinimumSameSitePolicy = SameSiteMode.Strict,
//};

//app.UseCookiePolicy(cookiePolicyOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=CategoryList}/{id?}");

app.Run();
