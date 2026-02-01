using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minidarmas0.Models
{
    public class Agenda
    {
        public int AgendaId { get; set; }
        public int MeetingId { get; set; }
        public string AgendaTitle { get; set; }
        public string Office { get; set; }
        public string SupportingDocument { get; set; }
    }

}
