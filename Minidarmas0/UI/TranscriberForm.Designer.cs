using System.Windows.Forms;
using System.Drawing;


namespace MiniDARMAS.UI
{
    partial class TranscriberForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAssigned;
        private System.Windows.Forms.TabPage tabTranscription;

        private System.Windows.Forms.DataGridView dgvAssigned;

        private System.Windows.Forms.Label lblAssignmentId;
        private System.Windows.Forms.TextBox txtAssignmentId;
        private System.Windows.Forms.TextBox txtTranscript;

        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnSubmit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranscriberForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAssigned = new System.Windows.Forms.TabPage();
            this.dgvAssigned = new System.Windows.Forms.DataGridView();
            this.tabTranscription = new System.Windows.Forms.TabPage();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.lblAssignmentId = new System.Windows.Forms.Label();
            this.txtAssignmentId = new System.Windows.Forms.TextBox();
            this.txtTranscript = new System.Windows.Forms.TextBox();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabAssigned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssigned)).BeginInit();
            this.tabTranscription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAssigned);
            this.tabControl1.Controls.Add(this.tabTranscription);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 644);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAssigned
            // 
            this.tabAssigned.Controls.Add(this.dgvAssigned);
            this.tabAssigned.Location = new System.Drawing.Point(8, 39);
            this.tabAssigned.Name = "tabAssigned";
            this.tabAssigned.Size = new System.Drawing.Size(984, 597);
            this.tabAssigned.TabIndex = 0;
            this.tabAssigned.Text = "Assigned Recordings";
            // 
            // dgvAssigned
            // 
            this.dgvAssigned.AllowUserToAddRows = false;
            this.dgvAssigned.AllowUserToDeleteRows = false;
            this.dgvAssigned.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssigned.ColumnHeadersHeight = 46;
            this.dgvAssigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssigned.Location = new System.Drawing.Point(0, 0);
            this.dgvAssigned.MultiSelect = false;
            this.dgvAssigned.Name = "dgvAssigned";
            this.dgvAssigned.ReadOnly = true;
            this.dgvAssigned.RowHeadersWidth = 82;
            this.dgvAssigned.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssigned.Size = new System.Drawing.Size(984, 597);
            this.dgvAssigned.TabIndex = 0;
            this.dgvAssigned.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssigned_CellClick_1);
            // 
            // tabTranscription
            // 
            this.tabTranscription.Controls.Add(this.button1);
            this.tabTranscription.Controls.Add(this.axWindowsMediaPlayer1);
            this.tabTranscription.Controls.Add(this.lblAssignmentId);
            this.tabTranscription.Controls.Add(this.txtAssignmentId);
            this.tabTranscription.Controls.Add(this.txtTranscript);
            this.tabTranscription.Controls.Add(this.btnSaveDraft);
            this.tabTranscription.Controls.Add(this.btnSubmit);
            this.tabTranscription.Location = new System.Drawing.Point(8, 39);
            this.tabTranscription.Name = "tabTranscription";
            this.tabTranscription.Size = new System.Drawing.Size(984, 597);
            this.tabTranscription.TabIndex = 1;
            this.tabTranscription.Text = "Transcription";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(439, 484);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(473, 52);
            this.axWindowsMediaPlayer1.TabIndex = 6;
            // 
            // lblAssignmentId
            // 
            this.lblAssignmentId.Location = new System.Drawing.Point(3, 487);
            this.lblAssignmentId.Name = "lblAssignmentId";
            this.lblAssignmentId.Size = new System.Drawing.Size(151, 30);
            this.lblAssignmentId.TabIndex = 0;
            this.lblAssignmentId.Text = "Assignment ID";
            // 
            // txtAssignmentId
            // 
            this.txtAssignmentId.Location = new System.Drawing.Point(199, 484);
            this.txtAssignmentId.Name = "txtAssignmentId";
            this.txtAssignmentId.ReadOnly = true;
            this.txtAssignmentId.Size = new System.Drawing.Size(200, 31);
            this.txtAssignmentId.TabIndex = 1;
            // 
            // txtTranscript
            // 
            this.txtTranscript.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTranscript.Location = new System.Drawing.Point(0, 0);
            this.txtTranscript.Multiline = true;
            this.txtTranscript.Name = "txtTranscript";
            this.txtTranscript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTranscript.Size = new System.Drawing.Size(984, 478);
            this.txtTranscript.TabIndex = 3;
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.Location = new System.Drawing.Point(41, 542);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(236, 40);
            this.btnSaveDraft.TabIndex = 4;
            this.btnSaveDraft.Text = "Save Draft";
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSaveDraft_Click_1);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(318, 542);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(225, 40);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit to Editor";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(635, 542);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TranscriberForm
            // 
            this.ClientSize = new System.Drawing.Size(1024, 657);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TranscriberForm";
            this.Text = "Mini-DARMAS-Transcriber";
            this.Load += new System.EventHandler(this.TranscriberForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAssigned.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssigned)).EndInit();
            this.tabTranscription.ResumeLayout(false);
            this.tabTranscription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Button button1;
    }
}
