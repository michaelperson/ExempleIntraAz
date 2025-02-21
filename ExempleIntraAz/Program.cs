using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(
    options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

            }
    ).AddMicrosoftIdentityWebApp
    (
       builder.Configuration.GetSection("AzureAd")
    
    );
builder.Services.AddAuthorization(
    optionsAutho=>
    {
        optionsAutho.AddPolicy("Best", Policy => 
        {
            Policy.RequireClaim("groups",
                new[] { "12eb6100-e2e4-481e-bc69-6256e2c1cdb7"}
                );
        });
    }
);

//Dingler - Ne la laisse pas tomber
builder.Services.ConfigureApplicationCookie(
    options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    }
    );


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
