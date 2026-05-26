namespace vendinha2
{
    partial class Cliente
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
            dataGridView1 = new DataGridView();
            txtBuscar = new TextBox();
            label1 = new Label();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnDividas = new Button();
            btnAnterior = new Button();
            btnProximo = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 90);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(730, 300);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(40, 45);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(300, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 20);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Buscar Cliente";
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(61, 424);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(180, 40);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "Excluir Cliente";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(285, 424);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(180, 40);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar Cliente";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnDividas
            // 
            btnDividas.Location = new Point(503, 424);
            btnDividas.Name = "btnDividas";
            btnDividas.Size = new Size(180, 40);
            btnDividas.TabIndex = 5;
            btnDividas.Text = "Ver Dívidas";
            btnDividas.UseVisualStyleBackColor = true;
            btnDividas.Click += btnDividas_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(411, 46);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 23);
            btnAnterior.TabIndex = 6;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnProximo
            // 
            btnProximo.Location = new Point(503, 46);
            btnProximo.Name = "btnProximo";
            btnProximo.Size = new Size(75, 23);
            btnProximo.TabIndex = 7;
            btnProximo.Text = "Proximo";
            btnProximo.UseVisualStyleBackColor = true;
            btnProximo.Click += btnProximo_Click;
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 500);
            Controls.Add(btnProximo);
            Controls.Add(btnAnterior);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            Controls.Add(dataGridView1);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnDividas);
            Name = "Cliente";
            Text = "Clientes";
            Load += Cliente_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtBuscar;
        private Label label1;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnDividas;
        private Button btnAnterior;
        private Button btnProximo;
    }
}