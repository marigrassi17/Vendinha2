using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using vendinha2.DataBase;

namespace vendinha2
{
    public partial class Divida : Form
    {
        BancoDados banco = new BancoDados();

        int idSelecionado = 0;

        public Divida()
        {
            InitializeComponent();
        }

        private void Divida_Load(object sender, EventArgs e)
        {
            comboSituacao.Items.Add("Pendente");
            comboSituacao.Items.Add("Paga");

            comboSituacao.SelectedIndex = 0;

            CarregarClientes();

            ListarDividas();

            gridDividas.AutoSizeColumnsMode =
    DataGridViewAutoSizeColumnsMode.Fill;

            gridDividas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            gridDividas.MultiSelect = false;

            gridDividas.ReadOnly = true;
        }

        private void CarregarClientes()
        {
            using (SQLiteConnection conexao =
                banco.AbrirConexao())
            {
                string sql = @"
                SELECT Id, NomeCompleto
                FROM Clientes
                ORDER BY NomeCompleto";

                SQLiteDataAdapter adapter =
                    new SQLiteDataAdapter(sql, conexao);

                DataTable tabela = new DataTable();

                adapter.Fill(tabela);

                comboClientes.DataSource = tabela;

                comboClientes.DisplayMember =
                    "NomeCompleto";

                comboClientes.ValueMember =
                    "Id";
            }
        }

        private void ListarDividas()
        {
            using (SQLiteConnection conexao =
                banco.AbrirConexao())
            {
                string sql = @"
                SELECT
                    Dividas.Id,
                    Clientes.NomeCompleto,
                    Dividas.Valor,
                    Dividas.Situacao,
                    Dividas.DataCriacao,
                    Dividas.DataPagamento
                FROM Dividas
                INNER JOIN Clientes
                ON Dividas.ClienteId = Clientes.Id
                ORDER BY Dividas.Id DESC";

                SQLiteDataAdapter adapter =
                    new SQLiteDataAdapter(sql, conexao);

                DataTable tabela = new DataTable();

                adapter.Fill(tabela);

                gridDividas.DataSource = tabela;
            }
        }

        private void btnCadastrar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using (SQLiteConnection conexao =
                    banco.AbrirConexao())
                {
                    int clienteId =
                        Convert.ToInt32(
                            comboClientes.SelectedValue
                        );

                    string verificar = @"
                    SELECT COUNT(*)
                    FROM Dividas
                    WHERE ClienteId = @clienteId
                    AND Situacao = 'Pendente'";

                    using (SQLiteCommand comandoVerificar =
                        new SQLiteCommand(verificar, conexao))
                    {
                        comandoVerificar.Parameters.AddWithValue(
                            "@clienteId",
                            clienteId
                        );

                        int existe =
                            Convert.ToInt32(
                                comandoVerificar.ExecuteScalar()
                            );

                        if (existe > 0)
                        {
                            MessageBox.Show(
                                "Cliente já possui dívida em aberto!"
                            );

                            return;
                        }
                    }

                    string sql = @"
                    INSERT INTO Dividas
                    (
                        ClienteId,
                        Valor,
                        Situacao,
                        DataCriacao
                    )
                    VALUES
                    (
                        @clienteId,
                        @valor,
                        @situacao,
                        @data
                    )";

                    using (SQLiteCommand comando =
                        new SQLiteCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue(
                            "@clienteId",
                            clienteId
                        );

                        comando.Parameters.AddWithValue(
                            "@valor",
                            txtValor.Text
                        );

                        comando.Parameters.AddWithValue(
                            "@situacao",
                            comboSituacao.Text
                        );

                        comando.Parameters.AddWithValue(
                            "@data",
                            DateTime.Now.ToString()
                        );

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Dívida cadastrada!"
                );

                txtValor.Clear();

                comboSituacao.SelectedIndex = 0;

                ListarDividas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro: " + ex.Message
                );
            }
        }

        private void gridDividas_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha =
                    gridDividas.Rows[e.RowIndex];

                idSelecionado =
                    Convert.ToInt32(
                        linha.Cells["Id"].Value
                    );
            }
        }

        private void btnPagar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idSelecionado == 0)
                {
                    MessageBox.Show(
                        "Selecione uma dívida!"
                    );

                    return;
                }

                using (SQLiteConnection conexao =
                    banco.AbrirConexao())
                {
                    string sql = @"
                    UPDATE Dividas SET
                    Situacao = 'Paga',
                    DataPagamento = @data
                    WHERE Id = @id";

                    using (SQLiteCommand comando =
                        new SQLiteCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue(
                            "@data",
                            DateTime.Now.ToString()
                        );

                        comando.Parameters.AddWithValue(
                            "@id",
                            idSelecionado
                        );

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Dívida marcada como paga!"
                );

                ListarDividas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro: " + ex.Message
                );
            }
        }
    }
}