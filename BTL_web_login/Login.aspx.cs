using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BTL_web_login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Code here to run when the page loads
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate the user credentials
            if (ValidateUser(email, password))
            {
                // Redirect to another page upon successful login
                Response.Redirect("Home.aspx");
            }
            else
            {
                litMessage.Text = "Invalid email or password. Please try again.";
            }
        }

        private bool ValidateUser(string email, string password)
        {
            string constr = ConfigurationManager.ConnectionStrings["UserDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND PasswordHash = @Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    return count == 1;
                }
            }
        }
    }
}
