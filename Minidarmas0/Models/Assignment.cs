using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minidarmas0.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int RecordingId { get; set; }
        public int TranscriberId { get; set; }
        public string Status { get; set; } // Assigned, InProgress, Completed
        public DateTime AssignedDate { get; set; }
        public string Comments { get; set; }
    }

}
