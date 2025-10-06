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
    public partial class newStaff : Form
    {
        public newStaff()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-CJ0V0EH\\KWAKU_SQLSERVER;Initial Catalog=EmployeeDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    conn.Open();

                    // This is the SQL command to insert data into the EmployeeDetails table
                    // We use parameters (@...) to prevent SQL injection
                    string insertQuery = "INSERT INTO EmployeeDetails (First Name, Middle Name, Last Name, Gender, D.O.B, D.O.E, Marital Status, Primary Phone, Email) " +
                        "-VALUES (@FirstN, @MiddleN, @LastN, @Gender, @DOB, @DOE, @MaritalS, @PrimPhone, @Email)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        // Add the parameter values from your application's text boxes or controls
                        cmd.Parameters.AddWithValue("@FirstN", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@MiddleN", txtMidName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastN", txtLastName.Text.Trim());
                        if (radMale.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Male");
                        }
                        else if (radFemale.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Gender", "Female");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("Gender", string.Empty);
                        }
                        cmd.Parameters.AddWithValue("@Gender",radMale.Text.ToString());
                        cmd.Parameters.AddWithValue("@Gender", radFemale.Text.ToString());
                        cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value);
                        cmd.Parameters.AddWithValue("@DOE", dtpDOE.Value);
                        cmd.Parameters.AddWithValue("@MaritalS", cboMarry.Text.ToString());
                        cmd.Parameters.AddWithValue("@PrimPhone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        // ExecuteNonQuery is used for INSERT, UPDATE, and DELETE statements.
                        // It returns the number of rows affected.
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee details saved successfully!");
                            // Clear your form fields here after a successful save
                            // For example: txtFullName.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Failed to save employee details. Please try again.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("A database error occurred: " + ex.Message + "\n\nPlease contact your Database Administration");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred:" + ex.Message + "\n\nPlease contact your Developer");
                }
            }

            newStaff1 st1 = new newStaff1();
            st1.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            ds.Show();
            this.Hide();
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            dtpDOB.CustomFormat = "DD/MM/YYYY";
        }

        private void dtpDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Back)
            {
                dtpDOB.CustomFormat = "";
            }
        }

       
    }
}
