using Microsoft.EntityFrameworkCore;
using SDATests.Db.Models;

namespace SDATests.Db
{
    public class DataBaseContext: DbContext
    {
        public DbSet<Question> Question { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<TicketQuestion> TicketQuestion { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options) 
        {
            Database.EnsureCreated();
        }

    }
}
