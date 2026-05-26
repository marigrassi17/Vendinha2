namespace vendinha2
{
    partial class Cadastro
    {
        /// <summary>
        /// Variável necessária do designer.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar recursos usados.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Forms Designer

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            txtNome = new TextBox();
            txtCpf = new TextBox();
            txtDataNascimento = new TextBox();
            txtEmail = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(256, 103);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(256, 163);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 2;
            label2.Text = "CPF";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(256, 223);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 4;
            label3.Text = "Data Nascimento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(256, 280);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 6;
            label5.Text = "Email";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(256, 121);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(250, 23);
            txtNome.TabIndex = 1;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(256, 181);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(250, 23);
            txtCpf.TabIndex = 3;
            // 
            // txtDataNascimento
            // 
            txtDataNascimento.Location = new Point(256, 241);
            txtDataNascimento.Name = "txtDataNascimento";
            txtDataNascimento.Size = new Size(250, 23);
            txtDataNascimento.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(256, 298);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 23);
            txtEmail.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(256, 369);
            button1.Name = "button1";
            button1.Size = new Size(250, 40);
            button1.TabIndex = 8;
            button1.Text = "Cadastrar Cliente";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(256, 434);
            button2.Name = "button2";
            button2.Size = new Size(250, 40);
            button2.TabIndex = 9;
            button2.Text = "Ver Clientes";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Banner", 14.2499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(230, 43);
            label4.Name = "label4";
            label4.Size = new Size(324, 28);
            label4.TabIndex = 10;
            label4.Text = "Sistema de Controle de Clientes e Dívidas";
            label4.Click += label4_Click;
            // 
            // Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 550);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Controls.Add(txtCpf);
            Controls.Add(label3);
            Controls.Add(txtDataNascimento);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(button1);
            Controls.Add(button2);
            Name = "Cadastro";
            Text = "Cadastro de Clientes";
            Load += Cadastro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;

        private TextBox txtNome;
        private TextBox txtCpf;
        private TextBox txtDataNascimento;
        private TextBox txtEmail;

        private Button button1;
        private Button button2;
        private Label label4;
    }
}