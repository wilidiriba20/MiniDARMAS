using MiniDARMAS.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace MiniDARMAS.Logic
{
    public class AgendaBLL
    {
        AgendaDAL dal = new AgendaDAL();

        public DataTable GetAgendasByMeeting(int meetingId)
        {
            return dal.GetAgendasByMeeting(meetingId);
        }
         
        public void AddAgenda(int meetingId, string title, string office, string doc)
        {
            if (meetingId <= 0)
            {
                MessageBox.Show("Select a meeting first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateAgenda(title, office, doc))
                return;
            if (meetingId == 0)
            {
                MessageBox.Show("Please select a meeting first.");
                return;
            }

            if (dal.IsAgendaTitleExists(meetingId, title))
            {
                MessageBox.Show("This agenda title already exists for this meeting.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dal.AddAgenda(meetingId, title, office, doc);
        }

        public void UpdateAgenda(int agendaId, int meetingId, string title, string office, string doc)
        {
            if (agendaId <= 0)
            {
                MessageBox.Show("Select an agenda first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateAgenda(title, office, doc))
                return;

            if (dal.IsAgendaTitleExists(meetingId, title, agendaId))
            {
                MessageBox.Show("This agenda title already exists for this meeting.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dal.UpdateAgenda(agendaId, meetingId, title, office, doc);
        }

        public bool DeleteAgenda(int agendaId)
        {
            int rows = dal.DeleteAgenda(agendaId);
            return rows > 0;
        }
       
        private bool ValidateAgenda(string title, string office, string doc)
        {
            string errorMessage = "";

            if (string.IsNullOrWhiteSpace(title))
                errorMessage += "Agenda title is required. ";

            if (string.IsNullOrWhiteSpace(office))
                errorMessage += "Office is required. ";

            if (string.IsNullOrWhiteSpace(doc))
                errorMessage += "Document is required. ";

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage.Trim(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
