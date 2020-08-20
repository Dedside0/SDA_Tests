using Microsoft.EntityFrameworkCore;
using SDATests.Db.Models;

namespace SDATests.Db
{
    public class TicketRepository(AppContext dbContext) : ITicketRepository
    {

        public List<Ticket> GetAll() =>
            dbContext.Tickets.Include(x => x.TicketQuestions).
            ThenInclude(x => x.Question).
            ThenInclude(x=>x.Answers).
            ToList();


        public Ticket? TryGetById(Guid id) =>
            dbContext.Tickets.Include(x => x.TicketQuestions).ThenInclude(x => x.Question).
            ThenInclude(x => x.Answers).FirstOrDefault(x => x.Id == id);


        public void Create(Ticket ticket)
        {
            dbContext.Tickets.Add(ticket);
            dbContext.SaveChanges();
        }
    }
}
