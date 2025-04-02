using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Enums;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.EntityFramework;

public class AppDbContext: IdentityDbContext<IdentityUser,IdentityRole,string>
{
    public DbSet<Book> Books { get; set; }
    public DbSet<HttpLog> HttpLogs { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<UsersRoles> UsersRoles { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options ): base(options){ }
}
