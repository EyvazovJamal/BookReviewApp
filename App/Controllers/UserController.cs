using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Models;
using App.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection; 
public class UserController : Controller
{
    private readonly AppDbContext dbContext;
    private readonly IDataProtector dataProtector;
    public UserController(AppDbContext dbContext, IDataProtectionProvider dataProtectionProvider)
    {
        this.dbContext = dbContext;
        this.dataProtector = dataProtectionProvider.CreateProtector("Identity");
    }


    [Authorize]
    public IActionResult MyInfo()
    {
        var user = new User {
            Id = int.Parse(base.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value!),
            Name = base.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value!,
            Email = base.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value!,
        };

        return base.View(user);
    }
}
