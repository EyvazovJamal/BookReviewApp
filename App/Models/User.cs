using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace App.Models;

public class User 
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public required string Email { get; set; } 
    public string AvatarUrl { get; set; } = @"C:\Users\acer\OneDrive\Документы\BookReviewApp\BookReviewApp\App\AvatarPhoto\blue-circle-with-white-user_78370-4707.avif";
    public string? Password { get; set; }
    public List<Book> FavoriteBooks { get; set; }= new ();
}