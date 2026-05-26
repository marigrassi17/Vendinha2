using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using vendinha2.DataBase;

namespace vendinha2
{
    public partial class Cadastro : Form
    {
        BancoDados banco = new BancoDados();

        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        // VALIDAR CPF
        private bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "")
                     .Replace("-", "")
                     .Trim();

            if (cpf.Length != 11)
                return false;

            bool todosIguais = true;

            for (int i = 1; i < 11 && todosIguais; i++)
            {
                if (cpf[i] != cpf[0])
                    todosIguais = false;
            }

            if (todosIguais || cpf == "12345678909")
                return false;

            int[] multiplicador1 =
                { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 =
                { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);

            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(
                    tempCpf[i].ToString()
                ) * multiplicador1[i];
            }

            int resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();

            tempCpf += digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(
                    tempCpf[i].ToString()
                ) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        // VALIDAR EMAIL
        private bool ValidarEmail(string email)
        {
            string padrao =
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, padrao);
        }

        // CADASTRAR CLIENTE
        private void button1_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // CAMPOS OBRIGATÓRIOS
                if (
                    txtNome.Text == "" ||
                    txtCpf.Text == "" ||
                    txtDataNascimento.Text == ""
                )
                {
                    MessageBox.Show(
                        "Preencha os campos obrigatórios!"
                    );

                    return;
                }

                // VALIDAR CPF
                if (!ValidarCPF(txtCpf.Text))
                {
                    MessageBox.Show(
                        "CPF inválido!"
                    );

                    return;
                }

                // VALIDAR EMAIL
                if (
                    txtEmail.Text != "" &&
                    !ValidarEmail(txtEmail.Text)
                )
                {
                    MessageBox.Show(
                        "E-mail inválido!"
                    );

                    return;
                }

                // VALIDAR DATA
                DateTime dataNascimento;

                bool dataValida =
                    DateTime.TryParse(
                        txtDataNascimento.Text,
                        out dataNascimento
                    );

                if (!dataValida)
                {
                    MessageBox.Show(
                        "Data inválida!"
                    );

                    return;
                }

                using (SQLiteConnection conexao =
                    banco.AbrirConexao())
                {
                    // VERIFICAR CPF DUPLICADO
                    string verificarCpf = @"
                    SELECT COUNT(*)
                    FROM Clientes
                    WHERE CPF = @cpf";

                    using (SQLiteCommand comandoVerificar =
                        new SQLiteCommand(
                            verificarCpf,
                            conexao
                        ))
                    {
                        comandoVerificar.Parameters.AddWithValue(
                            "@cpf",
                            txtCpf.Text
                        );

                        int existe =
                            Convert.ToInt32(
                                comandoVerificar.ExecuteScalar()
                            );

                        if (existe > 0)
                        {
                            MessageBox.Show(
                                "CPF já cadastrado!"
                            );

                            return;
                        }
                    }

                    string sql = @"
                    INSERT INTO Clientes
                    (
                        NomeCompleto,
                        CPF,
                        DataNascimento,
                        Email
                    )
                    VALUES
                    (
                        @nome,
                        @cpf,
                        @data,
                        @email
                    )";

                    using (SQLiteCommand comando =
                        new SQLiteCommand(sql, conexao))
                    {
                        comando.Parameters.AddWithValue(
                            "@nome",
                            txtNome.Text
                        );

                        comando.Parameters.AddWithValue(
                            "@cpf",
                            txtCpf.Text
                        );

                        comando.Parameters.AddWithValue(
                            "@data",
                            txtDataNascimento.Text
                        );

                        comando.Parameters.AddWithValue(
                            "@email",
                            txtEmail.Text
                        );

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Cliente cadastrado com sucesso!"
                );

                txtNome.Clear();
                txtCpf.Clear();
                txtDataNascimento.Clear();
                txtEmail.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro: " + ex.Message
                );
            }
        }

        // ABRIR TELA CLIENTES
        private void button2_Click(
            object sender,
            EventArgs e)
        {
            Cliente tela = new Cliente();

            tela.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}