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

namespace LittleSteps_Database
{
    public partial class loginScreenForm : Form
    {
        public loginScreenForm()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void registerButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funciono xd");
        }

        private void loginButton_Click_1(object sender, EventArgs e)
        {
            string username = usernameTextField.Text;
            string usernameCheck = "";
            string password = passwordTextField.Text;
            string passwordCheck = "";
            String connection = "workstation id=littlesteps.mssql.somee.com;packet size=4096;user id=xSerafini_SQLLogin_1;pwd=45bgyu4oj1;data source=littlesteps.mssql.somee.com;persist security info=False;initial catalog=littlesteps";
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT usuario from usuario where usuario = @user";
                string findQuery1 = "SELECT contrasena from usuario where contrasena = @password";
                SqlCommand comm = new SqlCommand(findQuery, con);
                SqlCommand comm1 = new SqlCommand(findQuery1, con);
                comm1.Parameters.AddWithValue("@password", passwordTextField.Text);
                comm.Parameters.AddWithValue("@user", usernameTextField.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if(reader.HasRows){
                        while(reader.Read())
                        {
                            usernameCheck = reader[0].ToString();
                            passwordCheck = reader[1].ToString();
                            if(username == usernameCheck && password == passwordCheck)
                            {
                                MessageBox.Show("Funciono");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No funciono");
                    }
                    
                }
                con.Close();
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
                MessageBox.Show("No se encontro el usuario en el sistema, porfavor verifique nuevamente");
            }
            
        }
    }
}
