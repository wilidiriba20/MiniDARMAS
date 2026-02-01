using System;
using System.Data;
using System.Data.SqlClient;

namespace MiniDARMAS.Data
{
    public class AssignmentDAL
    {
        private DBConnection db = new DBConnection();

        // Get assignments by recording
        public DataTable GetAssignmentsByRecording(int recordingId)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"SELECT a.AssignmentId, r.RecordingId, m.MeetingNo, ag.AgendaTitle,
                                        r.AudioFilePath, a.TranscriberId, u.FullName, a.Status
                                 FROM Assignments a
                                 INNER JOIN Recordings r ON a.RecordingId = r.RecordingId
                                 INNER JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                                 INNER JOIN Meetings m ON ag.MeetingId = m.MeetingId
                                 LEFT JOIN Users u ON a.TranscriberId = u.UserId
                                 WHERE a.RecordingId = @recordingId";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@recordingId", recordingId);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Assign recording to a transcriber
        public bool AssignRecording(int recordingId, int transcriberId)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"
                    INSERT INTO Assignments (RecordingId, TranscriberId, Status)
                    VALUES (@rid, @uid, 'Assigned')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@rid", recordingId);
                cmd.Parameters.AddWithValue("@uid", transcriberId);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Update assignment status only
        public bool UpdateStatus(int assignmentId, string status)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"UPDATE Assignments
                                 SET Status = @status
                                 WHERE AssignmentId = @assignmentId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@assignmentId", assignmentId);
                cmd.Parameters.AddWithValue("@status", status);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Get assignments assigned to a transcriber
        public DataTable GetAssignmentsByTranscriber(int transcriberId)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"
                    SELECT 
                        a.AssignmentId,
                        m.MeetingNo,
                        ag.AgendaTitle,
                        r.AudioFilePath,
                        t.TranscriptText,
                        t.Status
                    FROM Assignments a
                    INNER JOIN Recordings r ON a.RecordingId = r.RecordingId
                    INNER JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                    INNER JOIN Meetings m ON ag.MeetingId = m.MeetingId
                    LEFT JOIN Transcriptions t ON t.AssignmentId = a.AssignmentId
                    WHERE a.TranscriberId = @transcriberId";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@transcriberId", transcriberId);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Save transcription with status and editor comment
        public bool SaveTranscription(
    int assignmentId,
    string transcriptText,
    string status,
    string comment
)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"
            IF EXISTS (SELECT 1 FROM Transcriptions WHERE AssignmentId = @assignmentId)
            BEGIN
                UPDATE Transcriptions
                SET TranscriptText = @transcriptText,
                    Status = @status,
                    Comment = @comment,
                    UpdatedAt = GETDATE()
                WHERE AssignmentId = @assignmentId
            END
            ELSE
            BEGIN
                INSERT INTO Transcriptions (AssignmentId, TranscriptText, Status, Comment, CreatedAt)
                VALUES (@assignmentId, @transcriptText, @status, @comment, GETDATE())
            END

            UPDATE Assignments
            SET Status = @status
            WHERE AssignmentId = @assignmentId
        ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@assignmentId", assignmentId);
                cmd.Parameters.AddWithValue("@transcriptText", transcriptText);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@comment", comment ?? "");

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // Get transcript text by assignment
        public string GetTranscriptByAssignment(int assignmentId)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"SELECT TranscriptText
                                 FROM Transcriptions
                                 WHERE AssignmentId = @assignmentId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@assignmentId", assignmentId);

                con.Open();
                var result = cmd.ExecuteScalar();
                return result == null ? "" : result.ToString();
            }
        }

        // Get submitted assignments for editor review
        public DataTable GetSubmittedAssignments()
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"
                    SELECT 
                        a.AssignmentId,
                        t.TranscriptText,
                        t.Comment,
                        a.Status
                    FROM Assignments a
                    INNER JOIN Transcriptions t ON a.AssignmentId = t.AssignmentId
                    WHERE a.Status = 'Submitted'";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
