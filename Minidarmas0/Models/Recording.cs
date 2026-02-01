using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minidarmas0.Models
{
    public class Recording
    {
        public int RecordingId { get; set; }
        public int AgendaId { get; set; }
        public string AudioFilePath { get; set; }
    }

}
