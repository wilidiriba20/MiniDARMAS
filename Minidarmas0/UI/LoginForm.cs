using MiniDARMAS.Logic;
using MiniDARMAS.UI;
using System;
using System.Windows.Forms;

namespace Minidarmas0.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.Resize += (s, e) =>
            {
                groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
                groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
            };

            // Initial center
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = (this.ClientSize.Height - groupBox1.Height) / 2;
        }

        private void Login()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString().Trim() ?? "";

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                lblError.Visible = true;
                lblError.Text = "Username, password and role are required.";
                return;
            }

            UserBLL userBLL = new UserBLL();

            // Call Login from Business Layer
            var user = userBLL.Login(username, password, role);

            if (user != null)
            {
                lblError.Visible = false;

                int userId = user.UserId;
                string userRole = user.Role;

                // Open correct form based on role
                if (userRole == "Admin")
                {
                    AdminForm admin = new AdminForm(userId);
                    admin.Show();
                    this.Hide();
                }
                else if (userRole == "Operator")
                {
                    OperatorForm op = new OperatorForm(userId);
                    op.Show();
                    this.Hide();
                }
                else if (userRole == "Transcriber")
                {
                    TranscriberForm transcriber = new TranscriberForm(userId);
                    transcriber.Show();
                    this.Hide();
                }
                else if (userRole == "Editor")
                {
                    EditorForm editor = new EditorForm();
                    editor.Show();
                    this.Hide();
                }
                else if (userRole == "Approver")
                {
                    ApproverForm approver = new ApproverForm();
                    approver.Show();
                    this.Hide();
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Login failed. Check username, password and role.";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

       
    }
}
