using MiniDARMAS.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace MiniDARMAS.Logic
{
    public class MeetingBLL
    {
        private MeetingDAL dal = new MeetingDAL();

        public DataTable GetMeetings()
        {
            return dal.GetMeetings();
        }

        public bool IsMeetingAlreadyFinalApproved(int meetingId)
        {
            return dal.IsMeetingAlreadyFinalApproved(meetingId);
        }

        public bool MarkMeetingFinalApproved(int meetingId)
        {
            return dal.MarkMeetingFinalApproved(meetingId);
        }

        public string GetFinalApprovedMeetingText(int meetingId)
        {
            return dal.GetFinalApprovedMeetingText(meetingId);
        }

        // Add meeting with validation inside BLL
        public bool AddMeeting(string meetingNo, DateTime date, string location, string chairperson)
        {
            if (!ValidateMeeting(meetingNo, date, location, chairperson))
                return false;

            if (dal.IsMeetingNoExists(meetingNo))
            {
                MessageBox.Show("Meeting number already exists. Please use another.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return dal.AddMeeting(meetingNo, date, location, chairperson);
        }



        // Update meeting with validation inside BLL
        public bool UpdateMeeting(int meetingId, string meetingNo, DateTime date, string location, string chairperson)
        {
            if (meetingId <= 0)
            {
                MessageBox.Show("Invalid Meeting ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateMeeting(meetingNo, date, location, chairperson))
                return false;

            if (dal.IsMeetingNoExists(meetingNo, meetingId))
            {
                MessageBox.Show("Meeting number already exists. Please use another.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            dal.UpdateMeeting(meetingId, meetingNo, date, location, chairperson);
            return true;
        }

        public bool DeleteMeeting(int meetingId)
        {
            if (meetingId <= 0)
            {
                MessageBox.Show("Invalid Meeting ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int rowsAffected = dal.DeleteMeeting(meetingId);
            return rowsAffected > 0;
        }

        private bool ValidateMeeting(string meetingNo, DateTime date, string location, string chairperson)
        {
            string errorMessage = "";

            if (string.IsNullOrWhiteSpace(meetingNo))
                errorMessage += "Meeting number is required. ";

            if (string.IsNullOrWhiteSpace(location))
                errorMessage += "Location is required. ";

            if (string.IsNullOrWhiteSpace(chairperson))
                errorMessage += "Chairperson is required. ";

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage.Trim(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        public string GetApprovedTranscriptsByMeeting(int meetingId)
        {
            return dal.GetFinalApprovedMeetingText(meetingId);
        }


    }
}
