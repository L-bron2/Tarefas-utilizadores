using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gestor_de_tarefas
{
    public partial class criarConta : Form
    {
        BDconection bd = new BDconection();
        public criarConta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nomeUsuario = textBox1.Text.Trim();
            string senha = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomeUsuario) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Precisa de um nome de utilizador e palavra passe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gera hash da senha
            string hashSenha = criarHash.GerarHash(senha);

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();

                    // Verifica se o usuário já existe
                    string checkSql = "SELECT COUNT(*) FROM utilizadores WHERE nome_utilizador = @nome";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@nome", nomeUsuario);
                        long count = (long)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Nome de usuário já existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Insere novo usuário (sempre como operador, ainda tenho que fazer com que o adm possa fazer outras contas serem adm)
                    string sql = @"
                        INSERT INTO utilizadores (nome_utilizador, senha_hash, id_perfil, Ativo)
                        VALUES (@nome, @senha, 3, 'ativo')";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nomeUsuario);
                        cmd.Parameters.AddWithValue("@senha", hashSenha);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Conta criada!! Faça login.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar conta: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }
    }

}
   

