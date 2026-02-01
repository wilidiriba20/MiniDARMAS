using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minidarmas0.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public string MeetingNo { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Location { get; set; }
        public string Chairperson { get; set; }
        public bool IsFinalApproved { get; set; }
    }

}
