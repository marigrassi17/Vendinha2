using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using vendinha2.Repositories;

namespace vendinha2
{
    public partial class Cliente : Form
    {
        ClienteRepository repository =
            new ClienteRepository();

        int idSelecionado = 0;

        int paginaAtual = 0;

        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(
            object sender,
            EventArgs e)
        {
            ListarClientes();

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            dataGridView1.ReadOnly = true;
        }

        // LISTAR CLIENTES
        private void ListarClientes()
        {
            dataGridView1.DataSource =
                repository.ListarClientes(
                    txtBuscar.Text,
                    paginaAtual
                );
        }

        // BUSCAR CLIENTES
        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            paginaAtual = 0;

            ListarClientes();
        }

        // SELECIONAR CLIENTE
        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow linha =
                    dataGridView1.Rows[e.RowIndex];

                idSelecionado =
                    Convert.ToInt32(
                        linha.Cells["Id"].Value
                    );
            }
        }

        // EXCLUIR CLIENTE
        private void btnExcluir_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idSelecionado == 0)
                {
                    MessageBox.Show(
                        "Selecione um cliente!"
                    );

                    return;
                }

                DialogResult resultado =
                    MessageBox.Show(
                        "Deseja realmente excluir?",
                        "Confirmação",
                        MessageBoxButtons.YesNo
                    );

                if (resultado == DialogResult.Yes)
                {
                    repository.ExcluirCliente(
                        idSelecionado
                    );

                    MessageBox.Show(
                        "Cliente excluído!"
                    );

                    ListarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro: " + ex.Message
                );
            }
        }

        // EDITAR CLIENTE
        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Selecione um cliente!"
                    );

                    return;
                }

                string nome =
                    Interaction.InputBox(
                        "Novo nome:",
                        "Editar Cliente",
                        dataGridView1.CurrentRow
                        .Cells["NomeCompleto"]
                        .Value
                        .ToString()
                    );

                string email =
                    Interaction.InputBox(
                        "Novo email:",
                        "Editar Cliente",
                        dataGridView1.CurrentRow
                        .Cells["Email"]
                        .Value
                        .ToString()
                    );

                repository.EditarCliente(
                    idSelecionado,
                    nome,
                    email
                );

                MessageBox.Show(
                    "Cliente atualizado!"
                );

                ListarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro: " + ex.Message
                );
            }
        }

        // ABRIR TELA DE DÍVIDAS
        private void btnDividas_Click(
            object sender,
            EventArgs e)
        {
            Divida tela = new Divida();

            tela.ShowDialog();

            ListarClientes();
        }

        // PRÓXIMA PÁGINA
        private void btnProximo_Click(
            object sender,
            EventArgs e)
        {
            paginaAtual++;

            ListarClientes();
        }

        // PÁGINA ANTERIOR
        private void btnAnterior_Click(
            object sender,
            EventArgs e)
        {
            if (paginaAtual > 0)
            {
                paginaAtual--;

                ListarClientes();
            }
        }
    }
}