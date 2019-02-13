using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace importarFornecedorLets
{
    class Program
    {

        public static void Main(string[] args)
        {

            DataTable dataTable;
            AcessoExcel buscarDados = new AcessoExcel();
            DataBaseUtil dataBaseUtil = new DataBaseUtil();

            dataTable = buscarDados.BuscarDadosExcel();

            int loContaLinha = dataTable.Rows.Count;
            int IdTemp = 13139;

            for (int i = 0; i < loContaLinha; i++)
            {
                string _cnpj = dataTable.Rows[i][3].ToString();
                string _cnpjTratado = _cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "");
                int _contaFornecedorCad = dataBaseUtil.BuscaCNPJBase(_cnpjTratado);

                if (_contaFornecedorCad == 0)
                {
                    Fornecedor fornecedor = new Fornecedor();

                    fornecedor.nome = dataTable.Rows[i][1].ToString();
                    fornecedor.razaoSocial = dataTable.Rows[i][2].ToString();
                    fornecedor.cnpj = _cnpjTratado;
                    fornecedor.endereco = dataTable.Rows[i][4].ToString();
                    fornecedor.bairro = dataTable.Rows[i][5].ToString();
                    fornecedor.email = dataTable.Rows[i][10].ToString();
                    fornecedor.cdTicket = dataTable.Rows[i][0].ToString();
                    fornecedor.cdCidadeEuro = dataTable.Rows[i][6].ToString();

                    string _telefone = dataTable.Rows[i][9].ToString();
                    string[] words = _telefone.Split(' ');
                    fornecedor.ddd_telefone = words[0];
                    fornecedor.telefone = words[1].Replace("-", ""); ;

                    dataBaseUtil.CadastrarFornecedor(fornecedor, IdTemp);

                    Console.WriteLine(" ");
                    IdTemp++;
                }
            }

            Console.ReadKey();

        }






    }
}
