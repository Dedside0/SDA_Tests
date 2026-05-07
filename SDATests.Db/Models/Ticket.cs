using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDATests.Db.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public List<TicketQuestion> TicketQuestions { get; set; } 
    }
}
