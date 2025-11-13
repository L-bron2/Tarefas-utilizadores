namespace Gestor_de_tarefas
{
    partial class Tarefa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Titulo = new TextBox();
            Descricao = new TextBox();
            Adicionar = new Button();
            Gerir = new Button();
            Sair = new Button();
            lstTarefas = new ListBox();
            Estado = new ComboBox();
            utilizador = new Label();
            contas = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(216, 9);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 33;
            label1.Text = "Tarefas";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 49);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "Titulo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 89);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 2;
            label3.Text = "Descrição";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(69, 129);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Estado";
            // 
            // Titulo
            // 
            Titulo.Location = new Point(117, 46);
            Titulo.Name = "Titulo";
            Titulo.Size = new Size(277, 23);
            Titulo.TabIndex = 5;
            Titulo.UseWaitCursor = true;
            // 
            // Descricao
            // 
            Descricao.Location = new Point(117, 86);
            Descricao.Name = "Descricao";
            Descricao.Size = new Size(277, 23);
            Descricao.TabIndex = 6;
            // 
            // Adicionar
            // 
            Adicionar.Location = new Point(36, 199);
            Adicionar.Name = "Adicionar";
            Adicionar.Size = new Size(75, 23);
            Adicionar.TabIndex = 8;
            Adicionar.Text = "Adicionar";
            Adicionar.UseVisualStyleBackColor = true;
            Adicionar.Click += Adicionar_Click;
            // 
            // Gerir
            // 
            Gerir.Location = new Point(132, 199);
            Gerir.Name = "Gerir";
            Gerir.Size = new Size(75, 23);
            Gerir.TabIndex = 10;
            Gerir.Text = "Gerir ";
            Gerir.UseVisualStyleBackColor = true;
            Gerir.Click += Gerir_Click;
            // 
            // Sair
            // 
            Sair.Location = new Point(345, 199);
            Sair.Name = "Sair";
            Sair.Size = new Size(75, 23);
            Sair.TabIndex = 11;
            Sair.Text = "Sair";
            Sair.UseVisualStyleBackColor = true;
            Sair.Click += Sair_Click;
            // 
            // lstTarefas
            // 
            lstTarefas.FormattingEnabled = true;
            lstTarefas.ItemHeight = 15;
            lstTarefas.Location = new Point(12, 243);
            lstTarefas.Name = "lstTarefas";
            lstTarefas.Size = new Size(458, 169);
            lstTarefas.TabIndex = 34;
            // 
            // Estado
            // 
            Estado.FormattingEnabled = true;
            Estado.Items.AddRange(new object[] { "pendente", "concluido" });
            Estado.Location = new Point(117, 126);
            Estado.Name = "Estado";
            Estado.Size = new Size(277, 23);
            Estado.TabIndex = 35;
            // 
            // utilizador
            // 
            utilizador.AutoSize = true;
            utilizador.Location = new Point(10, 22);
            utilizador.Name = "utilizador";
            utilizador.Size = new Size(38, 15);
            utilizador.TabIndex = 36;
            utilizador.Text = "label5";
            // 
            // contas
            // 
            contas.Location = new Point(233, 199);
            contas.Name = "contas";
            contas.Size = new Size(75, 23);
            contas.TabIndex = 37;
            contas.Text = "Contas";
            contas.UseVisualStyleBackColor = true;
            contas.Click += button1_Click;
            // 
            // Tarefa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 420);
            Controls.Add(contas);
            Controls.Add(utilizador);
            Controls.Add(Estado);
            Controls.Add(lstTarefas);
            Controls.Add(Sair);
            Controls.Add(Gerir);
            Controls.Add(Adicionar);
            Controls.Add(Descricao);
            Controls.Add(Titulo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Tarefa";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox Titulo;
        private TextBox Descricao;
        private Button Adicionar;
        private Button Gerir;
        private Button Sair;
        private ListBox lstTarefas;
        private ComboBox Estado;
        private Label utilizador;
        private Button contas;
    }
}
