using MiniDARMAS.Logic;
using Minidarmas0.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniDARMAS.UI
{
    public partial class TranscriberForm : Form
    {
        private int selectedAssignmentId = 0;
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        public int userId;

        public TranscriberForm(int transcriberId)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            userId = transcriberId;
        }
        private void RefreshAssignedGrid()
        {
            dgvAssigned.DataSource = null;
            dgvAssigned.DataSource = assignmentBLL.GetAssignmentsByTranscriber(userId);
        }
        private void TranscriberForm_Load(object sender, EventArgs e)
        {
            LoadAssignedRecordings();
        }

        // Load assigned recordings for current transcriber
        private void LoadAssignedRecordings()
        {
            dgvAssigned.DataSource = assignmentBLL.GetAssignmentsByTranscriber(userId);
        }

        // When row clicked
        

        // Save Draft
        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            if (selectedAssignmentId == 0)
            {
                MessageBox.Show("Select an assignment first.");
                return;
            }

            assignmentBLL.SaveDraft(selectedAssignmentId, txtTranscript.Text);
            assignmentBLL.UpdateStatus(selectedAssignmentId, "Draft");
            MessageBox.Show("Draft saved successfully.");
        }

        // Submit to Editor
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (selectedAssignmentId == 0)
            {
                MessageBox.Show("Select an assignment first.");
                return;
            }

            assignmentBLL.SaveDraft(selectedAssignmentId, txtTranscript.Text);
            assignmentBLL.UpdateStatus(selectedAssignmentId, "Submitted");
            MessageBox.Show("Submitted to Editor.");
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AddLogoutButton();
        }

        private void AddLogoutButton()
        {
            if (Controls.Find("btnLogout", true).Length == 0)
            {
                Button btnLogout = new Button
                {
                    Name = "btnLogout",
                    Text = "Logout",
                    Size = new Size(80, 30),
                    Location = new Point(this.ClientSize.Width - 90, 10),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };

                btnLogout.Click += (s, e) =>
                {
                    LoginForm login = new LoginForm();
                    login.Show();
                    this.Close();
                };

                Controls.Add(btnLogout);
            }
        }

        private void dgvAssigned_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedAssignmentId = Convert.ToInt32(dgvAssigned.Rows[e.RowIndex].Cells["AssignmentId"].Value);

            txtAssignmentId.Text = selectedAssignmentId.ToString();

            // Load draft if exists
            string draft = assignmentBLL.GetTranscriptByAssignment(selectedAssignmentId);
            txtTranscript.Text = draft; // will be empty if no draft

            // Play audio
            string audioPath = dgvAssigned.Rows[e.RowIndex].Cells["AudioFilePath"].Value.ToString();
            axWindowsMediaPlayer1.URL = audioPath;
            axWindowsMediaPlayer1.Ctlcontrols.play();

            tabControl1.SelectedTab = tabTranscription;
        }

        private void btnSaveDraft_Click_1(object sender, EventArgs e)
        {
            if (selectedAssignmentId == 0)
            {
                MessageBox.Show("Select an assignment first.");
                return;
            }

            assignmentBLL.SaveTranscription(
                selectedAssignmentId,
                txtTranscript.Text,
                "Draft",
                ""  // <-- required comment parameter
            );
            RefreshAssignedGrid();
            MessageBox.Show("Draft saved successfully.");
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (selectedAssignmentId == 0)
            {
                MessageBox.Show("Select an assignment first.");
                return;
            }

            assignmentBLL.SubmitToEditor(selectedAssignmentId, txtTranscript.Text);

            MessageBox.Show("Submitted to Editor.");
            RefreshAssignedGrid();
            txtTranscript.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
