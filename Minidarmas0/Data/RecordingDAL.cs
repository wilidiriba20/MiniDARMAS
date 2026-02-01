using System.Data;
using System.Data.SqlClient;

namespace MiniDARMAS.Data
{
    public class RecordingDAL
    {
        DBConnection db = new DBConnection();

        public DataTable GetRecordingsByAgenda(int agendaId)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Recordings WHERE AgendaId=@aid", conn);
                da.SelectCommand.Parameters.AddWithValue("@aid", agendaId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddRecording(int agendaId, string path)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Recordings(AgendaId, AudioFilePath) VALUES(@aid,@path)", conn);
                cmd.Parameters.AddWithValue("@aid", agendaId);
                cmd.Parameters.AddWithValue("@path", path);
                cmd.ExecuteNonQuery();
            }
        }

        public bool DeleteRecording(int recordingId)
        {
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();

                //

                // 2) delete recording
                SqlCommand cmd2 = new SqlCommand(
                    "DELETE FROM Recordings WHERE RecordingId = @rid", con);
                cmd2.Parameters.AddWithValue("@rid", recordingId);

                int rows = cmd2.ExecuteNonQuery();
                con.Close();

                return rows > 0;
            }
        
        }


        // 🔥 Correct AssignTranscriber method
        public void AssignRecording(int recordingId)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
            INSERT INTO Transcriptions (RecordingId, Status, CreatedAt)
            VALUES (@rid, @status, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rid", recordingId);
                cmd.Parameters.AddWithValue("@status", "Assigned");

                cmd.ExecuteNonQuery();
            }
        }

    }
}
