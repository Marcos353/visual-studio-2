using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// referencia do mysql
using MySql.Data.MySqlClient;

namespace CrubMab
{
    public partial class cadastrar : Form
    {
        // 1° passo string com banco 
        //  1º passo
        private string url = "server=localhost;database=proj_mabc;uid=root;pwd= ";

        // 2º objeto de conxão
        private MySqlConnection conexao;

        //3º (insert, delet, update, select) 
        private string sql, idEst, sqluf;

        // 4° preparar o comando
        private MySqlCommand comando;

        MySqlDataReader tabelaRegistro;
        public cadastrar()
        {
            InitializeComponent();
           

        }

        private void cadastro_Load(object sender, EventArgs e)
        {
            try
            {
                // preciso fazer conexao com banco
                conexao = new MySqlConnection(url);
                conexao.Open();

                // 3° fazer a tabela do banco exibir os registro
                sqluf = "select * from tb_estado";

                // 4° preparar o comando
                comando = new MySqlCommand(sqluf, conexao);

                tabelaRegistro = comando.ExecuteReader();

                while (tabelaRegistro.Read())
                {
                    // MessageBox.Show(tabelaRegistro["nome_est"].ToString());
                    // adicionar item no combobox
                    CMBESTADO.Items.Add(tabelaRegistro["nome_est"].ToString());
                }
                tabelaRegistro.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro no servidor, procure o RH");
            }
        }

        private void sair(object sender, EventArgs e)
        {
        }

        private void BTCADASTRO_Click(object sender, EventArgs e)
        {
         
        }

        private void CMBESTADO_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
 
       
    }
}
