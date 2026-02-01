using MiniDARMAS.Logic;
using Minidarmas0.UI;
using System;
using System.Data;
using System.Windows.Forms;

namespace MiniDARMAS.UI
{
    public partial class ApproverForm : Form
    {
        MeetingBLL meetingBLL = new MeetingBLL();

        int selectedMeetingId = 0;

        public ApproverForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            LoadMeetings();
        }

        private void LoadMeetings()
        {
            var dt = meetingBLL.GetMeetings();

            cmbMeetings.DataSource = dt;
            cmbMeetings.DisplayMember = "MeetingNo";
            cmbMeetings.ValueMember = "MeetingId";

            cmbMeetings.SelectedIndex = -1;
            rtbFinalText.Text = "";
        }

        private void cmbMeetings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMeetings.SelectedIndex == -1) return;

            DataRowView drv = cmbMeetings.SelectedItem as DataRowView;
            if (drv == null) return;

            selectedMeetingId = Convert.ToInt32(drv["MeetingId"]);

            // This will show the approved transcript
            rtbFinalText.Text = meetingBLL.GetApprovedTranscriptsByMeeting(selectedMeetingId);
        }


        private void btnFinalApprove_Click_1(object sender, EventArgs e)
        {
            if (selectedMeetingId == 0)
            {
                MessageBox.Show("Select a meeting first.");
                return;
            }

            if (meetingBLL.IsMeetingAlreadyFinalApproved(selectedMeetingId))
            {
                MessageBox.Show("This meeting is already Final Approved.");
                return;
            }

            bool result = meetingBLL.MarkMeetingFinalApproved(selectedMeetingId);

            if (result)
            {
                MessageBox.Show("Meeting final approved.");

                // reload meeting list so already approved meeting is removed
                LoadMeetings();
            }
            else
            {
                MessageBox.Show("Approval failed. Ensure the meeting has approved transcripts.");
            }
        }

        // ------------------ MISSING METHODS ADDED BELOW ------------------

        private void btnExportTxt_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt";
            sfd.FileName = "FinalApprovedMeeting.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sfd.FileName, rtbFinalText.Text);
                MessageBox.Show("Text Exported Successfully.");
            }
        }

        private void btnExportRtf_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "RTF Files (*.rtf)|*.rtf";
            sfd.FileName = "FinalApprovedMeeting.rtf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                rtbFinalText.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                MessageBox.Show("RTF Exported Successfully.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
