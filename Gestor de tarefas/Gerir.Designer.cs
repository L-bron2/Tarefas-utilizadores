namespace Gestor_de_tarefas
{
    partial class Gerir
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Remover = new Button();
            voltar = new Button();
            label1 = new Label();
            label4 = new Label();
            lstTarefas = new ListBox();
            ID = new TextBox();
            Estado = new ComboBox();
            btnPesquisar = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // Remover
            // 
            Remover.Location = new Point(51, 121);
            Remover.Name = "Remover";
            Remover.Size = new Size(75, 23);
            Remover.TabIndex = 1;
            Remover.Text = "Remover";
            Remover.UseVisualStyleBackColor = true;
            Remover.Click += Remover_Click;
            // 
            // voltar
            // 
            voltar.Location = new Point(331, 121);
            voltar.Name = "voltar";
            voltar.Size = new Size(75, 23);
            voltar.TabIndex = 3;
            voltar.Text = "Voltar";
            voltar.UseVisualStyleBackColor = true;
            voltar.Click += Voltar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(105, 27);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 4;
            label1.Text = "ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(105, 61);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 7;
            label4.Text = "Novo estado:";
            // 
            // lstTarefas
            // 
            lstTarefas.FormattingEnabled = true;
            lstTarefas.ItemHeight = 15;
            lstTarefas.Location = new Point(12, 150);
            lstTarefas.Name = "lstTarefas";
            lstTarefas.Size = new Size(457, 259);
            lstTarefas.TabIndex = 8;
            // 
            // ID
            // 
            ID.Location = new Point(132, 24);
            ID.Name = "ID";
            ID.Size = new Size(201, 23);
            ID.TabIndex = 9;
            // 
            // Estado
            // 
            Estado.ForeColor = Color.DarkOrange;
            Estado.FormattingEnabled = true;
            Estado.Items.AddRange(new object[] { "Pendente", "concluido" });
            Estado.Location = new Point(188, 58);
            Estado.Name = "Estado";
            Estado.Size = new Size(145, 23);
            Estado.TabIndex = 10;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(142, 121);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 11;
            btnPesquisar.Text = "pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(234, 121);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Atualizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Atualizar_Click;
            // 
            // Gerir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 417);
            Controls.Add(button1);
            Controls.Add(btnPesquisar);
            Controls.Add(Estado);
            Controls.Add(ID);
            Controls.Add(lstTarefas);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(voltar);
            Controls.Add(Remover);
            Name = "Gerir";
            Text = "Gerir";
            Load += Gerir_Load;
            Click += Gerir_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button Remover;
        private Button voltar;
        private Label label1;
        private Label label4;
        private ListBox lstTarefas;
        private TextBox ID;
        private ComboBox Estado;
        private Button btnPesquisar;
        
    }
}