namespace Gestor_de_tarefas
{
    partial class ADMmanager
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
            label1 = new Label();
            button1 = new Button();
            ADM = new RadioButton();
            Ativo = new RadioButton();
            label2 = new Label();
            textBox1 = new TextBox();
            lstUsuarios = new ListBox();
            button2 = new Button();
            Gestor = new RadioButton();
            Operador = new RadioButton();
            Inativo = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(332, 78);
            button1.Name = "button1";
            button1.Size = new Size(123, 23);
            button1.TabIndex = 2;
            button1.Text = "Atualizar conta";
            button1.UseVisualStyleBackColor = true;
            // 
            // ADM
            // 
            ADM.AutoSize = true;
            ADM.Location = new Point(173, 12);
            ADM.Name = "ADM";
            ADM.Size = new Size(52, 19);
            ADM.TabIndex = 3;
            ADM.TabStop = true;
            ADM.Text = "ADM";
            ADM.UseVisualStyleBackColor = true;
            // 
            // Ativo
            // 
            Ativo.AutoSize = true;
            Ativo.Location = new Point(288, 12);
            Ativo.Name = "Ativo";
            Ativo.Size = new Size(53, 19);
            Ativo.TabIndex = 4;
            Ativo.TabStop = true;
            Ativo.Text = "Ativo";
            Ativo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 27);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 6;
            label2.Text = "ID: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(42, 21);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 7;
            // 
            // lstUsuarios
            // 
            lstUsuarios.FormattingEnabled = true;
            lstUsuarios.ItemHeight = 15;
            lstUsuarios.Location = new Point(12, 107);
            lstUsuarios.Name = "lstUsuarios";
            lstUsuarios.Size = new Size(534, 124);
            lstUsuarios.TabIndex = 8;
            // 
            // button2
            // 
            button2.Location = new Point(471, 78);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Voltar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Gestor
            // 
            Gestor.AutoSize = true;
            Gestor.Location = new Point(173, 37);
            Gestor.Name = "Gestor";
            Gestor.Size = new Size(59, 19);
            Gestor.TabIndex = 10;
            Gestor.TabStop = true;
            Gestor.Text = "Gestor";
            Gestor.UseVisualStyleBackColor = true;
            // 
            // Operador
            // 
            Operador.AutoSize = true;
            Operador.Location = new Point(173, 62);
            Operador.Name = "Operador";
            Operador.Size = new Size(75, 19);
            Operador.TabIndex = 11;
            Operador.TabStop = true;
            Operador.Text = "Operador";
            Operador.UseVisualStyleBackColor = true;
            // 
            // Inativo
            // 
            Inativo.AutoSize = true;
            Inativo.Location = new Point(288, 37);
            Inativo.Name = "Inativo";
            Inativo.Size = new Size(61, 19);
            Inativo.TabIndex = 12;
            Inativo.TabStop = true;
            Inativo.Text = "Inativo";
            Inativo.UseVisualStyleBackColor = true;
            // 
            // ADMmanager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 234);
            Controls.Add(Inativo);
            Controls.Add(Operador);
            Controls.Add(Gestor);
            Controls.Add(button2);
            Controls.Add(lstUsuarios);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(Ativo);
            Controls.Add(ADM);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "ADMmanager";
            Text = "ADMmanager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private RadioButton ADM;
        private RadioButton Ativo;
        private Label label2;
        private TextBox textBox1;
        private ListBox lstUsuarios;
        private Button button2;
        private RadioButton Gestor;
        private RadioButton Operador;
        private RadioButton Inativo;
    }
}