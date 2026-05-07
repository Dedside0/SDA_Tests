using SDATests.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDATests.Models
{
    public class TicketViewModel()
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<TicketQuestionViewModel> TicketQuestions { get; set; }

        public TicketViewModel(Ticket ticket):this()
        {
            Id = ticket.Id;
            TicketQuestions = new List<TicketQuestionViewModel>();
            foreach (var item in ticket.TicketQuestions)
            {
                TicketQuestions.Add(new TicketQuestionViewModel(item));
            }
        }
    }
}
