using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BTL_web_login
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Không cần thêm logic trong Page_Load cho việc đăng ký
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim(); // Cần băm mật khẩu trước khi lưu vào cơ sở dữ liệu

            // Băm mật khẩu (cần triển khai hàm băm phù hợp như SHA256, MD5, ...)
            string hashedPassword = YourPasswordHashingFunction(password);

            // Chuỗi kết nối từ Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["UserDBConnectionString"].ConnectionString;

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Câu lệnh SQL để thêm người dùng
                string sql = "INSERT INTO Users (Name, Email, PasswordHash) VALUES (@Name, @Email, @PasswordHash)";

                // Tạo và mở Command để thực thi câu lệnh SQL
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Thêm các tham số vào Command
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    // Mở kết nối và thực thi câu lệnh
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Đăng ký thành công, có thể chuyển hướng hoặc hiển thị thông báo
                            Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            // Xử lý lỗi khi không thêm được người dùng
                            litMessage.Text = "Đã xảy ra lỗi khi thêm người dùng. Vui lòng thử lại sau.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ khi thực thi câu lệnh SQL
                        litMessage.Text = "Đã xảy ra lỗi: " + ex.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        // Hàm băm mật khẩu để thực hiện băm mật khẩu người dùng
        private string YourPasswordHashingFunction(string password)
        {
            // Thực hiện mã hóa mật khẩu ở đây (ví dụ: sử dụng SHA256, MD5, ...)
            // Lưu ý: Đây là một ví dụ đơn giản, nên nên sử dụng thư viện băm mật khẩu an toàn hơn trong thực tế
            return password; // Giả sử đây là mật khẩu chưa được băm
        }
    }
}
