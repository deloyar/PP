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

namespace PP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void insert_Btn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text !="") { 

            using (SqlConnection con = new SqlConnection(Db.getConnectionString()))
            {
                    try
                    {
                        SqlCommand cmd = 
                            new SqlCommand("insert into TestDB(Name, State) values (@name, @state)", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@state", textBox2.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Operation Done");
                        
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Operation Failed");
                    }
                    finally
                    {
                        con.Close();
                        ClearData();
                        DisplayData();
                    }
            }
            }
        }

        private void DisplayData()
        {
            using(SqlConnection con = new SqlConnection(Db.getConnectionString()))
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter("select * from TestDB", con);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
            
        }
        //Clear Data  
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text != "" && txt_State.Text != "")
            {
                cmd = new SqlCommand("update tbl_Record set Name=@name,State=@state where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                cmd.Parameters.AddWithValue("@state", txt_State.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete tbl_Record where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
    }
}
