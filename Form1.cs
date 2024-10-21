using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace delacruzform
{
    public partial class Form1 : Form
    {
        static string connectionString = "Server=localhost;Database=pos;User ID=root;Password=;";
        static MySqlConnection conn = new MySqlConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
        }
        // Buttons for Connection
        private void button1_Click_1(object sender, EventArgs e)
        {
            Connect();
        }

        // Buttons for Show All point of Sales
        private void button2_Click(object sender, EventArgs e)
        {
            ShowPointOfSales();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Connect()
        {
            try
            {
                conn.Open();
                MessageBox.Show("Connection to the database was successful!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void ShowPointOfSales()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "SELECT p.product_name, p.category, c.customer_name, c.email, e.employee_name, e.salary " +
                               "FROM employees e      " +
                               "JOIN  customers c ON c.customer_id = e.customer_id  " +
                               "JOIN  products p ON p.product_id = c.product_id";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataContents.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error retrieving products: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void DataContents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(conn);
            f2.DataInserted += ShowPointOfSales;
            f2.ShowDialog();
        }


        private void Update_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Show_Products_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "SELECT * FROM products";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataContents.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error retrieving products: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void ShowCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "SELECT * FROM Customers";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataContents.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error retrieving Customers: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void ShowEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "SELECT * FROM employees";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataContents.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error retrieving Employees: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
