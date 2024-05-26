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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-PQ1DI5I6\\SQLEXPRESS; Initial Catalog=Stockmanagement; Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {//ADD
            String t1 = textBox1.Text; //Product code
            String t2 = textBox2.Text; //Quantity
            String t3 = textBox3.Text; //Product name
            String t4 = textBox4.Text; //Price
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO product (product_code, product_name, quantity, price) VALUES('" + t1 + "','" + t3 + "','" + t2 + "','" + t4 + "')" , baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void Form2_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {//DELETE
            String t1 = textBox1.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM product WHERE product_code=('"+t1+"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show(); // Form3'ü göster
            this.Hide(); // Form2'yi gizle

        }
    }
}
