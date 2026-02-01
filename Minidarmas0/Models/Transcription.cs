using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minidarmas0.Models
{
    public class Transcription
    {
        public int TranscriptionId { get; set; }
        public int AssignmentId { get; set; }
        public int RecordingId { get; set; }
        public string TranscriptText { get; set; }
        public string Status { get; set; } // Draft, Submitted, Approved, Returned, FinalApproved
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Comment { get; set; }
    }

}
