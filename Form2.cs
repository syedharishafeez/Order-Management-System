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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        String c_id;
        String p_id;
        String o_id;
        int k;
        String t14, t13;
        String c_id2;
        String[] o_id2=new string[10];
        String od_id2;
        String[] p_id2 = new string[10];
        String[] p_name2 = new string[10];

        String pid3;
        String oid3;

        public Form2()
        {
            InitializeComponent();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();


        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void customerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panel3.Hide();
            panel2.Hide();
            panel1.Show();

        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            dateTimePicker5.Value = DateTime.Now;
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel1.Hide();
            panel2.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "insert into Customer(name,email,contactno,address) values('" + textBox1.Text + "' , '" + textBox2.Text + "' ,'" + textBox3.Text + "' ,'" + textBox4.Text + "' )";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            MessageBox.Show("Insert Successfully");

            
            comboBox1.Items.Clear();
            NewMethod();
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "select * from Customer where name='"+comboBox1.SelectedItem+"'";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                textBox7.Text = reader["email"].ToString();
                textBox6.Text = reader["contactno"].ToString();
                textBox5.Text = reader["address"].ToString();

            }
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            NewMethod();
            product();

        }

        private void product()
        {
            SqlConnection conn2 = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query2 = "select * from Product";
            SqlCommand com2 = new SqlCommand(query2, conn2);

            conn2.Open();
            SqlDataReader reader2 = com2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox3.Items.Add(reader2["name"]);
                comboBox4.Items.Add(reader2["name"]);

            }
            conn2.Close();
        }

        private void NewMethod()
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "select * from Customer";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["name"]);
                comboBox2.Items.Add(reader["name"]);
                comboBox6.Items.Add(reader["name"]);
            }
            conn.Close();

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "update Customer set email ='" + textBox7.Text + "' , contactno = '" + textBox6.Text + "' , address = '" + textBox5.Text + "' where name = '"+ comboBox1.SelectedItem + "'";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            textBox7.Text = textBox6.Text = textBox5.Text = "";
            comboBox1.Text = "";
            MessageBox.Show("Update Successfully");


            comboBox1.Items.Clear();
            NewMethod();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "delete from Customer where name='" + comboBox1.SelectedItem + "'";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            textBox7.Text = textBox6.Text = textBox5.Text = "";
            comboBox1.Text = "";
            MessageBox.Show("Delete Successfully");

            comboBox1.Items.Clear();
            NewMethod();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "insert into Product(name,price,quantityavailable,expirydate,manufacturingdate) values ('" + textBox8.Text + "' , '" + textBox9.Text + "' ,'" + textBox10.Text + "' ,'" + dateTimePicker1.Value.ToString() + "' ,'" + dateTimePicker2.Value.ToString() + "' )";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            textBox8.Text = textBox9.Text = textBox10.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            comboBox3.Text = "";
            MessageBox.Show("Insert Successfully");


            comboBox3.Items.Clear();
            product();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "delete from Product where name='" + comboBox3.SelectedItem + "'";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            textBox11.Text = textBox12.Text = "";
            dateTimePicker4.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            comboBox3.Text = "";
            MessageBox.Show("Delete Successfully");

            comboBox3.Items.Clear();
            product();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "update Product set price ='" + textBox12.Text + "' , quantityavailable = '" + textBox11.Text + "' , expirydate = '" + dateTimePicker4.Value.ToString() + "' , manufacturingdate  = '" + dateTimePicker3.Value.ToString() + "' where name = '" + comboBox3.SelectedItem + "'";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            textBox11.Text = textBox12.Text = "";
            dateTimePicker4.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            comboBox3.Text = "";
            MessageBox.Show("Update Successfully");

            comboBox3.Items.Clear();
            product();
        }

        private void comboBox3_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "select * from Product where name='" + comboBox3.SelectedItem + "'";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                textBox12.Text = reader["price"].ToString();
                textBox11.Text = reader["quantityavailable"].ToString();
                dateTimePicker4.Text = reader["expirydate"].ToString();
                dateTimePicker3.Text = reader["manufacturingdate"].ToString();

            }
            conn.Close();
        }

        private void comboBox4_DropDownClosed(object sender, EventArgs e)
        {
            comboBox5.Text = "";
            textBox14.Text = "";
            comboBox5.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "select * from Product where name='" + comboBox4.SelectedItem + "'";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                p_id = reader["id"].ToString();
                int pri= Convert.ToInt32(reader["price"].ToString());
                int qnt = Convert.ToInt32(reader["quantityavailable"].ToString());
                if (qnt >= 1)
                {
                    for (int i = 1; i <= qnt; i++)
                    {
                        comboBox5.Items.Add(i);
                    }

                    textBox13.Text = "" + pri;
                    t13 = textBox13.Text;
                    int cpu = Convert.ToInt32(comboBox5.SelectedItem);
                }

                else
                {
                    MessageBox.Show("Out of Stock");
                }
                
                
            }
            conn.Close();
        }

        private void comboBox5_DropDownClosed(object sender, EventArgs e)
        {
            int pri=Convert.ToInt32(textBox13.Text);
            int cpu = Convert.ToInt32(comboBox5.SelectedItem);
            textBox14.Text = "" + (pri * cpu);
            t14 = textBox14.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "insert into Order2(orderdate,customerid) values ('" + dateTimePicker5.Value.ToString() + "' , "+Convert.ToInt32(c_id)+")";
            
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();

            var query2 = "select * from Order2";

            SqlCommand com2 = new SqlCommand(query2, conn);
            conn.Open();
            SqlDataReader reader2 = com2.ExecuteReader();
            
            while (reader2.Read())
            {
                o_id = reader2["id"].ToString();
                
            }
            conn.Close();


            var query3 = "insert into Orderdetail(orderid,productid) values ("+Convert.ToInt32(o_id)+" , " + Convert.ToInt32(p_id) + ")";

            SqlCommand com3 = new SqlCommand(query3, conn);

            conn.Open();
            com3.ExecuteNonQuery();
            conn.Close();

            textBox13.Text = textBox14.Text = "";

            comboBox2.Text = comboBox4.Text = comboBox5.Text = "";
            MessageBox.Show("Insert Successfully");

            comboBox5.Items.Clear();
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            comboBox6.Items.Clear();
            product();
            NewMethod();
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "select * from Customer where name='" + comboBox2.SelectedItem + "'";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                c_id = reader["id"].ToString();
                
            }
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "select * from Product where name='" + comboBox7.SelectedItem + "'";
            SqlCommand com = new SqlCommand(query, conn);
            
            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                pid3 = reader["id"].ToString();

            }
            conn.Close();

            for (int l = 0; l < k; l++)
            {
                var query3 = "select * from Orderdetail where orderid=" + o_id2[l] + " and productid="+Convert.ToInt32(pid3)+"";
                SqlCommand com3 = new SqlCommand(query3, conn);

                conn.Open();
                SqlDataReader reader3 = com3.ExecuteReader();
                while (reader3.Read())
                {
                    oid3 = reader3["orderid"].ToString();

                }
                
                conn.Close();


                if (Convert.ToInt32(o_id2[l]) == Convert.ToInt32(oid3))
                {
                    var query4 = "delete from Orderdetail where orderid=" + Convert.ToInt32(oid3) + " and productid=" + Convert.ToInt32(pid3) + "";
                    SqlCommand com4 = new SqlCommand(query4, conn);

                    conn.Open();
                    com4.ExecuteNonQuery();
                    conn.Close();


                    var query5 = "delete from Order2 where id=" + Convert.ToInt32(oid3) + "";
                    SqlCommand com5 = new SqlCommand(query5, conn);

                    conn.Open();
                    com5.ExecuteNonQuery();
                    conn.Close();
                }

            }
            comboBox6.Text = comboBox7.Text = "";
          

            comboBox6.Items.Clear();
            NewMethod();
            MessageBox.Show("Delete Successfully");

        }

        private void comboBox6_DropDownClosed(object sender, EventArgs e)
        {
            
            comboBox7.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "select * from customer where name='" +comboBox6.SelectedItem+"'";
            
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                c_id2 = reader["id"].ToString();

            }
            conn.Close();

            var query2 = "select * from Order2 where customerid='" +(c_id2) + "'";

            SqlCommand com2 = new SqlCommand(query2, conn);
            k = 0;
            conn.Open();
            SqlDataReader reader2 = com2.ExecuteReader();
            while (reader2.Read())
            {
                o_id2[k] = reader2["id"].ToString();
                k++;
            }
            conn.Close();

            for (int l = 0; l < k; l++)
            {
                var query3 = "select * from Orderdetail where orderid='" + (o_id2[l]) + "'";

                SqlCommand com3 = new SqlCommand(query3, conn);

                conn.Open();
                SqlDataReader reader3 = com3.ExecuteReader();
                while (reader3.Read())
                {
                    p_id2[l] = reader3["productid"].ToString();

                }
                conn.Close();

            }

            for (int m = 0; m < k; m++)
            {
                var query4 = "select * from Product where id='" + (p_id2[m]) + "'";

                SqlCommand com4 = new SqlCommand(query4, conn);

                conn.Open();
                SqlDataReader reader4 = com4.ExecuteReader();
                while (reader4.Read())
                {
                    comboBox7.Items.Add(reader4["name"]);

                }
                conn.Close();

                
            }

            

        }

        private void comboBox7_DropDownClosed(object sender, EventArgs e)
        {
            
          
        }

        private void comboBox8_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER-PC; initial catalog =OMS3; integrated security = true; ");
            var query = "select * from Product where name='" + comboBox7.SelectedItem + "'";
            SqlCommand com = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                pid3 = reader["id"].ToString();

            }
            conn.Close();

            for (int l = 0; l < k; l++)
            {
                var query3 = "select * from Orderdetail where orderid=" + o_id2[l] + " and productid=" + Convert.ToInt32(pid3) + "";
                SqlCommand com3 = new SqlCommand(query3, conn);

                conn.Open();
                SqlDataReader reader3 = com3.ExecuteReader();
                while (reader3.Read())
                {
                    oid3 = reader3["orderid"].ToString();

                }

                conn.Close();


                if (Convert.ToInt32(o_id2[l]) == Convert.ToInt32(oid3))
                {
                    var query4 = "update Orderdetail set price where orderid=" + Convert.ToInt32(oid3) + " and productid=" + Convert.ToInt32(pid3) + "";
                    SqlCommand com4 = new SqlCommand(query4, conn);

                    conn.Open();
                    com4.ExecuteNonQuery();
                    conn.Close();


                    var query5 = "delete from Order2 where id=" + Convert.ToInt32(oid3) + "";
                    SqlCommand com5 = new SqlCommand(query5, conn);

                    conn.Open();
                    com5.ExecuteNonQuery();
                    conn.Close();
                }

            }
            comboBox6.Text = comboBox7.Text = "";
           

            comboBox6.Items.Clear();
            NewMethod();
            MessageBox.Show("Update Successfully");
        }
    }
}
