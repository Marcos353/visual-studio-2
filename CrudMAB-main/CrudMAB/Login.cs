using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// importa o classe do banco
using MySql.Data.MySqlClient;

namespace CrudMab
{
    public partial class Login : Form
    {
        //  1º passo
        private string url = "server=localhost;database=proj_mabc;uid=root;pwd= ";

        // 2º objeto de conxão
        private MySqlConnection conexao;

        //4º string para fazer quey(manipulação) no bando
        // (insert, delet, update, select)
        private string sql;

        // 5° passo preparando o comando para ser executado no servidor
        private MySqlCommand comando;

        public Login()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
           

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //para vc parece mysql, porém e uma string para o c#
            sql = "select * from tb_login " +
                  "where usuario_log = '" + txtLogin.Text + "' and " +
                  " senha_log='" + txtSenha.Text + "' ";

            // MessageBox.Show(sql);

            //há três comando para executar no mysql com c#
            // 1º ExecuteNoQuery() -usando para os comandos sql(insert, update, delete)
            // 2º ExecuteReader() -usando no comando sql(select), retorna o valores lidos;
            // 3º ExecuteScalar() -retorna unico valores

            //5º passo preparar o comando
            comando = new MySqlCommand(sql, conexao);

            // 6º passo 
            // executa e traz os registro de usuario procurado
            MySqlDataReader tabelaRegistro = comando.ExecuteReader();

            // ler os dados carregando do mysql
            // estarei usando mais tarde, para lembrar ...
            tabelaRegistro.Read();
            //MessageBox.Show(tabelaRegistro["ID_LOG"].ToString());
            //MessageBox.Show(tabelaRegistro["USUARIO_LOG"].ToString());
            //MessageBox.Show(tabelaRegistro["SENHA_LOG"].ToString());

            if (tabelaRegistro.HasRows)
            {
                // MessageBox.Show("permissão);
                // 8° direcionar para o formulario tela(menu)
                // fazer ir para o formulario de tela
                MenuP frmMenu = new MenuP();
                this.Hide();
                // fechar o conexão
                conexao.Close();
                frmMenu.ShowDialog();

            }
            else
            {
                MessageBox.Show("Acesso negado");
                txtLogin.Clear();
                txtSenha.Clear();
                txtLogin.Focus();
            }
            // 7° toda vez que mandar executar um mysqldatareader(), temos que f
            tabelaRegistro.Close();

            // direcionar para tela menu
            // this.Hide();

            //MenuP frmM = new MenuP();
            // frmM.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                // 3º passo
                // fazer a configuração para abrir o conexão ao servidor
                conexao = new MySqlConnection(url);
                // abre a conexão
                conexao.Open();
            }
            catch (Exception erro)   {
                MessageBox.Show(erro.Message + "vai no rh");
            }

        }
    }
}
