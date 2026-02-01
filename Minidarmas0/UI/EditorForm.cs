using MiniDARMAS.Logic;
using Minidarmas0.UI;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MiniDARMAS.UI
{
    public partial class EditorForm : Form
    {
        private int selectedAssignmentId = 0;
        private AssignmentBLL assignmentBLL = new AssignmentBLL();

        public EditorForm()
        {
            InitializeComponent();
            LoadSubmittedAssignments();
            this.WindowState = FormWindowState.Maximized;


            // Add event handler to DataGridView
            dgvSubmissions.CellClick += dgvSubmissions_CellClick;
        }

        // Load only SUBMITTED assignments
        private void LoadSubmittedAssignments()
        {
            DataTable dt = assignmentBLL.GetSubmittedAssignments();
            dgvSubmissions.DataSource = dt;
        }

        // When editor selects a row
        private void dgvSubmissions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Ignore header clicks
            if (e.RowIndex < 0) return;

            // 2. Get the selected row
            DataGridViewRow row = dgvSubmissions.Rows[e.RowIndex];

            // 3. Read AssignmentId safely
            if (row.Cells["AssignmentId"].Value == null ||
                !int.TryParse(row.Cells["AssignmentId"].Value.ToString(), out int id))
            {
                return;
            }

            selectedAssignmentId = id;

            // 4. Show transcript text
            txtTranscript.Text =
                row.Cells["TranscriptText"].Value?.ToString() ?? "";

            // 5. Show comments
            txtComments.Text =
                row.Cells["Comment"].Value?.ToString() ?? "";
        }



        // Approve
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (selectedAssignmentId == 0)
            {
                MessageBox.Show("Select an assignment first.");
                return;
            }

            assignmentBLL.SaveTranscription(
                selectedAssignmentId,
                txtTranscript.Text,
                "Approved",
                txtComments.Text
            );

            assignmentBLL.UpdateStatus(selectedAssignmentId, "Approved");

            MessageBox.Show("Approved successfully.");

            ClearEditor();
            LoadSubmittedAssignments();
        }

        // Return (Reject)
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (selectedAssignmentId == 0)
            {
                MessageBox.Show("Select an assignment first.");
                return;
            }

            assignmentBLL.SaveTranscription(
                selectedAssignmentId,
                txtTranscript.Text,
                "Rejected",
                txtComments.Text
            );

            assignmentBLL.UpdateStatus(selectedAssignmentId, "Rejected");

            MessageBox.Show("Returned to transcriber.");

            ClearEditor();
            LoadSubmittedAssignments();
        }

        // Clear fields
        private void ClearEditor()
        {
            selectedAssignmentId = 0;
            txtTranscript.Clear();
            txtComments.Clear();
        }

        // Logout button
        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
