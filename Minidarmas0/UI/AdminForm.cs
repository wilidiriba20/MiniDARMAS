using MiniDARMAS.Logic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Minidarmas0.UI
{
    public partial class AdminForm : Form
    {
        UserBLL userBLL = new UserBLL();

        // ✅ Fix: Must be initialized
        private readonly int currentAdminId;



        // ✅ Fix: Constructor that receives current admin ID

        public AdminForm(int adminId)
        {
            InitializeComponent();   // MUST be here
            currentAdminId = adminId;
            this.WindowState = FormWindowState.Maximized;


            LoadRoles();
            LoadUsers();
        }
        private void LoadRoles()
        {
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Operator");
            cmbRole.Items.Add("Transcriber");
            cmbRole.Items.Add("Editor");
            cmbRole.Items.Add("Approver");
            cmbRole.SelectedIndex = 0;

            cmbFilterRole.Items.Add("All");
            cmbFilterRole.Items.Add("Admin");
            cmbFilterRole.Items.Add("Operator");
            cmbFilterRole.Items.Add("Transcriber");
            cmbFilterRole.Items.Add("Editor");
            cmbFilterRole.Items.Add("Approver");
            cmbFilterRole.SelectedIndex = 0;
        }

        private DataTable LoadUsers()
        {
            DataTable dt = userBLL.GetAllUsers();
            dgvUsers.DataSource = dt;
            dgvUsers.Columns["UserId"].Visible = false;


            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            return dt;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            bool success = userBLL.CreateUser(
                txtFullName.Text,
                txtUsername.Text,
                txtPassword.Text,
                cmbRole.Text
            );

            if (!success)
            {
                MessageBox.Show(userBLL.ErrorMessage, "Error");
                return;
            }

            LoadUsers();
            MessageBox.Show("User created successfully!");
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            txtFullName.Text = dgvUsers.CurrentRow.Cells["FullName"].Value.ToString();
            txtUsername.Text = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
            txtPassword.Text = dgvUsers.CurrentRow.Cells["Password"].Value.ToString();
            cmbRole.Text = dgvUsers.CurrentRow.Cells["Role"].Value.ToString();

            
        }

        private void SelectRowByUserId(int userId)
        {
            dgvUsers.ClearSelection();

            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["UserId"].Value != null &&
                    int.TryParse(row.Cells["UserId"].Value.ToString(), out int id) &&
                    id == userId)
                {
                    row.Selected = true;
                  
                    dgvUsers.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }


        private void btnEditUser_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserId"].Value);

            // Fix: if password empty, keep old password
            string passwordToUse = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(passwordToUse))
            {
                passwordToUse = dgvUsers.CurrentRow.Cells["Password"].Value.ToString();
            }

            bool success = userBLL.UpdateUser(
                userId,
                txtFullName.Text.Trim(),
                txtUsername.Text.Trim(),
                passwordToUse,
                cmbRole.Text
            );

            if (!success)
            {
                MessageBox.Show(userBLL.ErrorMessage);
                return;
            }

            LoadUsers();
            SelectRowByUserId(userId);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserId"].Value);

            var confirm = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                bool deleted = userBLL.DeleteUser(userId, currentAdminId);

                if (!deleted)
                {
                    MessageBox.Show(userBLL.ErrorMessage, "Error");
                    return;
                }

                LoadUsers();
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserId"].Value);

            userBLL.SetUserStatus(userId, true);
            LoadUsers();
            SelectRowByUserId(userId);
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserId"].Value);

            userBLL.SetUserStatus(userId, false);
            LoadUsers();
            SelectRowByUserId(userId);
        }

        // =================== FILTER + SEARCH ===================
        private void ApplyFilters()
        {
            DataTable dt = userBLL.GetAllUsers();
            string filter = "";

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                filter += $"FullName LIKE '%{txtSearch.Text}%' OR Username LIKE '%{txtSearch.Text}%'";
            }

            if (cmbFilterRole.Text != "All")
            {
                if (!string.IsNullOrEmpty(filter))
                    filter += " AND ";

                filter += $"Role = '{cmbFilterRole.Text}'";
            }

            dt.DefaultView.RowFilter = filter;
            dgvUsers.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        
               
        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

       
    }
}
