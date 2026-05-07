using SDATests.Db.Models;

namespace SDATests.Db
{
    public interface ITicketRepository
    {
        void Create(Ticket ticket);
        List<Ticket> GetAll();
        Ticket? TryGetById(Guid id);
    }
}