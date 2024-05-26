using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20230305046
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-PQ1DI5I6\\SQLEXPRESS; Initial Catalog=Stockmanagement; Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
            listele();

        }
        private void listele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from product", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        { //UPDATE
            String t1 = textBox1.Text; //Product code
            String t2 = textBox2.Text; //Quantity
            String t3 = textBox3.Text; //Product name
            String t4 = textBox4.Text; //Price

            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE product SET product_code='"+t1+ "',product_name='"+t2+ "',Quantity='"+t3+ "',price='"+t4+"' WHERE product_code='" +t1+"' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); 
            form2.Show(); 
            this.Hide(); 

        }
    }
}
