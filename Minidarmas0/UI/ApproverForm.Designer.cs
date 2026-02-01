namespace MiniDARMAS.UI
{
    partial class ApproverForm
    {
        private System.Windows.Forms.ComboBox cmbMeetings;
        private System.Windows.Forms.RichTextBox rtbFinalText;
        private System.Windows.Forms.Button btnExportTxt;
        private System.Windows.Forms.Button btnExportRtf;
        private System.Windows.Forms.Button btnFinalApprove;
        private System.Windows.Forms.Button button1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApproverForm));
            this.cmbMeetings = new System.Windows.Forms.ComboBox();
            this.rtbFinalText = new System.Windows.Forms.RichTextBox();
            this.btnExportTxt = new System.Windows.Forms.Button();
            this.btnExportRtf = new System.Windows.Forms.Button();
            this.btnFinalApprove = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbMeetings
            // 
            this.cmbMeetings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMeetings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeetings.Location = new System.Drawing.Point(0, 520);
            this.cmbMeetings.Name = "cmbMeetings";
            this.cmbMeetings.Size = new System.Drawing.Size(1000, 33);
            this.cmbMeetings.TabIndex = 0;
            this.cmbMeetings.SelectedIndexChanged += new System.EventHandler(this.cmbMeetings_SelectedIndexChanged);
            // 
            // rtbFinalText
            // 
            this.rtbFinalText.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbFinalText.Location = new System.Drawing.Point(0, 0);
            this.rtbFinalText.Name = "rtbFinalText";
            this.rtbFinalText.ReadOnly = true;
            this.rtbFinalText.Size = new System.Drawing.Size(1000, 520);
            this.rtbFinalText.TabIndex = 2;
            this.rtbFinalText.Text = "";
            // 
            // btnExportTxt
            // 
            this.btnExportTxt.Location = new System.Drawing.Point(26, 578);
            this.btnExportTxt.Name = "btnExportTxt";
            this.btnExportTxt.Size = new System.Drawing.Size(150, 40);
            this.btnExportTxt.TabIndex = 3;
            this.btnExportTxt.Text = "Export .txt";
            this.btnExportTxt.Click += new System.EventHandler(this.btnExportTxt_Click_1);
            // 
            // btnExportRtf
            // 
            this.btnExportRtf.Location = new System.Drawing.Point(262, 578);
            this.btnExportRtf.Name = "btnExportRtf";
            this.btnExportRtf.Size = new System.Drawing.Size(150, 40);
            this.btnExportRtf.TabIndex = 4;
            this.btnExportRtf.Text = "Export .rtf";
            this.btnExportRtf.Click += new System.EventHandler(this.btnExportRtf_Click_1);
            // 
            // btnFinalApprove
            // 
            this.btnFinalApprove.Location = new System.Drawing.Point(544, 578);
            this.btnFinalApprove.Name = "btnFinalApprove";
            this.btnFinalApprove.Size = new System.Drawing.Size(191, 40);
            this.btnFinalApprove.TabIndex = 5;
            this.btnFinalApprove.Text = "Final Approve";
            this.btnFinalApprove.Click += new System.EventHandler(this.btnFinalApprove_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(828, 578);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Logout";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ApproverForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFinalApprove);
            this.Controls.Add(this.btnExportTxt);
            this.Controls.Add(this.btnExportRtf);
            this.Controls.Add(this.cmbMeetings);
            this.Controls.Add(this.rtbFinalText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ApproverForm";
            this.Text = "Mini-DARMAS-Approver";
            this.ResumeLayout(false);

        }
    }
}
