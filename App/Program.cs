using System.Reflection;
using FluentValidation;
using App.Middlewares;
using App.Repositories;
using App.Repositories.Base;
using App.Repositories.BookRepository;
using App.Repositories.BookRepository.Base;
using App.Services;
using App.Services.Base;
using App.Services.BookServices;
using App.Services.BookServices.Base;
using Microsoft.EntityFrameworkCore;
using App.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options=>{
    var connectionString=builder.Configuration.GetConnectionString("BookReviewDb");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ITestService,TestService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssemblies(new Assembly[]{
    Assembly.GetExecutingAssembly()
});

builder.Services.AddScoped<IHttpLogRepository,HttpLogRepository>();
builder.Services.AddScoped<IHttpLogger,HttpLogger>();
builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddScoped<IBookService,BookService>();


builder.Services.AddIdentity<IdentityUser,IdentityRole>(options=>{})
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDataProtection();

builder.Services.AddAuthentication(defaultScheme: CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(
        authenticationScheme: CookieAuthenticationDefaults.AuthenticationScheme,
        configureOptions: options =>
        {
            options.LoginPath = "/Identity/Login";
        });


builder.Services.AddAuthorization(options=>{
    options.AddPolicy(
        name:"AdminPolicy",
        configurePolicy:policyBuilder=>{
            policyBuilder
                .RequireRole("Admin");
        }
    );
     options.AddPolicy(
        name:"UserPolicy",
        configurePolicy:policyBuilder=>{
            policyBuilder
                .RequireRole("User");
        }
    );
});


var app = builder.Build();

var serviceScope=app.Services.CreateScope();
var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

await roleManager.CreateAsync(new IdentityRole {Name = "Admin"});
await roleManager.CreateAsync(new IdentityRole {Name = "User"});


app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();


app.Run();

