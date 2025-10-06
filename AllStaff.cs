using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SB_SOLUTIONS
{
    public partial class AllStaff : Form
    {
        public AllStaff()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            ds.Show();
            this.Hide();
        }
    }
}
