using MiniDARMAS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MiniDARMAS.Data
{
    public class UserDAL
    {
        DBConnection db = new DBConnection();

        //  LOGIN
        public User Login(string username, string password, string role)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string q = @"SELECT UserId, Username, Role
                     FROM Users
                     WHERE Username = @u
                       AND Password = @p
                       AND Role = @r
                       AND IsActive = @active";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                cmd.Parameters.AddWithValue("@r", role);
                cmd.Parameters.AddWithValue("@active", true);

                con.Open();
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(r["UserId"]),
                        Username = r["Username"].ToString(),
                        Role = r["Role"].ToString()
                    };
                }

                return null;
            }
        }


        //  GET ALL USERS (ADMIN)
        public DataTable GetAllUsers()
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"SELECT UserId, FullName, Username, Password, Role, IsActive 
                                 FROM Users";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // CREATE USER (ADMIN)
        public int CreateUser(string fullName, string username, string password, string role)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"INSERT INTO Users
                                 (FullName, Username, Password, Role, IsActive)
                                 VALUES (@FullName, @Username, @Password, @Role, 1)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        //  ACTIVATE / DEACTIVATE USER (ADMIN)
        public int SetUserStatus(int userId, bool isActive)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"UPDATE Users 
                                 SET IsActive=@IsActive 
                                 WHERE UserId=@UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.Parameters.AddWithValue("@UserId", userId);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // SEARCH USERS (ADMIN)
        public DataTable SearchUsers(string keyword)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"SELECT UserId, FullName, Username, Role, IsActive
                                 FROM Users
                                 WHERE FullName LIKE @k OR Username LIKE @k";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@k", "%" + keyword + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // UPDATE USER (ADMIN)
        public int UpdateUser(int userId, string fullName, string username, string password, string role)
        {
            try
            {
                using (SqlConnection con = db.GetConnection())
                {
                    string query = @"UPDATE Users
                                     SET FullName=@FullName, Username=@Username, Password=@Password, Role=@Role
                                     WHERE UserId=@UserId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Duplicate username error
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    return -1; // special code for duplicate username
                }
                throw; // throw other errors
            }
        }

        // DELETE USER (ADMIN)
        public int DeleteUser(int userId)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = "DELETE FROM Users WHERE UserId=@UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userId);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        //  USERNAME CHECK (for create)
        public bool UsernameExists(string username)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @u";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@u", username);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // USERNAME CHECK (for update)
        public bool UsernameExistsForOtherUser(int userId, string username)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username=@Username AND UserId <> @UserId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@UserId", userId);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }


        //  GET USERS BY ROLE (for Operator module)
        public List<User> GetUsersByRole(string role)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string query = @"SELECT UserId, FullName 
                         FROM Users 
                         WHERE Role=@role AND IsActive=1";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@role", role);

                DataTable dt = new DataTable();
                da.Fill(dt);

                // Convert DataTable to List<User>
                List<User> users = new List<User>();

                foreach (DataRow row in dt.Rows)
                {
                    users.Add(new User
                    {
                        UserId = Convert.ToInt32(row["UserId"]),
                        FullName = row["FullName"].ToString()
                    });
                }

                return users;
            }
        }
    }
    }
