using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace LittleSteps_Database
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
        }

        private void parentPanel_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void profEnterDate_Click(object sender, EventArgs e)
        {
        }
        //Works

        //
        //      TUTOR
        //
        private void parentIdSearch_Click(object sender, EventArgs e)
        {
            DateTime nac;
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from tutor where cedula = @RNC";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@RNC", parentRNC.Text);
                
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            parentRNC.Text = reader["cedula"].ToString();
                            parentName.Text = reader["nombre"].ToString();
                            parentLast.Text = reader["apellido"].ToString();
                            parentDate.Text = Convert.ToDateTime( reader["fecha_nacimiento"]).ToString();
                            parentEmail.Text = reader["email"].ToString();
                            parentPhone.Text = reader["telefono"].ToString();
                            parentLoc.Text = reader["direccion"].ToString();
                        }
                    }
                }
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("Error: " + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }
        //Works
        private void parentRegister_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string username = parentRNC.Text;
            string usernameCheck = "";
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from tutor where cedula = @RNC";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@RNC", parentRNC.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usernameCheck = reader["cedula"].ToString();
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
                    con.Open();
                    string insertQuery = "INSERT INTO tutor(cedula,nombre,apellido,fecha_nacimiento,email,direccion,telefono) VALUES (@cedula,@nombre,@apellido,@fecha_nacimiento,@email,@direccion,@telefono)";
                    SqlCommand comm1 = new SqlCommand(insertQuery,con);
                    comm1.Parameters.AddWithValue("@cedula",parentRNC.Text);
                    comm1.Parameters.AddWithValue("@nombre",parentName.Text);
                    comm1.Parameters.AddWithValue("@apellido",parentLast.Text);
                    comm1.Parameters.AddWithValue("@fecha_nacimiento",parentDate.Value.ToString());
                    comm1.Parameters.AddWithValue("@email",parentEmail.Text);
                    comm1.Parameters.AddWithValue("@direccion",parentLoc.Text);
                    comm1.Parameters.AddWithValue("@telefono",parentPhone.Text);
                    comm1.ExecuteNonQuery();
                    MessageBox.Show("Se ha registrado el tutor: "+ parentName.Text+" "+parentLast.Text+" cedula "+parentRNC.Text);
                    clear("t");
                    
                    con.Close();
                }
            } catch (Exception es)
            {
                MessageBox.Show("Error:\n" + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }
        //Works
        private void parentModify_Click(object sender, EventArgs e)
        {
                    String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                    SqlConnection con = new SqlConnection(connection);
                    string updateQuery = "UPDATE tutor SET nombre = @nombre, apellido = @apellido, fecha_nacimiento = @fecha_nacimiento, email = @email, direccion = @direccion, telefono = @telefono WHERE cedula = @RNC";
                    SqlCommand comm1 = new SqlCommand(updateQuery,con);
                    try{
                    if(fieldsMissing("t") == true)
                    {
                    MessageBox.Show("Porfavor, llenar los campos vacios");
                    }
                    else{
                        con.Open();
                        comm1.Parameters.AddWithValue("@RNC",parentRNC.Text);
                        comm1.Parameters.AddWithValue("@nombre",parentName.Text);
                        comm1.Parameters.AddWithValue("@apellido",parentLast.Text);
                        comm1.Parameters.AddWithValue("@fecha_nacimiento",parentDate.Value.ToString());
                        comm1.Parameters.AddWithValue("@email",parentEmail.Text);
                        comm1.Parameters.AddWithValue("@direccion",parentLoc.Text);
                        comm1.Parameters.AddWithValue("@telefono",parentPhone.Text);
                        comm1.ExecuteNonQuery();
                    MessageBox.Show("Se han modificado los datos con exito");
                    clear("t");
                    con.Close();
                    }
                    }catch(Exception es)
                    {
                       MessageBox.Show("Error: " + es + " \n Porfavor contacte al tecnico de informatica del area");
                    }
        }
        //Works
        private void parentRemove_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string username = parentRNC.Text;
            string usernameCheck = "";
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from tutor where cedula = @RNC";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@RNC", parentRNC.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usernameCheck = reader["cedula"].ToString();
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
                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    string insertQuery = "Delete from tutor where cedula = @cedula";
                    SqlCommand comm1 = new SqlCommand(insertQuery,con);
                    comm1.Parameters.AddWithValue("@cedula",parentRNC.Text);
                    comm1.ExecuteNonQuery();
                    MessageBox.Show("Se ha eliminado el tutor cedula "+parentRNC.Text);
                    clear("t");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("El tutor no existe, porfavor verifique la cedula nuevamente");
                }
            } catch (Exception es)
            {
                MessageBox.Show("Error:\n" + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        //
        //      ESTUDIANTE
        //
        private void studentIdSearch_Click(object sender, EventArgs e)
        {
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from estudiante where matricula = @matricula";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@matricula", Convert.ToInt32(studentID.Text));
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            studentID.Text = reader["matricula"].ToString();
                            studentName.Text = reader["nombre"].ToString();
                            studentLast.Text = reader["apellido"].ToString();
                            studentDate.Text = Convert.ToDateTime(reader["fecha_nacimiento"]).ToString();
                            studentParentID.Enabled = false;
                            studentParentID.Text = reader["id_tutor"].ToString();
                            studentGrade.Text = reader["grado"].ToString();
                            if(reader["sexo"]== "M")
                            {
                                studentSexF.Checked = true;
                                studentSexM.Enabled = false;
                                studentSexF.Enabled = false;
                            }
                            else
                            {
                                studentSexM.Checked = true;
                                studentSexF.Enabled = false;
                                studentSexM.Enabled = false;
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
        }
        //Works
        private void studentSexM_CheckedChanged(object sender, EventArgs e)
        {
            if (studentSexM.Checked) studentSexF.Checked = false;
        }
        //Works
        private void studentSexF_CheckedChanged(object sender, EventArgs e)
        {
            if (studentSexF.Checked) studentSexM.Checked = false;
        }
        //Works
        private void studentRegister_Click(object sender, EventArgs e)
        {
            int counter = 0;
            bool parentExists = false;
            string username = studentID.Text;
            string usernameCheck = "";
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from estudiante where matricula = @matricula";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@matricula", studentID.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usernameCheck = reader["matricula"].ToString();
                            if (username == usernameCheck)
                            {
                                counter++;
                            }
                        }
                    }
                }
                con.Close();

                findQuery = "SELECT * from tutor where cedula = @RNC";
                comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@RNC", studentParentID.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (studentParentID.Text == reader["cedula"].ToString())
                            {
                                parentExists = true;
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
                    MessageBox.Show("El estudiante ya existe, porfavor cambie el estudiante nuevamente para poder completar el registro");
                }
                else if (!parentExists)
                {
                    MessageBox.Show("El tutor no existe, porfavor cambie la cedula nuevamente para poder completar el registro");
                }
                else
                {
                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    string insertQuery = "insert into estudiante(matricula, nombre, apellido, sexo, fecha_nacimiento, grado, id_tutor) values (@matricula, @nombre, @apellido, @sexo, @fecha_nacimiento, @grado, @tutor)";
                    SqlCommand comm1 = new SqlCommand(insertQuery,con);
                    comm1.Parameters.AddWithValue("@matricula",studentID.Text);
                    comm1.Parameters.AddWithValue("@nombre",studentName.Text);
                    comm1.Parameters.AddWithValue("@apellido",studentLast.Text);
                    comm1.Parameters.AddWithValue("@tutor",studentParentID.Text);
                    comm1.Parameters.AddWithValue("@fecha_nacimiento",studentDate.Value.ToString());
                    if(studentSexF.Checked == true)
                    {
                        comm1.Parameters.AddWithValue("@sexo","F");
                    }
                    else{
                        comm1.Parameters.AddWithValue("@sexo","M");
                    }
                    comm1.Parameters.AddWithValue("@grado",studentGrade.Text);
                    comm1.ExecuteScalar();
                    MessageBox.Show("Se ha registrado el estudiante: "+ studentName.Text+" "+studentLast.Text+" matricula "+studentID.Text);
                    clear("s");
                    
                    con.Close();
                }
            } catch (Exception es)
            {
                MessageBox.Show("Error:\n" + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        private void studentModify_Click(object sender, EventArgs e)
        {
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            string updateQuery = "UPDATE estudiante SET nombre = @nombre, apellido = @apellido, fecha_nacimiento = @fecha_nacimiento ,grado = @grado WHERE matricula = @matricula";
            SqlCommand comm1 = new SqlCommand(updateQuery,con);
            try{
                if(fieldsMissing("s") == true)
                {
                    MessageBox.Show("Porfavor, llenar los campos vacios");
                }
                else{
                        con.Open();
                        comm1.Parameters.AddWithValue("@nombre",studentName.Text);
                        comm1.Parameters.AddWithValue("@apellido",studentLast.Text);
                        comm1.Parameters.AddWithValue("@fecha_nacimiento",studentDate.Value.ToString());
                        comm1.Parameters.AddWithValue("@grado",studentGrade.Text);
                        comm1.Parameters.AddWithValue("@matricula",studentID.Text);
                        comm1.ExecuteNonQuery();
                        MessageBox.Show("Se han modificado los datos con exito");
                        clear("s");
                        con.Close();
                    }
            }catch(Exception es)
            {
                MessageBox.Show("Error: " + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }
        //Works
        private void studentRemove_Click(object sender, EventArgs e)
        {
            int counter = 0;
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from estudiante where matricula = @matricula";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@matricula", studentID.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (studentID.Text == reader["matricula"].ToString())
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
                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    string deleteQuery = "Delete from estudiante where matricula = @matricula";
                    SqlCommand comm1 = new SqlCommand(deleteQuery,con);
                    comm1.Parameters.AddWithValue("@matricula",studentID.Text);
                    comm1.ExecuteNonQuery();
                    MessageBox.Show("Se ha eliminado el estudiante matricula: "+studentID.Text);
                    clear("s");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("El estudiante no existe, porfavor verifique la matricula nuevamente");
                }
            } catch (Exception es)
            {
                MessageBox.Show("Error:\n" + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        //
        //      PROFESOR
        //
        private void profIdSearch_Click(object sender, EventArgs e)
        {
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from profesor where matricula = @matricula";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@matricula", Convert.ToInt32(profID.Text));
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            profID.Text = reader["matricula"].ToString();
                            profName.Text = reader["nombre"].ToString();
                            profLast.Text = reader["apellido"].ToString();
                            profEmail.Text = reader["email"].ToString();
                            profPhone.Text = reader["telefono"].ToString();
                            profDate.Text = Convert.ToDateTime(reader["fecha_nacimiento"]).ToString();
                        }
                    }
                }
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("Error: " + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        private void profRegister_Click(object sender, EventArgs e)
        {
            int counter = 0;
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from profesor where matricula = @matricula";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@matricula", profID.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (profID.Text == reader["matricula"].ToString())
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
                    MessageBox.Show("El profesor ya existe, porfavor cambie el profesor nuevamente para poder completar el registro");
                }
                else
                {
                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    string insertQuery = "insert into profesor(matricula, nombre, apellido, email, telefono, fecha_nacimiento) values (@matricula, @nombre, @apellido, @email, @telefono, @fecha_nacimiento)";
                    SqlCommand comm1 = new SqlCommand(insertQuery,con);
                    comm1.Parameters.AddWithValue("@matricula",profID.Text);
                    comm1.Parameters.AddWithValue("@nombre",profName.Text);
                    comm1.Parameters.AddWithValue("@apellido",profLast.Text);
                    comm1.Parameters.AddWithValue("@email",profEmail.Text);
                    comm1.Parameters.AddWithValue("@telefono",profPhone.Text);
                    comm1.Parameters.AddWithValue("@fecha_nacimiento",profDate.Value.ToString());
                    comm1.ExecuteScalar();
                    MessageBox.Show("Se ha registrado el profesor: "+ profName.Text+" "+profLast.Text+", matricula: "+profID.Text);
                    clear("s");
                    
                    con.Close();
                }
            } catch (Exception es)
            {
                MessageBox.Show("Error:\n" + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        private void profModify_Click(object sender, EventArgs e)
        {
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            string updateQuery = "UPDATE profesor SET nombre = @nombre, apellido = @apellido, fecha_nacimiento = @fecha_nacimiento, email = @email, telefono = @phone WHERE matricula = @matricula";
            SqlCommand comm1 = new SqlCommand(updateQuery,con);
            try{
                if(fieldsMissing("p") == true)
                {
                    MessageBox.Show("Porfavor, llenar los campos vacios");
                }
                else{
                        con.Open();
                        comm1.Parameters.AddWithValue("@matricula",profID.Text);
                        comm1.Parameters.AddWithValue("@nombre",profName.Text);
                        comm1.Parameters.AddWithValue("@apellido",profLast.Text);
                        comm1.Parameters.AddWithValue("@phone",profPhone.Text);
                        comm1.Parameters.AddWithValue("@fecha_nacimiento",profDate.Value.ToString());
                        comm1.Parameters.AddWithValue("@email",profEmail.Text);
                        comm1.ExecuteNonQuery();
                        MessageBox.Show("Se han modificado los datos con exito");
                        clear("s");
                        con.Close();
                    }
            }catch(Exception es)
            {
                MessageBox.Show("Error: " + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        private void profRemove_Click(object sender, EventArgs e)
        {
            int counter = 0;
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from profesor where matricula = @matricula";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@matricula", profID.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (profID.Text == reader["matricula"].ToString())
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
                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    string deleteQuery = "Delete from profesor where matricula = @matricula";
                    SqlCommand comm1 = new SqlCommand(deleteQuery, con);
                    comm1.Parameters.AddWithValue("@matricula", profID.Text);
                    comm1.ExecuteNonQuery();
                    MessageBox.Show("Se ha eliminado el profesor matricula: " + profID.Text);
                    clear("t");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("El profesor no existe, porfavor verifique la matricula nuevamente");
                }
            } catch (Exception es)
            {
                MessageBox.Show("Error:\n" + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        //
        //      CLASE
        //
        private void classIdSearch_Click(object sender, EventArgs e)
        {
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from clase where idClase = @idClase";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@idClase", classID.Text);
                TimeSpan xd;
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            classID.Text = reader["idClase"].ToString();
                            className.Text = reader["nombre_clase"].ToString();
                            ClassLoc.Text = reader["ubicacion"].ToString();
                            classDiaClase.Text = reader["dias_clase"].ToString();
                            xd = (TimeSpan)reader["horario"];
                            Horario.Text = xd.ToString();
                            ClassGrade.Text = reader["grado"].ToString();
                            classInscAlumn.Text = reader["alumnos_inscritos"].ToString();
                        }
                    }
                }
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("Error: " + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        private void classRegister_Click(object sender, EventArgs e)
        {
            int counter = 0;
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from clase where idClase = @idClase";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@idClase", classID.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (classID.Text == reader["idClase"].ToString())
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
                    MessageBox.Show("La clase ya existe, por favor cambie la clase nuevamente para poder completar el registro");
                }
                else
                {
                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    string insertQuery = "insert into clase(idClase, nombre_clase, horario, dias_clase, ubicacion, grado, alumnos_inscritos) values (@idClase, @nombre, @horario, @dias, @ubicacion, @grado, @inscritos)";
                    SqlCommand comm1 = new SqlCommand(insertQuery,con);
                    comm1.Parameters.AddWithValue("@idClase",classID.Text);
                    comm1.Parameters.AddWithValue("@nombre",className.Text);
                    comm1.Parameters.AddWithValue("@horario",Horario.Text);
                    comm1.Parameters.AddWithValue("@dias",classDiaClase.Text);
                    comm1.Parameters.AddWithValue("@grado",ClassGrade.Text);
                    comm1.Parameters.AddWithValue("@ubicacion",ClassLoc.Text);
                    comm1.Parameters.AddWithValue("@inscritos",classInscAlumn.Text);
                    comm1.ExecuteScalar();
                    MessageBox.Show("Se ha registrado la clase: "+ classID.Text);
                    clear("s");
                    
                    con.Close();
                }
            } catch (Exception es)
            {
                MessageBox.Show("Error:\n" + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        private void classModify_Click(object sender, EventArgs e)
        {
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            string updateQuery = "UPDATE clase SET nombre_clase = @nombre, ubicacion = @location, horario = @horario, grado = @grado, alumnos_inscritos = @alumnos WHERE idClase = @classID";
            SqlCommand comm1 = new SqlCommand(updateQuery,con);
            try{
                if(fieldsMissing("c") == true)
                {
                    MessageBox.Show("Porfavor, llenar los campos vacios");
                }
                else{
                        con.Open();
                        comm1.Parameters.AddWithValue("@classID",classID.Text);
                        comm1.Parameters.AddWithValue("@nombre",className.Text);
                        comm1.Parameters.AddWithValue("@location",ClassLoc.Text);
                        comm1.Parameters.AddWithValue("@horario",Horario.Value.ToString());
                        comm1.Parameters.AddWithValue("@grado",ClassGrade.Text);
                        comm1.Parameters.AddWithValue("@alumnos",classInscAlumn.Text);
                        comm1.ExecuteNonQuery();
                        MessageBox.Show("Se han modificado los datos con exito");
                        clear("s");
                        con.Close();
                    }
            }catch(Exception es)
            {
                MessageBox.Show("Error: " + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }
        

        private void classRemove_Click(object sender, EventArgs e)
        {
            int counter = 0;
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from clase where idClase = @classID";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@classID", classID.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (classID.Text == reader["idClase"].ToString())
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
                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    string deleteQuery = "Delete from clase where idClase = @classID";
                    SqlCommand comm1 = new SqlCommand(deleteQuery, con);
                    comm1.Parameters.AddWithValue("@classID", classID.Text);
                    comm1.ExecuteNonQuery();
                    MessageBox.Show("Se ha eliminado las clase ID: " + classID.Text);
                    clear("t");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("La clase no existe, porfavor verifique el ID nuevamente");
                }
            } catch (Exception es)
            {
                MessageBox.Show("Error:\n" + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        //
        //      FACTURA
        //
        private void factGenerate_Click(object sender, EventArgs e)
        {
            bool tutorRegistered = false;
            String connection = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connection);
                string findQuery = "SELECT * from tutor where cedula = @cedula";
                SqlCommand comm = new SqlCommand(findQuery, con);
                comm.Parameters.AddWithValue("@cedula", fact_cedula_tutor.Text);
                con.Open();
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (fact_cedula_tutor.Text == reader["cedula"].ToString())
                            {
                                tutorRegistered = true;
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
                if (tutorRegistered)
                {
                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    string insertQuery = "exec efectuar_factura @importe = @monto, @cedula_tutor = @RNC";
                    SqlCommand comm1 = new SqlCommand(insertQuery, con);
                    comm1.Parameters.AddWithValue("@monto", factMonto.Text);
                    comm1.Parameters.AddWithValue("@RNC", fact_cedula_tutor.Text);
                    comm1.ExecuteScalar();
                    MessageBox.Show("Se ha generado la factura: " + classID.Text);
                    clear("f");

                    con.Close();
                }
                else
                {
                    MessageBox.Show("El tutor designado no existe, por favor revise la cedula introducida");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Error: " + es + " \n Porfavor contacte al tecnico de informatica del area");
            }
        }

        private void clear(string name)
        {
            if(name =="t")
            {
            //For Parent panel
                parentRNC.Text = "";
                parentName.Text = "";
                parentLast.Text = "";
                parentDate.Text = "";
                parentEmail.Text = "";
                parentPhone.Text = "";
                parentLoc.Text = "";
            }
            else if(name == "s")
            {
            //For Student panel
                studentID.Text = "";
                studentName.Text = "";
                studentLast.Text = "";
                studentDate.Text = "";
                studentSexF.Checked = false;
                studentSexM.Checked = false;
                studentGrade.Text = "";
                studentParentID.Text = "";
                studentParentID.Enabled = true;
            }
            else if(name =="p")
            {
                //For teachers panel
                profID.Text = "";
                profName.Text = "";
                profLast.Text = "";
                profPhone.Text = "";
                profDate.Text = "";
                profEmail.Text = "";
            }
            else if(name=="c")
            {
                //For class panel 
                classID.Text = "";
                className.Text = "";
                Horario.Text = "";
                classDiaClase.Text = "";
                ClassGrade.Text = "";
                ClassLoc.Text = "";
                classInscAlumn.Text = "";
            }
            else if (name == "f")
            {
                factMonto.Text = "";
                fact_cedula_tutor.Text = "";
            }
        }

        private bool fieldsMissing(string name)
        {
            if (name == "t")
            {
                //For Parent panel
                return parentRNC.Text == "" || parentName.Text == "" || parentLast.Text == "" || parentDate.Text == "" || parentEmail.Text == "" || parentPhone.Text == "" || parentLoc.Text == "";
            
            }
            else if (name == "s")
            {
                //For Student panel
                return studentID.Text == "" || studentName.Text == "" || studentLast.Text == "" || studentDate.Text == "" || studentGrade.Text == "" || studentParentID.Text == "" || (!studentSexM.Checked && !studentSexF.Checked);
                
            }
            else if (name == "p")
            {
                //For teachers panel
                return profID.Text == "" || profName.Text == "" || profLast.Text == "" || profPhone.Text == "" || profDate.Text == "" || profEmail.Text == "";
                
            }
            else if (name == "c")
            {
                //For class panel 
                return classID.Text == "" || className.Text == "" ||Horario.Text == "" || classDiaClase.Text == "" || ClassGrade.Text == "" || ClassLoc.Text == "" || classInscAlumn.Text == "";
            }
            else if (name == "f")
            {
                //For receipt panel
                return factMonto.Text == "" || fact_cedula_tutor.Text == "";
            }
            return true;
        }

        private void classTime_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void classGrado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void profPanel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from profesor";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

            conn.Open();

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            adapter.Fill(dt);

            profTable.DataSource = dt;
            profTable.Refresh();

            conn.Close();
        }

        private void dataGridTeacher_Click(object sender, EventArgs e)
        {
            string query = "select * from tutor";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

            conn.Open();

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            adapter.Fill(dt);

            parentTable.DataSource = dt;
            parentTable.Refresh();

            conn.Close();
        }

        private void dataGridStudent_Click(object sender, EventArgs e)
        {
            studentSexM.Enabled = true;
            studentSexF.Enabled = true;
            string query = "select * from estudiante";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

            conn.Open();

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            adapter.Fill(dt);

            studentTable.DataSource = dt;
            studentTable.Refresh();

            conn.Close();
        }

        private void dataGridClass_Click(object sender, EventArgs e)
        {
            string query = "select * from clase";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

            conn.Open();

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            adapter.Fill(dt);

            classTable.DataSource = dt;
            classTable.Refresh();

            conn.Close();
        }

        private void dataGridProf_Click(object sender, EventArgs e)
        {
            string query = "select * from profesor";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

            conn.Open();

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            adapter.Fill(dt);

            profTable.DataSource = dt;
            profTable.Refresh();

            conn.Close();
        }
    }
    
}

