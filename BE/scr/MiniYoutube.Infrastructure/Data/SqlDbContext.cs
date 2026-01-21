using Microsoft.EntityFrameworkCore;

namespace MiniYoutube.Infrastructure.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }
    }
}
