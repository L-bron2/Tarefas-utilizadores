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
    public partial class ADMmanager : Form
    {

        BDconection bd = new BDconection();
        public ADMmanager()
        {
            InitializeComponent();
        }

        private void ADMmanager_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            lstUsuarios.Items.Clear();

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();
                    string sql = @"
                        SELECT u.id, u.nome_utilizador, p.nome AS perfil, u.Ativo
                        FROM utilizadores u
                        JOIN perfil p ON u.id_perfil = p.id
                        ORDER BY u.id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0;
                            string nome = reader["nome_utilizador"]?.ToString() ?? "";
                            string perfil = reader["perfil"]?.ToString() ?? "";
                            string ativo = reader["Ativo"]?.ToString() ?? "";

                            lstUsuarios.Items.Add($"{id} - {nome} | Perfil: {perfil} | Ativo: {ativo}");
                        }
                    }
                }

                if (lstUsuarios.Items.Count == 0)
                    lstUsuarios.Items.Add("Nenhum usuário cadastrado.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar utilizadores: " + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Informe o ID do usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox1.Text.Trim(), out int idUsuario))
            {
                MessageBox.Show("ID inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Determina o id do perfil
            int idPerfil;
            if (ADM.Checked) idPerfil = 1;
            else if (Gestor.Checked) idPerfil = 2;
            else if (Operador.Checked) idPerfil = 3;
            else
            {
                MessageBox.Show("Selecione um perfil.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determina o status
            string status;
            if (Ativo.Checked) status = "ativo";
            else if (Inativo.Checked) status = "inativo";
            else
            {
                MessageBox.Show("Selecione um status.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE utilizadores SET id_perfil = @perfil, Ativo = @status WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@perfil", idPerfil);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@id", idUsuario);

                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Conta atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AtualizarLista();
                            textBox1.Clear();
                            ADM.Checked = Gestor.Checked = Operador.Checked = false;
                            Ativo.Checked = Inativo.Checked = false;
                        }
                        else
                        {
                            MessageBox.Show("Nenhum usuário encontrado com esse ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar conta: " + ex.Message);
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tarefa tarefa1 = new Tarefa();
            tarefa1.ShowDialog();
        }
    }
}
