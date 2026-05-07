using Microsoft.EntityFrameworkCore;
using SDATests.Db.Models;

namespace SDATests.Db
{
    public class AppContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TicketQuestion> TicketQuestions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
