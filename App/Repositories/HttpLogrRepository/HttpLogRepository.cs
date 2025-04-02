using App.Models;
using App.Repositories.Base;
using App.EntityFramework;

namespace App.Repositories;

public class HttpLogRepository : IHttpLogRepository
{
    private readonly AppDbContext context;

    public HttpLogRepository(AppDbContext context)
    {
       this.context = context;
    }

    public async Task InsertAsync(HttpLog httpLog)
    {
        await context.HttpLogs.AddAsync(httpLog);
        await context.SaveChangesAsync();

    }
}
