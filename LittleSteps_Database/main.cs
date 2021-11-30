using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LittleSteps_Database
{
    static class main
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
<<<<<<< Updated upstream
            String connection = "workstation id=littlesteps.mssql.somee.com;packet size=4096;user id=xSerafini_SQLLogin_1;pwd=45bgyu4oj1;data source=littlesteps.mssql.somee.com;persist security info=False;initial catalog=littlesteps";
=======
            String connection = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
>>>>>>> Stashed changes
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EmployeeForm());
            
        }








    }
}
