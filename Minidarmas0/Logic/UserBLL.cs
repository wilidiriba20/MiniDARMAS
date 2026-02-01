using MiniDARMAS.Data;
using MiniDARMAS.Models;
using System.Collections.Generic;
using System.Data;

namespace MiniDARMAS.Logic
{
    public class UserBLL
    {
        private UserDAL dal = new UserDAL();

        public string ErrorMessage { get; private set; }

        // ================= LOGIN =================
        public User Login(string username, string password, string role)
        {
            return dal.Login(username, password, role);
        }

        // ================= GET USERS =================
        public DataTable GetAllUsers()
        {
            return dal.GetAllUsers();
        }

        // ================= CREATE USER =================
        public bool CreateUser(string fullName, string username, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                ErrorMessage = "All fields are required.";
                return false;
            }

            if (password.Length < 6)
            {
                ErrorMessage = "Password must be at least 6 characters.";
                return false;
            }

            if (dal.UsernameExists(username))
            {
                ErrorMessage = "Username already exists.";
                return false;
            }

            int rows = dal.CreateUser(fullName, username, password, role);
            return rows > 0;
        }

        // ================= UPDATE USER =================
        public bool UpdateUser(int userId, string fullName, string username, string password, string role)
        {
            if (userId <= 0)
            {
                ErrorMessage = "No user selected.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(username))
            {
                ErrorMessage = "Full name and username are required.";
                return false;
            }

            // Check if username already exists for another user
            if (dal.UsernameExistsForOtherUser(userId, username))
            {
                ErrorMessage = "Username already exists!";
                return false;
            }

            int rows = dal.UpdateUser(userId, fullName, username, password, role);
            return rows > 0;
        }

        // ================= ACTIVATE / DEACTIVATE =================
        public bool SetUserStatus(int userId, bool isActive)
        {
            if (userId <= 0)
            {
                ErrorMessage = "Invalid user selected.";
                return false;
            }

            int rows = dal.SetUserStatus(userId, isActive);
            return rows > 0;
        }

        // ================= DELETE USER =================
        public bool DeleteUser(int userId, int currentAdminId)
        {
            ErrorMessage = "";

            //  Invalid selection
            if (userId <= 0)
            {
                ErrorMessage = "Invalid user selected.";
                return false;
            }

            // Prevent self-delete
            if (userId == currentAdminId)
            {
                ErrorMessage = "You cannot delete yourself.";
                return false;
            }

            //  Call DAL
            int rowsAffected = dal.DeleteUser(userId);

            //  Delete failed
            if (rowsAffected <= 0)
            {
                ErrorMessage = "Delete failed. User may not exist.";
                return false;
            }

            return true;
        }


        // ================= SEARCH USERS =================
        public DataTable SearchUsers(string keyword)
        {
            return dal.SearchUsers(keyword);
        }


        // ================= GET USERS BY ROLE =================
        public List<User> GetUsersByRole(string role)
        {
            return dal.GetUsersByRole(role);
        }

    }
}
