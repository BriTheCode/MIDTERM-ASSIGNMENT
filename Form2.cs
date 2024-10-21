using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace delacruzform
{
    public partial class Form2 : Form
    {
        private MySqlConnection conn;
        public delegate void DataInsertedHandler();
        public event DataInsertedHandler DataInserted;

        public Form2(MySqlConnection connection)
        {
            InitializeComponent();
            conn = connection;
        }

        // Insert product data into the database
        private void InsertingProducts_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string insertQuery = "INSERT INTO products (product_name, category) VALUES (@productName, @category)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@productName", Product_name.Text);  // Product_name is a TextBox
                cmd.Parameters.AddWithValue("@category", Category.Text);  // Category is a TextBox
                cmd.ExecuteNonQuery();

                MessageBox.Show("Product inserted successfully!");

                // Trigger the DataInserted event to notify Form1
                DataInserted?.Invoke();

                this.Close();
             
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error inserting product: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void Product_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Category_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customers_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void Product_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void InsertingCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string insertQuery = "INSERT INTO customers (customer_name, email,product_id) VALUES (@customerName, @email, @product_id)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@customerName", Customers_name.Text);  // Product_name is a TextBox
                cmd.Parameters.AddWithValue("@email", Email.Text);
                cmd.Parameters.AddWithValue("@product_id", Product_ID.Text); // Category is a TextBox
                cmd.ExecuteNonQuery();

                MessageBox.Show("Product inserted successfully!");

                // Trigger the DataInserted event to notify Form1
                DataInserted?.Invoke();

                this.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error inserting product: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Employee_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Salary_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customers_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void InsertingEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string insertQuery = "INSERT INTO employees (employee_name, salary,customer_id) " +
                    "VALUES (@employeeName, @salary, @customer_id)";
                MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@employeeName", Employee_name.Text);  
                cmd.Parameters.AddWithValue("@salary", Salary.Text); 
                cmd.Parameters.AddWithValue("@customer_id", Customers_ID.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Product inserted successfully!");

                // Trigger the DataInserted event to notify Form1
                DataInserted?.Invoke();

                this.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error inserting product: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
