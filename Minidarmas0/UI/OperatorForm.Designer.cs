namespace Minidarmas0.UI
{
    partial class OperatorForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMeetings = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMeetings = new System.Windows.Forms.DataGridView();
            this.txtMeetingNo = new System.Windows.Forms.TextBox();
            this.dtpMeetingDate = new System.Windows.Forms.DateTimePicker();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtChairperson = new System.Windows.Forms.TextBox();
            this.btnAddMeeting = new System.Windows.Forms.Button();
            this.btnEditMeeting = new System.Windows.Forms.Button();
            this.btnDeleteMeeting = new System.Windows.Forms.Button();
            this.tabAgenda = new System.Windows.Forms.TabPage();
            this.Clear = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvAgendas = new System.Windows.Forms.DataGridView();
            this.txtAgendaTitle = new System.Windows.Forms.TextBox();
            this.txtOffice = new System.Windows.Forms.TextBox();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.btnAddAgenda = new System.Windows.Forms.Button();
            this.btnEditAgenda = new System.Windows.Forms.Button();
            this.btnDeleteAgenda = new System.Windows.Forms.Button();
            this.tabRecordings = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvRecordings = new System.Windows.Forms.DataGridView();
            this.txtAudioPath = new System.Windows.Forms.TextBox();
            this.btnBrowseAudio = new System.Windows.Forms.Button();
            this.btnAddRecording = new System.Windows.Forms.Button();
            this.btnDeleteRecording = new System.Windows.Forms.Button();
            this.tabAssignments = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.cmbTranscriber = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabMeetings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetings)).BeginInit();
            this.tabAgenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgendas)).BeginInit();
            this.tabRecordings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordings)).BeginInit();
            this.tabAssignments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMeetings);
            this.tabControl1.Controls.Add(this.tabAgenda);
            this.tabControl1.Controls.Add(this.tabRecordings);
            this.tabControl1.Controls.Add(this.tabAssignments);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1150, 611);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMeetings
            // 
            this.tabMeetings.Controls.Add(this.button5);
            this.tabMeetings.Controls.Add(this.button4);
            this.tabMeetings.Controls.Add(this.label4);
            this.tabMeetings.Controls.Add(this.label3);
            this.tabMeetings.Controls.Add(this.label2);
            this.tabMeetings.Controls.Add(this.label1);
            this.tabMeetings.Controls.Add(this.dgvMeetings);
            this.tabMeetings.Controls.Add(this.txtMeetingNo);
            this.tabMeetings.Controls.Add(this.dtpMeetingDate);
            this.tabMeetings.Controls.Add(this.txtLocation);
            this.tabMeetings.Controls.Add(this.txtChairperson);
            this.tabMeetings.Controls.Add(this.btnAddMeeting);
            this.tabMeetings.Controls.Add(this.btnEditMeeting);
            this.tabMeetings.Controls.Add(this.btnDeleteMeeting);
            this.tabMeetings.Location = new System.Drawing.Point(8, 39);
            this.tabMeetings.Name = "tabMeetings";
            this.tabMeetings.Size = new System.Drawing.Size(1134, 564);
            this.tabMeetings.TabIndex = 0;
            this.tabMeetings.Text = "Meetings";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(871, 463);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 42);
            this.button5.TabIndex = 14;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(871, 511);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 42);
            this.button4.TabIndex = 13;
            this.button4.Text = "Logout";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 517);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Meeting Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 467);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Chairperson";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Location";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Meeting Number";
            // 
            // dgvMeetings
            // 
            this.dgvMeetings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMeetings.ColumnHeadersHeight = 46;
            this.dgvMeetings.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMeetings.Location = new System.Drawing.Point(0, 0);
            this.dgvMeetings.Name = "dgvMeetings";
            this.dgvMeetings.RowHeadersWidth = 82;
            this.dgvMeetings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeetings.Size = new System.Drawing.Size(1134, 312);
            this.dgvMeetings.TabIndex = 12;
            this.dgvMeetings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeetings_CellClick);
            this.dgvMeetings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeetings_CellDoubleClick);
            this.dgvMeetings.SelectionChanged += new System.EventHandler(this.dgvMeetings_SelectionChanged);
            // 
            // txtMeetingNo
            // 
            this.txtMeetingNo.Location = new System.Drawing.Point(261, 367);
            this.txtMeetingNo.Name = "txtMeetingNo";
            this.txtMeetingNo.Size = new System.Drawing.Size(511, 31);
            this.txtMeetingNo.TabIndex = 1;
            // 
            // dtpMeetingDate
            // 
            this.dtpMeetingDate.Location = new System.Drawing.Point(258, 511);
            this.dtpMeetingDate.Name = "dtpMeetingDate";
            this.dtpMeetingDate.Size = new System.Drawing.Size(514, 31);
            this.dtpMeetingDate.TabIndex = 2;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(258, 414);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(514, 31);
            this.txtLocation.TabIndex = 3;
            // 
            // txtChairperson
            // 
            this.txtChairperson.Location = new System.Drawing.Point(258, 461);
            this.txtChairperson.Name = "txtChairperson";
            this.txtChairperson.Size = new System.Drawing.Size(514, 31);
            this.txtChairperson.TabIndex = 4;
            // 
            // btnAddMeeting
            // 
            this.btnAddMeeting.Location = new System.Drawing.Point(871, 318);
            this.btnAddMeeting.Name = "btnAddMeeting";
            this.btnAddMeeting.Size = new System.Drawing.Size(141, 40);
            this.btnAddMeeting.TabIndex = 5;
            this.btnAddMeeting.Text = "Add";
            this.btnAddMeeting.Click += new System.EventHandler(this.btnAddMeeting_Click);
            // 
            // btnEditMeeting
            // 
            this.btnEditMeeting.Location = new System.Drawing.Point(871, 360);
            this.btnEditMeeting.Name = "btnEditMeeting";
            this.btnEditMeeting.Size = new System.Drawing.Size(141, 44);
            this.btnEditMeeting.TabIndex = 6;
            this.btnEditMeeting.Text = "Edit";
            this.btnEditMeeting.Click += new System.EventHandler(this.btnEditMeeting_Click);
            // 
            // btnDeleteMeeting
            // 
            this.btnDeleteMeeting.Location = new System.Drawing.Point(871, 414);
            this.btnDeleteMeeting.Name = "btnDeleteMeeting";
            this.btnDeleteMeeting.Size = new System.Drawing.Size(141, 43);
            this.btnDeleteMeeting.TabIndex = 7;
            this.btnDeleteMeeting.Text = "Delete";
            this.btnDeleteMeeting.Click += new System.EventHandler(this.btnDeleteMeeting_Click);
            // 
            // tabAgenda
            // 
            this.tabAgenda.Controls.Add(this.Clear);
            this.tabAgenda.Controls.Add(this.button3);
            this.tabAgenda.Controls.Add(this.label7);
            this.tabAgenda.Controls.Add(this.label6);
            this.tabAgenda.Controls.Add(this.label5);
            this.tabAgenda.Controls.Add(this.dgvAgendas);
            this.tabAgenda.Controls.Add(this.txtAgendaTitle);
            this.tabAgenda.Controls.Add(this.txtOffice);
            this.tabAgenda.Controls.Add(this.txtDoc);
            this.tabAgenda.Controls.Add(this.btnAddAgenda);
            this.tabAgenda.Controls.Add(this.btnEditAgenda);
            this.tabAgenda.Controls.Add(this.btnDeleteAgenda);
            this.tabAgenda.Location = new System.Drawing.Point(8, 39);
            this.tabAgenda.Name = "tabAgenda";
            this.tabAgenda.Size = new System.Drawing.Size(1134, 564);
            this.tabAgenda.TabIndex = 1;
            this.tabAgenda.Text = "Agenda";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(913, 459);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(134, 39);
            this.Clear.TabIndex = 12;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(913, 508);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 42);
            this.button3.TabIndex = 11;
            this.button3.Text = "Logout";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 508);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "Document File";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 459);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Office";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Agenda Title";
            // 
            // dgvAgendas
            // 
            this.dgvAgendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgendas.ColumnHeadersHeight = 46;
            this.dgvAgendas.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvAgendas.Location = new System.Drawing.Point(0, 0);
            this.dgvAgendas.MultiSelect = false;
            this.dgvAgendas.Name = "dgvAgendas";
            this.dgvAgendas.RowHeadersWidth = 82;
            this.dgvAgendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgendas.Size = new System.Drawing.Size(1134, 311);
            this.dgvAgendas.TabIndex = 10;
            this.dgvAgendas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgendas_CellClick);
            this.dgvAgendas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgendas_CellDoubleClick);
            this.dgvAgendas.SelectionChanged += new System.EventHandler(this.dgvAgendas_SelectionChanged);
            // 
            // txtAgendaTitle
            // 
            this.txtAgendaTitle.Location = new System.Drawing.Point(279, 397);
            this.txtAgendaTitle.Name = "txtAgendaTitle";
            this.txtAgendaTitle.Size = new System.Drawing.Size(511, 31);
            this.txtAgendaTitle.TabIndex = 1;
            // 
            // txtOffice
            // 
            this.txtOffice.Location = new System.Drawing.Point(279, 451);
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Size = new System.Drawing.Size(511, 31);
            this.txtOffice.TabIndex = 2;
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(279, 502);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(511, 31);
            this.txtDoc.TabIndex = 3;
            // 
            // btnAddAgenda
            // 
            this.btnAddAgenda.Location = new System.Drawing.Point(913, 317);
            this.btnAddAgenda.Name = "btnAddAgenda";
            this.btnAddAgenda.Size = new System.Drawing.Size(134, 40);
            this.btnAddAgenda.TabIndex = 4;
            this.btnAddAgenda.Text = "Add";
            this.btnAddAgenda.Click += new System.EventHandler(this.btnAddAgenda_Click_1);
            // 
            // btnEditAgenda
            // 
            this.btnEditAgenda.Location = new System.Drawing.Point(913, 363);
            this.btnEditAgenda.Name = "btnEditAgenda";
            this.btnEditAgenda.Size = new System.Drawing.Size(134, 40);
            this.btnEditAgenda.TabIndex = 5;
            this.btnEditAgenda.Text = "Edit";
            this.btnEditAgenda.Click += new System.EventHandler(this.btnEditAgenda_Click);
            // 
            // btnDeleteAgenda
            // 
            this.btnDeleteAgenda.Location = new System.Drawing.Point(913, 409);
            this.btnDeleteAgenda.Name = "btnDeleteAgenda";
            this.btnDeleteAgenda.Size = new System.Drawing.Size(134, 40);
            this.btnDeleteAgenda.TabIndex = 6;
            this.btnDeleteAgenda.Text = "Delete";
            this.btnDeleteAgenda.Click += new System.EventHandler(this.btnDeleteAgenda_Click_1);
            // 
            // tabRecordings
            // 
            this.tabRecordings.Controls.Add(this.button2);
            this.tabRecordings.Controls.Add(this.dgvRecordings);
            this.tabRecordings.Controls.Add(this.txtAudioPath);
            this.tabRecordings.Controls.Add(this.btnBrowseAudio);
            this.tabRecordings.Controls.Add(this.btnAddRecording);
            this.tabRecordings.Controls.Add(this.btnDeleteRecording);
            this.tabRecordings.Location = new System.Drawing.Point(8, 39);
            this.tabRecordings.Name = "tabRecordings";
            this.tabRecordings.Size = new System.Drawing.Size(1134, 564);
            this.tabRecordings.TabIndex = 2;
            this.tabRecordings.Text = "Recordings";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(790, 486);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 42);
            this.button2.TabIndex = 9;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvRecordings
            // 
            this.dgvRecordings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecordings.ColumnHeadersHeight = 46;
            this.dgvRecordings.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRecordings.Location = new System.Drawing.Point(0, 0);
            this.dgvRecordings.MultiSelect = false;
            this.dgvRecordings.Name = "dgvRecordings";
            this.dgvRecordings.RowHeadersWidth = 82;
            this.dgvRecordings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecordings.Size = new System.Drawing.Size(1134, 392);
            this.dgvRecordings.TabIndex = 0;
            this.dgvRecordings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecordings_CellClick);
            this.dgvRecordings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecordings_CellDoubleClick);
            this.dgvRecordings.SelectionChanged += new System.EventHandler(this.dgvRecordings_SelectionChanged);
            // 
            // txtAudioPath
            // 
            this.txtAudioPath.Location = new System.Drawing.Point(82, 432);
            this.txtAudioPath.Name = "txtAudioPath";
            this.txtAudioPath.Size = new System.Drawing.Size(661, 31);
            this.txtAudioPath.TabIndex = 1;
            // 
            // btnBrowseAudio
            // 
            this.btnBrowseAudio.Location = new System.Drawing.Point(836, 423);
            this.btnBrowseAudio.Name = "btnBrowseAudio";
            this.btnBrowseAudio.Size = new System.Drawing.Size(134, 40);
            this.btnBrowseAudio.TabIndex = 2;
            this.btnBrowseAudio.Text = "Browse";
            this.btnBrowseAudio.Click += new System.EventHandler(this.btnBrowseAudio_Click_1);
            // 
            // btnAddRecording
            // 
            this.btnAddRecording.Location = new System.Drawing.Point(223, 488);
            this.btnAddRecording.Name = "btnAddRecording";
            this.btnAddRecording.Size = new System.Drawing.Size(134, 40);
            this.btnAddRecording.TabIndex = 3;
            this.btnAddRecording.Text = "Add";
            this.btnAddRecording.Click += new System.EventHandler(this.btnAddRecording_Click_1);
            // 
            // btnDeleteRecording
            // 
            this.btnDeleteRecording.Location = new System.Drawing.Point(527, 488);
            this.btnDeleteRecording.Name = "btnDeleteRecording";
            this.btnDeleteRecording.Size = new System.Drawing.Size(134, 40);
            this.btnDeleteRecording.TabIndex = 4;
            this.btnDeleteRecording.Text = "Delete";
            this.btnDeleteRecording.Click += new System.EventHandler(this.btnDeleteRecording_Click_1);
            // 
            // tabAssignments
            // 
            this.tabAssignments.Controls.Add(this.button1);
            this.tabAssignments.Controls.Add(this.label9);
            this.tabAssignments.Controls.Add(this.label8);
            this.tabAssignments.Controls.Add(this.dgvAssignments);
            this.tabAssignments.Controls.Add(this.cmbTranscriber);
            this.tabAssignments.Controls.Add(this.cmbStatus);
            this.tabAssignments.Controls.Add(this.btnAssign);
            this.tabAssignments.Controls.Add(this.btnUpdateStatus);
            this.tabAssignments.Location = new System.Drawing.Point(8, 39);
            this.tabAssignments.Name = "tabAssignments";
            this.tabAssignments.Size = new System.Drawing.Size(1134, 564);
            this.tabAssignments.TabIndex = 3;
            this.tabAssignments.Text = "Assignments";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(828, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(87, 484);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Assignment";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "Transcriber";
            // 
            // dgvAssignments
            // 
            this.dgvAssignments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignments.ColumnHeadersHeight = 46;
            this.dgvAssignments.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvAssignments.Location = new System.Drawing.Point(0, 0);
            this.dgvAssignments.MultiSelect = false;
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.RowHeadersWidth = 82;
            this.dgvAssignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignments.Size = new System.Drawing.Size(1134, 370);
            this.dgvAssignments.TabIndex = 7;
            this.dgvAssignments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssignments_CellClick);
            // 
            // cmbTranscriber
            // 
            this.cmbTranscriber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranscriber.Location = new System.Drawing.Point(270, 430);
            this.cmbTranscriber.Name = "cmbTranscriber";
            this.cmbTranscriber.Size = new System.Drawing.Size(511, 33);
            this.cmbTranscriber.TabIndex = 1;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] {
            "Assigned ",
            " In Progress ",
            "Completed"});
            this.cmbStatus.Location = new System.Drawing.Point(270, 484);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(511, 33);
            this.cmbStatus.TabIndex = 2;
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(828, 399);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(134, 40);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "Assign";
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click_1);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(828, 457);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(134, 40);
            this.btnUpdateStatus.TabIndex = 4;
            this.btnUpdateStatus.Text = "Update";
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click_1);
            // 
            // OperatorForm
            // 
            this.ClientSize = new System.Drawing.Size(1150, 611);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OperatorForm";
            this.Text = "Mini-DARMAS-Oprator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabMeetings.ResumeLayout(false);
            this.tabMeetings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetings)).EndInit();
            this.tabAgenda.ResumeLayout(false);
            this.tabAgenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgendas)).EndInit();
            this.tabRecordings.ResumeLayout(false);
            this.tabRecordings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordings)).EndInit();
            this.tabAssignments.ResumeLayout(false);
            this.tabAssignments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMeetings;
        private System.Windows.Forms.TabPage tabAgenda;
        private System.Windows.Forms.TabPage tabRecordings;
        private System.Windows.Forms.TabPage tabAssignments;

        private System.Windows.Forms.DataGridView dgvMeetings;
        private System.Windows.Forms.TextBox txtMeetingNo;
        private System.Windows.Forms.DateTimePicker dtpMeetingDate;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtChairperson;
        private System.Windows.Forms.Button btnAddMeeting;
        private System.Windows.Forms.Button btnEditMeeting;
        private System.Windows.Forms.Button btnDeleteMeeting;

        private System.Windows.Forms.DataGridView dgvAgendas;
        private System.Windows.Forms.TextBox txtAgendaTitle;
        private System.Windows.Forms.TextBox txtOffice;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.Button btnAddAgenda;
        private System.Windows.Forms.Button btnEditAgenda;
        private System.Windows.Forms.Button btnDeleteAgenda;

        private System.Windows.Forms.DataGridView dgvRecordings;
        private System.Windows.Forms.TextBox txtAudioPath;
        private System.Windows.Forms.Button btnBrowseAudio;
        private System.Windows.Forms.Button btnAddRecording;
        private System.Windows.Forms.Button btnDeleteRecording;

        private System.Windows.Forms.DataGridView dgvAssignments;
        private System.Windows.Forms.ComboBox cmbTranscriber;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnUpdateStatus;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button button5;
    }
}
