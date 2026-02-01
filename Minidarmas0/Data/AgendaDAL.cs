using System;
using System.Data;
using System.Data.SqlClient;

namespace MiniDARMAS.Data
{
    public class AgendaDAL
    {
        DBConnection db = new DBConnection();

        public DataTable GetAgendasByMeeting(int meetingId)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Agendas WHERE MeetingId=@mid", conn);
                da.SelectCommand.Parameters.AddWithValue("@mid", meetingId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddAgenda(int meetingId, string title, string office, string doc)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Agendas(MeetingId, AgendaTitle, Office, SupportingDocument) VALUES(@mid,@title,@office,@doc)", conn);
                cmd.Parameters.AddWithValue("@mid", meetingId);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@office", office);
                cmd.Parameters.AddWithValue("@doc", doc);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateAgenda(int agendaId, int meetingId, string title, string office, string doc)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Agendas SET MeetingId=@mid, AgendaTitle=@title, Office=@office, SupportingDocument=@doc WHERE AgendaId=@id", conn);
                cmd.Parameters.AddWithValue("@id", agendaId);
                cmd.Parameters.AddWithValue("@mid", meetingId);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@office", office);
                cmd.Parameters.AddWithValue("@doc", doc);
                cmd.ExecuteNonQuery();
            }
        }

        public int DeleteAgenda(int agendaId)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = "DELETE FROM Agendas WHERE AgendaId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", agendaId);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public class AssignmentDAL
        {
            DBConnection db = new DBConnection();

            public DataTable GetAssignmentsByTranscriber(int transcriberId)
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(
                        @"SELECT a.AssignmentId, m.MeetingNo, ag.Title AS AgendaTitle,
                             r.AudioPath, a.Status
                      FROM Assignments a
                      JOIN Recordings r ON a.RecordingId = r.RecordingId
                      JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                      JOIN Meetings m ON ag.MeetingId = m.MeetingId
                      WHERE a.TranscriberId = @tid", conn);

                    da.SelectCommand.Parameters.AddWithValue("@tid", transcriberId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

            public void SaveDraft(int assignmentId, string transcript)
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Assignments SET Transcript=@trans WHERE AssignmentId=@id", conn);

                    cmd.Parameters.AddWithValue("@trans", transcript);
                    cmd.Parameters.AddWithValue("@id", assignmentId);
                    cmd.ExecuteNonQuery();
                }
            }

            public void UpdateStatus(int assignmentId, string status)
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Assignments SET Status=@status WHERE AssignmentId=@id", conn);

                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", assignmentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetSubmittedAssignments()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT AssignmentId, Transcript, Status
              FROM Assignments
              WHERE Status = 'Submitted'", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void SaveComments(int assignmentId, string comments)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Assignments SET Comments=@comments WHERE AssignmentId=@id", conn);

                cmd.Parameters.AddWithValue("@comments", comments);
                cmd.Parameters.AddWithValue("@id", assignmentId);
                cmd.ExecuteNonQuery();
            }
        }
        public string GetFinalApprovedMeetingText(int meetingId)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT ag.Title, a.Transcript
              FROM Assignments a
              JOIN Recordings r ON a.RecordingId = r.RecordingId
              JOIN Agendas ag ON r.AgendaId = ag.AgendaId
              WHERE ag.MeetingId=@mid AND a.Status='Approved'
              ORDER BY ag.AgendaId", conn);

                cmd.Parameters.AddWithValue("@mid", meetingId);
                SqlDataReader reader = cmd.ExecuteReader();

                string finalText = "";
                while (reader.Read())
                {
                    finalText += "AGENDA: " + reader["Title"] + "\n\n";
                    finalText += reader["Transcript"] + "\n\n";
                    finalText += "--------------------------------------\n\n";
                }
                return finalText;
            }
        }
        public bool IsAgendaTitleExists(int meetingId, string title, int agendaId = 0)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Agendas WHERE MeetingId = @mid AND AgendaTitle = @title";

                if (agendaId > 0)
                    query += " AND AgendaId != @aid";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mid", meetingId);
                cmd.Parameters.AddWithValue("@title", title);

                if (agendaId > 0)
                    cmd.Parameters.AddWithValue("@aid", agendaId);

                object result = cmd.ExecuteScalar();
                int count = (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);

                return count > 0;
            }
        }

        public void MarkMeetingFinalApproved(int meetingId)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Meetings SET IsFinalApproved=1 WHERE MeetingId=@mid", conn);

                cmd.Parameters.AddWithValue("@mid", meetingId);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
