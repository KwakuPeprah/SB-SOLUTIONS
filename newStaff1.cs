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
    public partial class newStaff1 : Form
    {
        public newStaff1()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            newStaff ns = new newStaff();
            ns.Show();
            this.Hide();
        }

        private void btnSaveStaff_Click(object sender, EventArgs e)
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
                    string insertQuery = "INSERT INTO EmployeeDetails (Job Title, Department, Supervisor, Employment Type, Employment Status, Basic Salary) " +
                                         "VALUES (@JobT, @Dept, @Supervisor, @EmploymentT, @EmploymentS, @BasicS)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        // Add the parameter values from your application's text boxes or controls
                        cmd.Parameters.AddWithValue("@JobT", txtJob.Text.Trim());
                        cmd.Parameters.AddWithValue("@Dept", cboDept.Text.Trim());
                        cmd.Parameters.AddWithValue("@Supervisor", txtSuper.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmploymentT", cboEmpType.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmploymentS", cboEmpStatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@BasicS", txtBasSal.Text.Trim());

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
        }
    }
}
