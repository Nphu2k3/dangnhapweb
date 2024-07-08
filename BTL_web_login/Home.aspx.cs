using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BTL_web_login
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string currentUserEmail = "john@mail.com"; // Thay thế bằng email của người dùng đăng nhập

                string connectionString = ConfigurationManager.ConnectionStrings["UserDBConnectionString"].ConnectionString;

                string query = "SELECT Name, Email FROM Users WHERE Email = @Email";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", currentUserEmail);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string userName = reader["Name"].ToString();
                            string userEmail = reader["Email"].ToString();
                            lblUserInfo.Text = $"Welcome back, {userName}! Your email: {userEmail}";
                        }
                        reader.Close();
                    }
                }
            }
        }
    }
}
