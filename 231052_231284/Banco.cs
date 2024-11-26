using System;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace _231052_231284
{
    public class Banco
    {
        // Criando as variáveis publicas para conexão e consulta serão usadas em todo o projeto
        // connection responsável pela conexão com MySQL
        public static MySqlConnection Conexao;
        // Command responsável pelas instruções SQL a serem executadas
        public static MySqlCommand Comando;
        // Adapter responsável por inserir dados em um dataTable
        public static MySqlDataAdapter Adaptador;
        // DataTable responsável por ligar o banco em controles com a propriedade DataSource
        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                // Estabelece os parâmetros para a conexão com o banco
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                // Abre a conexao com o banco de dados
                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {
                // Fecha a conexão com o banco de dados
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                //Chama a funcão para abertura de conexão com o banco
                AbrirConexao();

                //Informa a instrução SQL
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);
                // Executa a Query no MySQL (Raio de Workbanch)
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("Create TABLE IF NOT EXISTS Cidades " +
                                           "(id integer auto_increment primary key, " +
                                           "nome char(40)," +
                                           "uf char(02))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("Create TABLE IF NOT EXISTS Marcas " +
                                           "(id integer auto_increment primary key, " +
                                           "marca char(20))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("Create TABLE IF NOT EXISTS Categorias " +
                                           "(id integer auto_increment primary key, " +
                                           "categoria char(20))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("Create TABLE IF NOT EXISTS Clientes " +
                                           "(Id integer auto_increment primary key, " +
                                           "Nome char(20)), " +
                                           "idCidade integer, " +
                                           "dataNasc date, " +
                                           "renda decimal(10,2), " +
                                           "cpf char(14), " +
                                           "foto varchar(100), " +
                                           "venda boolean)" , Conexao);

                Comando.ExecuteNonQuery();

                // Chama a função para fechar a conexão com o banco
                FecharConexao();
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMenu_Load (object sender, EventArgs e)
        {
            Banco.CriarBanco();
        }
    }
}
