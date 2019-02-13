using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace importarFornecedorLets
{
    class DataBaseUtil
    {

        public int BuscaCNPJBase(string cnpj)
        {
            int contaForne;

            using (SqlConnection conexao = new SqlConnection(ConnectionString.connectionString))
            {
                String sqlBusca = "SELECT COUNT(*) CONTA_FORNECEDOR FROM T008_FORNECEDOR WHERE A008_CNPJ = '"+ cnpj + "'";

                conexao.Open();
                SqlCommand cmd = new SqlCommand(sqlBusca, conexao);
                SqlDataReader resultBusca = cmd.ExecuteReader();

                while (resultBusca.Read())
                {
                    contaForne = Convert.ToInt32(resultBusca.GetValue(0).ToString());
                    return contaForne;
                }
            }
            return 0;

        }

        public void CadastrarFornecedor(Fornecedor fornecedor, int IdTemp)
        {

            using (SqlConnection conexao = new SqlConnection(ConnectionString.connectionString))
            {
                int _IdFornecedor;
                String sqlBuscaId = "select max(A008_cd_fornecedor)+1 from T008_FORNECEDOR";

                conexao.Open();
                SqlCommand cmd = new SqlCommand(sqlBuscaId, conexao);
                SqlDataReader resultBusca = cmd.ExecuteReader();

                while (resultBusca.Read())
                {
                    _IdFornecedor = Convert.ToInt32(resultBusca.GetValue(0).ToString());

                    String sqlInsert = "INSERT INTO T008_FORNECEDOR " +
                                   " (A008_cd_fornecedor" +
                                   ",A008_nome_fornecedor" +
                                   ",A008_razao_social" +
                                   ",A008_CNPJ" +
                                   ",A008_endereco" +
                                   ",A008_bairro" +
                                   ",A008_email" +
                                   ",A008_cod_ticketlog" +
                                   ",A008_DDD_fone" +
                                   ",A008_fone" +
                                   ",A047_cd_cidade" +
                                   ",A008_status" +
                                   ",A019_cd_usu_inc" +
                                   ",A019_cd_usu_ult_alt" +
                                   ",A008_sem_cnpj_cpf) " +
                                   "VALUES (" +
                                   "" + _IdFornecedor + "" +
                                   ",'" + fornecedor.nome + "'" +
                                   ",'" + fornecedor.razaoSocial + "'" +
                                   ",'" + fornecedor.cnpj + "'" +
                                   ",'" + fornecedor.endereco + "'" +
                                   ",'" + fornecedor.bairro + "'" +
                                   ",'" + fornecedor.email + "'" +
                                   "," + fornecedor.cdTicket + "" +
                                   "," + fornecedor.ddd_telefone + "" +
                                   "," + fornecedor.telefone + "" +
                                   "," + fornecedor.cdCidadeEuro + "" +
                                   ",1" +
                                   ",1" +
                                   ",1" +
                                   ",1" +
                                   ")";

                    Console.WriteLine(sqlInsert);
                }
            }

        }

    }
}
