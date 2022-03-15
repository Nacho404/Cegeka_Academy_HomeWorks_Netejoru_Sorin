using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Text;

namespace HomeWork_02_Web_Services.DataBaseConnection
{
    public class DBConnection
    {
        public OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\Cegeka Academy\Teme\Tema[02] - [Web Services]\HomeWork_02_Web_Services\HomeWork_02_Web_Services\DB_file.accdb'");

    }
}
