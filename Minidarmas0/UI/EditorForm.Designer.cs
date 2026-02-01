using System.Windows.Forms;

namespace MiniDARMAS.UI
{
    partial class EditorForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvSubmissions;

        private System.Windows.Forms.Label lblTranscript;
        private System.Windows.Forms.TextBox txtTranscript;

        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.TextBox txtComments;

        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReturn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.dgvSubmissions = new System.Windows.Forms.DataGridView();
            this.lblTranscript = new System.Windows.Forms.Label();
            this.txtTranscript = new System.Windows.Forms.TextBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubmissions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSubmissions
            // 
            this.dgvSubmissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubmissions.ColumnHeadersHeight = 46;
            this.dgvSubmissions.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSubmissions.Location = new System.Drawing.Point(0, 0);
            this.dgvSubmissions.Name = "dgvSubmissions";
            this.dgvSubmissions.ReadOnly = true;
            this.dgvSubmissions.RowHeadersWidth = 82;
            this.dgvSubmissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubmissions.Size = new System.Drawing.Size(965, 171);
            this.dgvSubmissions.TabIndex = 0;
            // 
            // lblTranscript
            // 
            this.lblTranscript.Location = new System.Drawing.Point(2, 174);
            this.lblTranscript.Name = "lblTranscript";
            this.lblTranscript.Size = new System.Drawing.Size(136, 25);
            this.lblTranscript.TabIndex = 3;
            this.lblTranscript.Text = "Transcript";
            // 
            // txtTranscript
            // 
            this.txtTranscript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTranscript.Location = new System.Drawing.Point(0, 194);
            this.txtTranscript.Multiline = true;
            this.txtTranscript.Name = "txtTranscript";
            this.txtTranscript.Size = new System.Drawing.Size(965, 172);
            this.txtTranscript.TabIndex = 4;
            // 
            // lblComments
            // 
            this.lblComments.Location = new System.Drawing.Point(2, 369);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(114, 23);
            this.lblComments.TabIndex = 5;
            this.lblComments.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(0, 395);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(950, 148);
            this.txtComments.TabIndex = 6;
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(59, 580);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(150, 40);
            this.btnApprove.TabIndex = 7;
            this.btnApprove.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(332, 580);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(150, 40);
            this.btnReturn.TabIndex = 8;
            this.btnReturn.Text = "Return";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(649, 580);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Logout";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditorForm
            // 
            this.ClientSize = new System.Drawing.Size(965, 646);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvSubmissions);
            this.Controls.Add(this.lblTranscript);
            this.Controls.Add(this.txtTranscript);
            this.Controls.Add(this.lblComments);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnReturn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditorForm";
            this.Text = "Mini-DARMAS-Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubmissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button button1;
    }
}
