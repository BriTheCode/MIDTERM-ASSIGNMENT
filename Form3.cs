using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace delacruzform
{

    public partial class Form3 : Form
    {
        private MySqlConnection conn;
        static string connectionString = "Server=localhost;Database=pos;User ID=root;Password=;";

        public Form3()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);  // Initialize connection here
        }

        private void updatingProduct_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(conn);  // Pass the connection to Form4
            f4.ShowDialog();
        }
    }

}
