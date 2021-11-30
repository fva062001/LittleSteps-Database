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
            String connection = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginScreenForm());
            
        }

    }
}
