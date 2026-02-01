using MiniDARMAS.Data;
using System.Data;
using System.Windows.Forms;

namespace MiniDARMAS.Logic
{
    public class RecordingBLL
    {
        RecordingDAL dal = new RecordingDAL();

        public DataTable GetRecordingsByAgenda(int agendaId)
        {
            return dal.GetRecordingsByAgenda(agendaId);
        }

        public void AddRecording(int agendaId, string path)
        {
            dal.AddRecording(agendaId, path);
        }
        public void AssignRecording(int recordingId)
        {
            if (recordingId <= 0)
            {
                MessageBox.Show("Invalid recording selection.");
                return;
            }
        }

        public bool DeleteRecording(int recordingId)
        {
            return dal.DeleteRecording(recordingId);
        }

    }
}
