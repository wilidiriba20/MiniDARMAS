using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniDARMAS.Data
{
    public class MeetingDAL
    {
        private DBConnection db = new DBConnection();

        public DataTable GetMeetings()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT MeetingId, MeetingNo, MeetingDate, Location, Chairperson, " +
                    "CASE WHEN IsFinalApproved = 1 THEN 'Approved' ELSE 'Pending' END AS Status " +
                    "FROM Meetings", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public string GetFinalApprovedMeetingText(int meetingId)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT t.TranscriptText
              FROM Transcriptions t
              INNER JOIN Assignments a ON t.AssignmentId = a.AssignmentId
              INNER JOIN Recordings r ON a.RecordingId = r.RecordingId
              INNER JOIN Agendas ag ON r.AgendaId = ag.AgendaId
              WHERE ag.MeetingId = @meetingId
                AND t.Status = 'Approved'
              ORDER BY t.CreatedAt",
                    conn);

                cmd.Parameters.AddWithValue("@meetingId", meetingId);
                SqlDataReader dr = cmd.ExecuteReader();
                string finalText = "";
                while (dr.Read())
                {
                    finalText += dr["TranscriptText"].ToString() + Environment.NewLine;
                }
                return finalText;
            }
        }


        public bool IsMeetingAlreadyFinalApproved(int meetingId)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT IsFinalApproved FROM Meetings WHERE MeetingId = @meetingId",
                    conn);

                cmd.Parameters.AddWithValue("@meetingId", meetingId);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        public bool MarkMeetingFinalApproved(int meetingId)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Meetings SET IsFinalApproved = 1, Status = 'FinalApproved' WHERE MeetingId = @meetingId",
                    conn);

                cmd.Parameters.AddWithValue("@meetingId", meetingId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Other methods ...
        public bool AddMeeting(string meetingNo, DateTime date, string location, string chairperson)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Meetings(MeetingNo, MeetingDate, Location, Chairperson, Status, IsFinalApproved) " +
                    "VALUES(@mno,@date,@loc,@chair, 'Pending', 0)", conn);

                cmd.Parameters.AddWithValue("@mno", meetingNo);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@loc", location);
                cmd.Parameters.AddWithValue("@chair", chairperson);

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public void UpdateMeeting(int meetingId, string meetingNo, DateTime date, string location, string chairperson)
        {
            try
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Meetings SET MeetingNo=@mno, MeetingDate=@date, Location=@loc, Chairperson=@chair WHERE MeetingId=@id",
                        conn);

                    cmd.Parameters.AddWithValue("@id", meetingId);
                    cmd.Parameters.AddWithValue("@mno", meetingNo);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@loc", location);
                    cmd.Parameters.AddWithValue("@chair", chairperson);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int DeleteMeeting(int meetingId)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("DELETE FROM Agendas WHERE MeetingId = @mid", conn);
                cmd1.Parameters.AddWithValue("@mid", meetingId);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE FROM Meetings WHERE MeetingId = @mid", conn);
                cmd2.Parameters.AddWithValue("@mid", meetingId);

                return cmd2.ExecuteNonQuery();
            }
        }

        public bool IsMeetingNoExists(string meetingNo, int meetingId = 0)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Meetings WHERE MeetingNo = @mno";

                if (meetingId > 0)
                    query += " AND MeetingId != @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mno", meetingNo);

                if (meetingId > 0)
                    cmd.Parameters.AddWithValue("@id", meetingId);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
