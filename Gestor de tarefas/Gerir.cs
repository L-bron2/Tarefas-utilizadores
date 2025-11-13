using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gestor_de_tarefas
{
    public partial class Gerir : Form
    {
        BDconection bd = new BDconection();

        public Gerir()
        {
            InitializeComponent();
        }

        private void Gerir_Load(object sender, EventArgs e)
        {
            if (SessaoUtilizador.Perfil != "Admin")
            {
                MessageBox.Show("Acesso restrito apenas ao administrador!", "Permissão negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();
                }

                // Mostra as tarefas quando abre o formulário
                AtualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar: " + ex.Message);
            }

            Estado.Items.Clear();
            string[] opcao = { "Pendente", "Concluido" };
            Estado.Items.AddRange(opcao);
        }

        //BTN remover
        private void Remover_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ID.Text))
            {
                MessageBox.Show("Por favor, insira o ID da tarefa a ser removida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id;
            if (!int.TryParse(ID.Text.Trim(), out id))
            {
                MessageBox.Show("ID inválido. Por favor, insira um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM task WHERE id = @id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tarefa removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AtualizarLista();
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma tarefa encontrada com esse ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao a remover tarefa: " + ex.Message);
            }
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
            Tarefa tarefa1 = new Tarefa();
            tarefa1.ShowDialog();
        }
        private void AtualizarLista()
        {
            lstTarefas.Items.Clear();
            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM task ORDER BY id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string titulo = reader["titulo"]?.ToString() ?? "";
                            string descricao = reader["descricao"]?.ToString() ?? "";
                            string estado = reader["estado"]?.ToString() ?? "";

                            lstTarefas.Items.Add($"ID:[{id}] Título: {titulo} | Descrição: {descricao} | Estado: {estado}");
                        }
                    }
                }
                if (lstTarefas.Items.Count == 0)
                    lstTarefas.Items.Add("Nenhuma foi tarefa adicionada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao as listar tarefas: " + ex.Message);
            }
        }


        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ID.Text))
            {
                MessageBox.Show("Por favor, insira o ID da tarefa que quer procurar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(ID.Text.Trim(), out int id))
            {
                MessageBox.Show("ID inválido. Por favor, insira um ID válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM task WHERE id = @id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string titulo = reader["titulo"]?.ToString() ?? "";
                                string descricao = reader["descricao"]?.ToString() ?? "";
                                string estado = reader["estado"]?.ToString() ?? "";

                                MessageBox.Show(
                                    $"Tarefa encontrada:\n\nTítulo: {titulo}\nDescrição: {descricao}\nEstado: {estado}",
                                    "Resultado da pesquisa",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                            else
                            {
                                MessageBox.Show("Nenhuma tarefa encontrada com esse ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao procurar tarefa: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Atualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ID.Text))
            {
                MessageBox.Show("Por favor, selecione o ID da tarefa que quer atualizar o estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(ID.Text.Trim(), out int id))
            {
                MessageBox.Show("ID inválido. Por favor, insira um ID válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Estado.Text))
            {
                MessageBox.Show("Selecione um estado para atualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string novoEstado = Estado.Text.Trim();

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE task SET estado = @estado WHERE id = @id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@estado", novoEstado);
                        cmd.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                            MessageBox.Show("Estado atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Nenhuma tarefa encontrada com esse ID.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        AtualizarLista();
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o estado da tarefa: " + ex.Message);
            }
        }


        private void LimparCampos()
        {
            ID.Clear();
            Estado.SelectedIndex = -1;
        }
    }
}
