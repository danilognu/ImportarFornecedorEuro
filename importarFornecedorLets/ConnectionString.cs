using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importarFornecedorLets
{
    class ConnectionString
    {
       // public String connectionString = "Provider=SQLOLEDB;Data Source=srvaqabd;Initial Catalog=ETOOLS_LETS;User ID=euroitlogin;password=Admin123#";

        public static String connectionString = "Server=srvaqabd" +
                                        ";Database=etools_lets" +
                                        ";Uid=euroitlogin" +
                                        ";Pwd=Admin123#" + ";";
    }
}
