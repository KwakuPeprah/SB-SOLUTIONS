using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SB_SOLUTIONS
{

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)

        {
            // Define your connection string
            string connectionString = "Data Source=DESKTOP-CJ0V0EH\\KWAKU_SQLSERVER;Initial Catalog=EmployeeDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection to the database
                    conn.Open();

                    string loginQuery = "SELECT Username, Password FROM loginTab WHERE Username=@username AND Password=@password";

                    using (SqlCommand cmd = new SqlCommand(loginQuery, conn))
                    {
                        // Add the parameter values from the textboxes
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable Table = new DataTable(); // Create an empty DataTable to hold results
                            da.Fill(Table);

                            if (Table.Rows.Count > 0)
                            {
                                MessageBox.Show("Login Successful");

                                Dashboard dashboard = new Dashboard();
                                dashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password. Please try again");
                            }
                        }
                    }
                }
                catch (SqlException ex) // Catch specific SQL-related errors
                {
                    MessageBox.Show("A database error occurred: " + ex.Message + "\n\nPlease contact you Database Administration");
                }
                catch (Exception ex) // Catch any other unexpected errors that might occur
                {
                    MessageBox.Show("An unexpected error occurred:" + ex.Message + "\n\nPlease contact your Developer");
                }

            }

        }
    }
}
   

