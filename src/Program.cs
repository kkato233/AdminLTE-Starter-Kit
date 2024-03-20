using Company.WebApplication1.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Company.WebApplication1.Services.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Company.WebApplication1.Services.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using asp_net_admin.Utility;
using ScottBrady91.AspNetCore.Identity;
using asp_net_admin.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.Configure<CookieTempDataProviderOptions>(options =>
{
    options.Cookie.IsEssential = true;
});

// Add services to the container.
var Configuration = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseMySQL(connectionString));

builder.Services.AddDbContext<AspNetAdminContext>(options =>
       options.UseMySQL(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(config =>
{
    config.User.RequireUniqueEmail = true;    //  email
    config.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+";
    config.SignIn.RequireConfirmedEmail = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IUserStore<IdentityUser>, CustomUserStore>();

builder.Services.AddScoped<IPasswordHasher<IdentityUser>, BCryptPasswordHasher<IdentityUser>>();

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/");

    options.Conventions.AllowAnonymousToPage("/Error");
    options.Conventions.AllowAnonymousToPage("/Account/AccessDenied");
    options.Conventions.AllowAnonymousToPage("/Account/ConfirmEmail");
    options.Conventions.AllowAnonymousToPage("/Account/ExternalLogin");
    options.Conventions.AllowAnonymousToPage("/Account/ForgotPassword");
    options.Conventions.AllowAnonymousToPage("/Account/ForgotPasswordConfirmation");
    options.Conventions.AllowAnonymousToPage("/Account/Lockout");
    options.Conventions.AllowAnonymousToPage("/Account/Login");
    options.Conventions.AllowAnonymousToPage("/Account/LoginWith2fa");
    options.Conventions.AllowAnonymousToPage("/Account/LoginWithRecoveryCode");
    options.Conventions.AllowAnonymousToPage("/Account/Register");
    options.Conventions.AllowAnonymousToPage("/Account/ResetPassword");
    options.Conventions.AllowAnonymousToPage("/Account/ResetPasswordConfirmation");
    options.Conventions.AllowAnonymousToPage("/Account/SignedOut");
});

builder.Services.AddControllersWithViews()
    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

if (Configuration["Email:EmailProvider"] == "SendGrid")
{
    builder.Services.Configure<SendGridAuthOptions>(Configuration.GetSection("Email:SendGrid"));
    builder.Services.AddSingleton<IMailManager, SendGridMailManager>();
}
else
{
    builder.Services.AddSingleton<IMailManager, EmptyMailManager>();
}

builder.Services.AddScoped<ProfileManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
    app.UseDatabaseErrorPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
