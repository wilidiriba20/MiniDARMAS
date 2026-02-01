using MiniDARMAS.Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minidarmas0.UI
{
    public partial class OperatorForm : Form
    {
        MeetingBLL meetingBLL = new MeetingBLL();
        AgendaBLL agendaBLL = new AgendaBLL();
        RecordingBLL recordingBLL = new RecordingBLL();
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        UserBLL userBLL = new UserBLL();

        int selectedMeetingId = 0;
        int selectedAgendaId = 0;
        int selectedRecordingId = 0;
        int selectedAssignmentId = 0;

        private int operatorId;
        public OperatorForm(int userId)
        {
            InitializeComponent();
            operatorId = userId;
            this.WindowState = FormWindowState.Maximized;


            LoadMeetings();
            LoadTranscribers();
        }

        // -------------------------
        // Load Data
        // -------------------------
        private void LoadMeetings()
        {
            dgvMeetings.DataSource = meetingBLL.GetMeetings();
        }

        private void LoadAgendas(int meetingId)
        {
            dgvAgendas.DataSource = agendaBLL.GetAgendasByMeeting(meetingId);
        }

        private void LoadRecordings(int agendaId)
        {
            dgvRecordings.DataSource = recordingBLL.GetRecordingsByAgenda(agendaId);
        }

        private void LoadAssignments(int recordingId)
        {
            dgvAssignments.DataSource = assignmentBLL.GetAssignmentsByRecording(recordingId);
        }

        private void LoadTranscribers()
        {
            cmbTranscriber.Items.Clear();

            var transcribers = userBLL.GetUsersByRole("Transcriber");

            foreach (var t in transcribers)
            {
                cmbTranscriber.Items.Add(new ComboboxItem
                {
                    Text = t.FullName,
                    Value = t.UserId
                });
            }
        }

       

       

        private void dgvAssignments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAssignments.CurrentRow == null) return;

            var cellValue = dgvAssignments.CurrentRow.Cells["AssignmentId"].Value;

            // If cell is empty or null, ignore
            if (cellValue == null || cellValue == DBNull.Value)
            {
                selectedAssignmentId = 0;
                return;
            }

            selectedAssignmentId = Convert.ToInt32(cellValue);

        }

        // -------------------------
        // Meeting Buttons
        // -------------------------
        private void btnAddMeeting_Click(object sender, EventArgs e)
        {

            bool isAdded = meetingBLL.AddMeeting(
        txtMeetingNo.Text,
        dtpMeetingDate.Value,
        txtLocation.Text,
        txtChairperson.Text
    );

            if (isAdded)
            {
                MessageBox.Show("Meeting added successfully!");
                LoadMeetings();
                ClearMeetingFields();
            }
        }
        private void btnEditMeeting_Click(object sender, EventArgs e)
        {
            if (selectedMeetingId == 0)
            {
                MessageBox.Show("Select a meeting first.");
                return;
            }

            bool updated = meetingBLL.UpdateMeeting(
                selectedMeetingId,
                txtMeetingNo.Text,
                dtpMeetingDate.Value,
                txtLocation.Text,
                txtChairperson.Text
            );

            if (updated)
            {
                MessageBox.Show("Meeting updated successfully!");
                LoadMeetings();
            }
        }
        private void btnDeleteMeeting_Click(object sender, EventArgs e)
        {
            if (selectedMeetingId == 0)
            {
                MessageBox.Show("Select a meeting first.");
                return;
            }

            bool deleted = meetingBLL.DeleteMeeting(selectedMeetingId);

            if (deleted)
            {
                MessageBox.Show("Meeting deleted successfully!");
                LoadMeetings();
                ClearMeetingFields();
            }
        }


        // -------------------------
        // Agenda Buttons
        // -------------------------
        private void btnAddAgenda_Click(object sender, EventArgs e)
        {
            if (selectedMeetingId == 0)
            {
                MessageBox.Show("Select a meeting first.");
                return;
            }


            agendaBLL.AddAgenda(selectedMeetingId, txtAgendaTitle.Text, txtOffice.Text, txtDoc.Text);
            LoadAgendas(selectedMeetingId);

        }

        private void btnUpdateAgenda_Click(object sender, EventArgs e)
        {
            if (selectedAgendaId == 0)
            {
                MessageBox.Show("Select an agenda first.");
                return;
            }

            agendaBLL.UpdateAgenda(selectedAgendaId, selectedMeetingId, txtAgendaTitle.Text, txtOffice.Text, txtDoc.Text);
            LoadAgendas(selectedMeetingId);
            MessageBox.Show("Agenda updated!");

        }

        private void btnDeleteAgenda_Click(object sender, EventArgs e)
        {

            if (selectedAgendaId == 0)
            {
                MessageBox.Show("Select an agenda first.");
                return;
            }

            agendaBLL.DeleteAgenda(selectedAgendaId);
            LoadAgendas(selectedMeetingId);
            ClearAgendaFields();



        }

        // -------------------------
        // Recording Buttons
        // -------------------------
        private void btnBrowseAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Audio Files|*.mp3;*.wav;*.m4a";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtAudioPath.Text = ofd.FileName;
            }
        }

        private void btnAddRecording_Click(object sender, EventArgs e)
        {
            if (selectedAgendaId == 0)
            {
                MessageBox.Show("Select an agenda first.");
                return;
            }

            recordingBLL.AddRecording(selectedAgendaId, txtAudioPath.Text);
            LoadRecordings(selectedAgendaId);
            txtAudioPath.Clear();
        }

        private void btnDeleteRecording_Click(object sender, EventArgs e)
        {
            if (selectedRecordingId == 0)
            {
                MessageBox.Show("Select a recording first.");
                return;
            }

            recordingBLL.DeleteRecording(selectedRecordingId);
            LoadRecordings(selectedAgendaId);
        }

        // -------------------------
        // Assignment Buttons
        // -------------------------
        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (selectedRecordingId == 0)
            {
                MessageBox.Show("Select a recording first.");
                return;
            }

            if (cmbTranscriber.SelectedItem == null)
            {
                MessageBox.Show("Select a transcriber.");
                return;
            }

            var item = (ComboboxItem)cmbTranscriber.SelectedItem;
            int transcriberId = (int)item.Value;

            assignmentBLL.AssignRecording(selectedRecordingId, transcriberId);
            LoadAssignments(selectedRecordingId);
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (selectedAssignmentId == 0)
            {
                MessageBox.Show("Select an assignment first.");
                return;
            }

            assignmentBLL.UpdateStatus(selectedAssignmentId, cmbStatus.Text);
            LoadAssignments(selectedRecordingId);
        }

        // -------------------------
        // Clear Fields
        // -------------------------
        private void ClearMeetingFields()
        {
            txtMeetingNo.Clear();
            txtLocation.Clear();
            txtChairperson.Clear();
        }

        private void ClearAgendaFields()
        {
            txtAgendaTitle.Clear();
            txtOffice.Clear();
            txtDoc.Clear();
        }

        // =========================
        // LOGOUT CODE INSIDE CLASS
        // =========================
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

        

        private void dgvMeetings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMeetings.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgvMeetings.SelectedRows[0];

            if (row.Cells["MeetingId"].Value == null || row.Cells["MeetingId"].Value == DBNull.Value)
                return;

            selectedMeetingId = Convert.ToInt32(row.Cells["MeetingId"].Value);

            // CHANGE THIS if your column names are different
            txtMeetingNo.Text = row.Cells["MeetingNo"].Value?.ToString();
            txtLocation.Text = row.Cells["Location"].Value?.ToString();
            txtChairperson.Text = row.Cells["Chairperson"].Value?.ToString();

            var dateValue = row.Cells["MeetingDate"].Value;
            if (dateValue != null && dateValue != DBNull.Value)
                dtpMeetingDate.Value = Convert.ToDateTime(dateValue);


        }

        private void dgvMeetings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var meetingIdValue = dgvMeetings.Rows[e.RowIndex].Cells["MeetingId"].Value;

            // If meetingId is null or empty, do nothing
            if (meetingIdValue == null || meetingIdValue == DBNull.Value || string.IsNullOrEmpty(meetingIdValue.ToString()))
                return;

            selectedMeetingId = Convert.ToInt32(meetingIdValue);

            LoadAgendas(selectedMeetingId);
            tabControl1.SelectedTab = tabAgenda;
        }

        private void btnAddAgenda_Click_1(object sender, EventArgs e)
        {
            if (selectedMeetingId == 0)
            {
                MessageBox.Show("Select a meeting first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            agendaBLL.AddAgenda(selectedMeetingId, txtAgendaTitle.Text, txtOffice.Text, txtDoc.Text);
            LoadAgendas(selectedMeetingId);
            ClearAgendaFields();
        }

        private void dgvAgendas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAgendas.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgvAgendas.SelectedRows[0];

            if (row.Cells["AgendaId"].Value == null || row.Cells["AgendaId"].Value == DBNull.Value)
                return;

            selectedAgendaId = Convert.ToInt32(row.Cells["AgendaId"].Value);

            txtAgendaTitle.Text = row.Cells["AgendaTitle"].Value?.ToString();   // <-- fix column name
            txtOffice.Text = row.Cells["Office"].Value?.ToString();
            txtDoc.Text = row.Cells["SupportingDocument"].Value?.ToString();

        }

       

        private void btnEditAgenda_Click(object sender, EventArgs e)
        {
            if (selectedAgendaId == 0)
            {
                MessageBox.Show("Select an agenda first.");
                return;
            }

            agendaBLL.UpdateAgenda(selectedAgendaId, selectedMeetingId, txtAgendaTitle.Text, txtOffice.Text, txtDoc.Text);
            LoadAgendas(selectedMeetingId);
            MessageBox.Show("Agenda updated!");

        }

        private void btnDeleteAgenda_Click_1(object sender, EventArgs e)
        {

            if (selectedAgendaId == 0)
            {
                MessageBox.Show("Select an agenda first.");
                return;
            }

            agendaBLL.DeleteAgenda(selectedAgendaId);
            LoadAgendas(selectedMeetingId);
            ClearAgendaFields();


        }

        private void dgvAgendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (selectedAgendaId == 0)
            {
                MessageBox.Show("Select an agenda first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadRecordings(selectedAgendaId);
            tabControl1.SelectedTab = tabRecordings;
        }

        private void btnBrowseAudio_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Audio Files|*.mp3;*.wav;*.m4a";
            ofd.Title = "Select Audio File";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtAudioPath.Text = ofd.FileName;
            }
        }

        private void btnAddRecording_Click_1(object sender, EventArgs e)
        {
            // 1. Check if agenda is selected
            if (selectedAgendaId == 0)
            {
                MessageBox.Show("Select an agenda first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Check if audio file path is selected
            if (string.IsNullOrEmpty(txtAudioPath.Text))
            {
                MessageBox.Show("Please browse and select an audio file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Add recording
            recordingBLL.AddRecording(selectedAgendaId, txtAudioPath.Text);

            // 4. Refresh grid
            LoadRecordings(selectedAgendaId);

            // 5. Clear textbox
            txtAudioPath.Clear();

            MessageBox.Show("Recording added successfully!");
        }

        private void dgvRecordings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var recordingIdValue = dgvRecordings.Rows[e.RowIndex].Cells["RecordingId"].Value;

            if (recordingIdValue == null || recordingIdValue == DBNull.Value)
                return;

            selectedRecordingId = Convert.ToInt32(recordingIdValue);

            // Load assignments for that recording
            LoadAssignments(selectedRecordingId);

            // Go to Assignment tab
            tabControl1.SelectedTab = tabAssignments;
        }

        private void btnDeleteRecording_Click_1(object sender, EventArgs e)
        {
            if (selectedRecordingId == 0)
            {
                MessageBox.Show("Select a recording first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this recording?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool deleted = recordingBLL.DeleteRecording(selectedRecordingId);

                if (deleted)
                {
                    MessageBox.Show("Recording deleted successfully!");
                    LoadRecordings(selectedAgendaId);
                }
                else
                {
                    MessageBox.Show("Failed to delete recording.");
                }
            }
        }

        private void dgvRecordings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecordings.SelectedRows.Count == 0)
            {
                selectedRecordingId = 0;
                return;
            }

            var row = dgvRecordings.SelectedRows[0];
            var idValue = row.Cells["RecordingId"].Value;

            if (idValue == null || idValue == DBNull.Value)
            {
                selectedRecordingId = 0;
                return;
            }

            selectedRecordingId = Convert.ToInt32(idValue);
        }

    // ComboboxItem must be OUTSIDE the form class
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString() => Text;
    }

        private void btnAssign_Click_1(object sender, EventArgs e)
        {
            if (selectedRecordingId == 0)
            {
                MessageBox.Show("Select a recording first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTranscriber.SelectedItem == null)
            {
                MessageBox.Show("Select a transcriber.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var item = (ComboboxItem)cmbTranscriber.SelectedItem;
            int transcriberId = (int)item.Value;

            bool result = assignmentBLL.AssignRecording(selectedRecordingId, transcriberId);

            if (result)
            {
                MessageBox.Show("Recording assigned successfully!");
                LoadAssignments(selectedRecordingId);
            }
            else
            {
                MessageBox.Show("Failed to assign recording.");
            }
        }

        private void btnUpdateStatus_Click_1(object sender, EventArgs e)
        {
            if (selectedAssignmentId == 0)
            {
                MessageBox.Show("Select an assignment first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Select a status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool updated = assignmentBLL.UpdateStatus(selectedAssignmentId, cmbStatus.Text);

            if (updated)
            {
                MessageBox.Show("Status updated successfully!");
                LoadAssignments(selectedRecordingId);
            }
            else
            {
                MessageBox.Show("Status update failed!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            // Clear agenda textboxes
            txtAgendaTitle.Clear();
            txtOffice.Clear();
            txtDoc.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtMeetingNo.Clear();
            txtLocation.Clear();
            txtChairperson.Clear();
        }

        private void dgvMeetings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvMeetings.Rows[e.RowIndex];

            // ---------- CHECK MeetingId ----------
            var meetingIdObj = row.Cells["MeetingId"].Value;
            if (meetingIdObj == null || meetingIdObj == DBNull.Value)
            {
                selectedMeetingId = 0;
                return;
            }
            selectedMeetingId = Convert.ToInt32(meetingIdObj);

            // ---------- SET TEXTBOX VALUES ----------
            txtMeetingNo.Text = row.Cells["MeetingNo"].Value?.ToString();
            txtLocation.Text = row.Cells["Location"].Value?.ToString();
            txtChairperson.Text = row.Cells["Chairperson"].Value?.ToString();

            // ---------- CHECK MeetingDate ----------
            var dateObj = row.Cells["MeetingDate"].Value;
            if (dateObj != null && dateObj != DBNull.Value)
                dtpMeetingDate.Value = Convert.ToDateTime(dateObj);

            
        }

        private void dgvAgendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvAgendas.Rows[e.RowIndex];

            // ----- CHECK AgendaId -----
            var agendaIdObj = row.Cells["AgendaId"].Value;
            if (agendaIdObj == null || agendaIdObj == DBNull.Value)
            {
                selectedAgendaId = 0;
                return;
            }
            selectedAgendaId = Convert.ToInt32(agendaIdObj);

            // ----- FILL TEXTBOXES -----
            txtAgendaTitle.Text = row.Cells["AgendaTitle"].Value?.ToString();
            txtOffice.Text = row.Cells["Office"].Value?.ToString();
            txtDoc.Text = row.Cells["SupportingDocument"].Value?.ToString();

            
        }

        private void dgvRecordings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvRecordings.Rows[e.RowIndex];

            // ----- SAFE CHECK for RecordingId -----
            var recordingIdObj = row.Cells["RecordingId"].Value;
            if (recordingIdObj == null || recordingIdObj == DBNull.Value)
            {
                selectedRecordingId = 0;
                return;
            }
            selectedRecordingId = Convert.ToInt32(recordingIdObj);

            // ----- SAFE CHECK for AudioFilePath -----
            var audioPathObj = row.Cells["AudioFilePath"].Value;
            txtAudioPath.Text = (audioPathObj == null || audioPathObj == DBNull.Value)
                ? ""
                : audioPathObj.ToString();

            // Load assignments for selected recording automatically
            //LoadAssignments(selectedRecordingId);
        }

     


    }
}
