using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gestor_de_tarefas
{
    public partial class Tarefa : Form
    {
        BDconection bd = new BDconection();

        public Tarefa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // tamnho da janela fixo
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // opções de estado
            Estado.Items.Clear();
            string[] opcao = { "Pendente", "Concluido" };
            Estado.Items.AddRange(opcao);

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();
                }

                // Mostra as tarefas ao abrir o formulário
                AtualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar: " + ex.Message);
            }

            // Mostra o utilizador atual
            utilizador.Text = $"Utilizador: {SessaoUtilizador.Nome} ({SessaoUtilizador.Perfil})";

            // permissões de acordo com o perfil
            switch (SessaoUtilizador.Perfil)
            {
                case "Admin":
                    Adicionar.Enabled = true;
                    Gerir.Enabled = true;
                    contas.Enabled = true;
                    break;

                case "Gestor":
                    Adicionar.Enabled = true;
                    Gerir.Enabled = false;
                    contas.Enabled = false;
                    break;

                case "Operador":
                    Adicionar.Enabled = true;
                    Gerir.Enabled = false;
                    contas.Enabled = false;
                    break;
            }
        }

        //BTN adicionar tarefa
        private void Adicionar_Click(object sender, EventArgs e)
        {
            string titulo = Titulo.Text.Trim();
            string descricao = string.IsNullOrWhiteSpace(Descricao.Text) ? "(Sem descrição)" : Descricao.Text.Trim();
            string estado = string.IsNullOrWhiteSpace(Estado.Text) ? "Pendente" : Estado.Text.Trim();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                MessageBox.Show("A tarefa precisa de um título.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = bd.GetConnection())
                {
                    conn.Open();

                    string sql = "INSERT INTO task (titulo, descricao, estado) VALUES (@titulo, @descricao, @estado)";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@titulo", titulo);
                        cmd.Parameters.AddWithValue("@descricao", descricao);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Tarefa adicionada com sucesso!");
                LimparCampos();
                AtualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar tarefa: " + ex.Message);
            }
        }

        // BTN gerir tarefas (apenas Admin)
        private void Gerir_Click(object sender, EventArgs e)
        {
            if (SessaoUtilizador.Perfil != "Admin")
            {
                MessageBox.Show("Acesso restrito ao administrador!", "Permissão negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Gerir gerir1 = new Gerir();
            gerir1.ShowDialog();
        }

        // BTN sair
        private void Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Atuliza a lista de tarefas
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

                            lstTarefas.Items.Add($"ID:[{id}]  Título: {titulo}  |  Descrição: {descricao}  |  Estado: {estado}");
                        }
                    }
                }

                if (lstTarefas.Items.Count == 0)
                    lstTarefas.Items.Add("Nenhuma tarefa adicionada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar tarefas: " + ex.Message);
            }
        }

        //limpar campos das texBos
        private void LimparCampos()
        {
            Titulo.Clear();
            Descricao.Clear();
            Estado.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMmanager adm = new ADMmanager();
            adm.ShowDialog();
        }
    }
}
