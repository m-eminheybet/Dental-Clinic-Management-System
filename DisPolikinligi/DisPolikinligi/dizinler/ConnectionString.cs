using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DisPolikinligi
{
    class ConnectionString
    {
        public SqlConnection GetCon()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\memin\Documents\DisPolikinligiDatabase.mdf;Integrated Security=True;Connect Timeout=30";
            return Con;
        }
    }
}
