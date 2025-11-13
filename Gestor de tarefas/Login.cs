using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gestor_de_tarefas
{
    public partial class Login : Form
    {
        BDconection bd = new BDconection();

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text.Trim();
            string senha = textBox2.Text.Trim();
            string hashSenha = criarHash.GerarHash(senha);

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                    SELECT u.id, u.nome_utilizador, p.nome AS perfil
                    FROM utilizadores u
                    JOIN perfil p ON u.id_perfil = p.id
                    WHERE u.nome_utilizador = @nome 
                    AND u.senha_hash = @senha
                    AND u.ativo  = 'ativo'";


                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@senha", hashSenha);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // guarda os dados do utilizador
                                SessaoUtilizador.Id = reader.GetInt32("id");
                                SessaoUtilizador.Nome = reader.GetString("nome_utilizador");
                                SessaoUtilizador.Perfil = reader.GetString("perfil");

                                // abre o formulário principal
                                Tarefa tarefaForm = new Tarefa();
                                tarefaForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Nome ou senha incorretos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar a BD: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            criarConta criarContaForm = new criarConta();
            criarContaForm.Show();

        }
    }
}
