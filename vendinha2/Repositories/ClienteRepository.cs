using System.Data;
using System.Data.SQLite;
using vendinha2.DataBase;

namespace vendinha2.Repositories
{
    public class ClienteRepository
    {
        BancoDados banco = new BancoDados();

        // LISTAR CLIENTES COM BUSCA E PAGINAÇÃO
        public DataTable ListarClientes(
            string busca,
            int pagina)
        {
            using (SQLiteConnection conexao =
                banco.AbrirConexao())
            {
                int limite = 10;

                int offset = pagina * limite;

                string sql = @"
                SELECT
                    Clientes.Id,

                    Clientes.NomeCompleto,

                    Clientes.CPF,

                    Clientes.DataNascimento,

                    Clientes.Email,

                    CAST(
                        (
                            julianday('now') -
                            julianday(Clientes.DataNascimento)
                        ) / 365
                    AS INTEGER
                    ) AS Idade,

                    IFNULL(
                        SUM(
                            CASE
                                WHEN Dividas.Situacao = 'Pendente'
                                THEN Dividas.Valor
                                ELSE 0
                            END
                        ),
                        0
                    ) AS TotalDividas

                FROM Clientes

                LEFT JOIN Dividas
                ON Clientes.Id = Dividas.ClienteId

                WHERE Clientes.NomeCompleto
                LIKE @busca

                GROUP BY Clientes.Id

                ORDER BY TotalDividas DESC

                LIMIT @limite OFFSET @offset";

                SQLiteDataAdapter adapter =
                    new SQLiteDataAdapter(sql, conexao);

                adapter.SelectCommand.Parameters.AddWithValue(
                    "@busca",
                    "%" + busca + "%"
                );

                adapter.SelectCommand.Parameters.AddWithValue(
                    "@limite",
                    limite
                );

                adapter.SelectCommand.Parameters.AddWithValue(
                    "@offset",
                    offset
                );

                DataTable tabela = new DataTable();

                adapter.Fill(tabela);

                return tabela;
            }
        }

        // EXCLUIR CLIENTE
        public void ExcluirCliente(int id)
        {
            using (SQLiteConnection conexao =
                banco.AbrirConexao())
            {
                string excluirDividas = @"
                DELETE FROM Dividas
                WHERE ClienteId = @id";

                using (SQLiteCommand comandoDividas =
                    new SQLiteCommand(
                        excluirDividas,
                        conexao
                    ))
                {
                    comandoDividas.Parameters.AddWithValue(
                        "@id",
                        id
                    );

                    comandoDividas.ExecuteNonQuery();
                }

                string sql =
                    "DELETE FROM Clientes WHERE Id = @id";

                using (SQLiteCommand comando =
                    new SQLiteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue(
                        "@id",
                        id
                    );

                    comando.ExecuteNonQuery();
                }
            }
        }

        // EDITAR CLIENTE
        public void EditarCliente(
            int id,
            string nome,
            string email)
        {
            using (SQLiteConnection conexao =
                banco.AbrirConexao())
            {
                string sql = @"
                UPDATE Clientes SET
                NomeCompleto = @nome,
                Email = @email
                WHERE Id = @id";

                using (SQLiteCommand comando =
                    new SQLiteCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue(
                        "@nome",
                        nome
                    );

                    comando.Parameters.AddWithValue(
                        "@email",
                        email
                    );

                    comando.Parameters.AddWithValue(
                        "@id",
                        id
                    );

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}