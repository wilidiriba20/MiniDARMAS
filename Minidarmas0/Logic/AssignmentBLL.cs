using MiniDARMAS.Data;
using System.Data;

namespace MiniDARMAS.Logic
{
    public class AssignmentBLL
    {
        private AssignmentDAL dal = new AssignmentDAL();

        public DataTable GetAssignmentsByRecording(int recordingId)
        {
            return dal.GetAssignmentsByRecording(recordingId);
        }

        public bool AssignRecording(int recordingId, int transcriberId)
        {
            return dal.AssignRecording(recordingId, transcriberId);
        }

        public bool UpdateStatus(int assignmentId, string status)
        {
            return dal.UpdateStatus(assignmentId, status);
        }

        public DataTable GetAssignmentsByTranscriber(int transcriberId)
        {
            return dal.GetAssignmentsByTranscriber(transcriberId);
        }

        public bool SaveDraft(int assignmentId, string transcriptText)
        {
            return dal.SaveTranscription(assignmentId, transcriptText, "Draft", "");
        }

        public bool SubmitToEditor(int assignmentId, string transcriptText)
        {
            return SaveTranscription(assignmentId, transcriptText, "Submitted", "");
        }


        public bool SaveTranscription(int assignmentId, string transcriptText, string status, string comment)
        {
            return dal.SaveTranscription(assignmentId, transcriptText, status, comment);
        }

        public DataTable GetSubmittedAssignments()
        {
            return dal.GetSubmittedAssignments();
        }

        public string GetTranscriptByAssignment(int assignmentId)
        {
            return dal.GetTranscriptByAssignment(assignmentId);
        }
    }
}
