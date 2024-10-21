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
    public partial class Form4 : Form
    {
        private MySqlConnection conn;

        // Constructor to accept the connection object
        public Form4(MySqlConnection connection)
        {
            InitializeComponent();
            conn = connection;  // Store the passed connection
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string updateQuery = "UPDATE products SET product_name = @productName, category = @category WHERE product_id = @productId";
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@productName", updateName.Text);
                cmd.Parameters.AddWithValue("@category", updateCategory.Text);
                cmd.Parameters.AddWithValue("@productId", updateID.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Product updated successfully!");
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}