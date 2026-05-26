namespace vendinha2
{
    partial class Divida
    {
        private System.ComponentModel.IContainer components = null;

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
            txtValor = new TextBox();
            comboSituacao = new ComboBox();
            btnCadastrar = new Button();
            btnPagar = new Button();
            gridDividas = new DataGridView();
            comboClientes = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)gridDividas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 30);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome do Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 30);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 2;
            label2.Text = "Valor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(570, 30);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 4;
            label3.Text = "Situação";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(320, 50);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(200, 23);
            txtValor.TabIndex = 3;
            // 
            // comboSituacao
            // 
            comboSituacao.Location = new Point(570, 50);
            comboSituacao.Name = "comboSituacao";
            comboSituacao.Size = new Size(150, 23);
            comboSituacao.TabIndex = 5;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(50, 88);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(180, 40);
            btnCadastrar.TabIndex = 6;
            btnCadastrar.Text = "Cadastrar Dívida";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(320, 88);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(180, 40);
            btnPagar.TabIndex = 7;
            btnPagar.Text = "Marcar como Paga";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // gridDividas
            // 
            gridDividas.BackgroundColor = SystemColors.GradientInactiveCaption;
            gridDividas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDividas.Location = new Point(50, 190);
            gridDividas.Name = "gridDividas";
            gridDividas.Size = new Size(700, 220);
            gridDividas.TabIndex = 8;
            gridDividas.CellClick += gridDividas_CellClick;
            // 
            // comboClientes
            // 
            comboClientes.FormattingEnabled = true;
            comboClientes.Location = new Point(50, 50);
            comboClientes.Name = "comboClientes";
            comboClientes.Size = new Size(200, 23);
            comboClientes.TabIndex = 9;
            // 
            // Divida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(comboClientes);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtValor);
            Controls.Add(label3);
            Controls.Add(comboSituacao);
            Controls.Add(btnCadastrar);
            Controls.Add(btnPagar);
            Controls.Add(gridDividas);
            Name = "Divida";
            Text = "Controle de Dívidas";
            Load += Divida_Load;
            ((System.ComponentModel.ISupportInitialize)gridDividas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtValor;

        private ComboBox comboSituacao;

        private Button btnCadastrar;
        private Button btnPagar;

        private DataGridView gridDividas;
        private ComboBox comboClientes;
    }
}