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
using System.Configuration;

namespace LittleSteps_Database
{
    public partial class loginScreenForm : Form
    {
        private EmployeeForm employeeScreen;
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
            int counter = 0;
            string username = usernameTextField.Text;
            string usernameCheck = "";
            string password = passwordTextField.Text;
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT usuario from usuario where usuario = @user";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@user", usernameTextField.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usernameCheck = reader["usuario"].ToString();
                            if (username == usernameCheck)
                            {
                                counter++;
                            }
                        }
                    }
                }
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("Error: " + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
            try
            {
                if (counter == 1)
                {
                    MessageBox.Show("El usuario ya existe, porfavor cambie el usuario nuevamente para poder completar el registro");
                }
                else
                {
                    SqlConnection con = new SqlConnection(connection);
                    string registerQuery = "INSERT into usuario(usuario,contrasena) VALUES(@usuario,@pwd)";
                    SqlCommand comm = new SqlCommand(registerQuery, con);
                    comm.Parameters.AddWithValue("@usuario", usernameTextField.Text);
                    comm.Parameters.AddWithValue("@pwd", passwordTextField.Text);
                    con.Open();
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Se ha registrado el usuario correctamente");
                    con.Close();
                }
            } catch (Exception es)
            {
                MessageBox.Show("Error:\n" + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }
    
        private void loginButton_Click_1(object sender, EventArgs e)
        {
            string username = usernameTextField.Text;
            string usernameCheck = "";
            string password = passwordTextField.Text;
            string passwordCheck = "";
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT usuario,contrasena from usuario where usuario = @user AND contrasena = @password";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@user", usernameTextField.Text);
                comm.Parameters.AddWithValue("@password", passwordTextField.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usernameCheck = reader["usuario"].ToString();
                            passwordCheck = reader["contrasena"].ToString();
                            if (username == usernameCheck && password == passwordCheck)
                            {
                                MessageBox.Show("Loggin Succesfully");
                                //Aqui va abrir los forms 
                                employeeScreen = new EmployeeForm();
                                employeeScreen.Show();
                                this.Hide();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario/contraseña esta incorrecta, porfavor intentelo nuevamente");
                    }
                }
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("Error: "+es+" \n Porfavor contacte al tecnico de informatica del area");
            }
            
        }
    }
}
