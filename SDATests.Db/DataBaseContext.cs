using Microsoft.EntityFrameworkCore;
using SDATests.Db.Models;

namespace SDATests.Db
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
