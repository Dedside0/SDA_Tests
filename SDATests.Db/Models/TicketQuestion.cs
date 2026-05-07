using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SDATests.Db.Models
{
    public class TicketQuestion
    {
        public Guid Id { get; set; }

        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; } 

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public int OrderIndex { get; set; }
    }
}
