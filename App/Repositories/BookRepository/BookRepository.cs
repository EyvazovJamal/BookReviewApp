
using App.Models;
using App.Repositories.BookRepository.Base;
using App.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.BookRepository;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext context;

    public BookRepository(AppDbContext context)
    {
        this.context = context;
    }
    

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await context.Books.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await context.Books
                                .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddBookAsync(Book book)
    {
        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
        context.Books.Update(book);
        await context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await context.Books
                                    .FirstOrDefaultAsync(b => b.Id == id);
        if (book != null)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }
    }
    
}




