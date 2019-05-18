using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroBd
{
    public class Cadastro
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public String mensagem = "";
        public Cadastro(String nome, String telefone)
        {
            cmd.CommandText = "insert into pessoas (nome,telefone) values(@nome,@telefone)";

            cmd.Parameters.AddWithValue("@nome",nome);
            cmd.Parameters.AddWithValue("@telefone", telefone);

            try
            {
                cmd.Connection = conexao.conectar();
                cmd.ExecuteNonQuery();
                conexao.desconectar();

                this.mensagem = "Cadastrado com Sucesso!!!";

            }
            catch (SqlException e )
            {

                this.mensagem = "Erro banco de Dados";
            }
        }
    }
}
