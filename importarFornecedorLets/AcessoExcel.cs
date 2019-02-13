using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace importarFornecedorLets
{
    class AcessoExcel
    {
        public DataTable BuscarDadosExcel()
        {
            string aspas = "\"";
            String _Arquivo = @"C:\webservicos\util\importarFornecedorLets\importarFornecedorLets\excel\forne.xlsx";


            String Conexao = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + _Arquivo + ";" + "Extended Properties=" + aspas + "Excel 8.0;HDR=YES" + aspas;


            OleDbConnection Cn = new OleDbConnection();
            Cn.ConnectionString = Conexao;
            Cn.Open();
            object[] Restricoes = { null, null, null, "TABLE" };
            DataTable DTSchema = Cn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, Restricoes);
            if (DTSchema.Rows.Count > 0)
            {

                OleDbCommand Comando = new OleDbCommand("SELECT * FROM [Plan1$]", Cn);
                DataTable Dados = new DataTable();
                OleDbDataAdapter DA = new OleDbDataAdapter(Comando);
                try
                {
                    DA.Fill(Dados);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());

                }
                Cn.Close();

                return Dados;
            }

            return null;
        }
    }
}
