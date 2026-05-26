using System;
using System.Data.SQLite;

namespace vendinha2.DataBase
{
    public class CriarBanco
    {
        public void CriarTabelas()
        {
            BancoDados banco = new BancoDados();

            using (SQLiteConnection conexao =
                banco.AbrirConexao())
            {
                string sqlClientes = @"
                CREATE TABLE IF NOT EXISTS Clientes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NomeCompleto TEXT NOT NULL,
                    CPF TEXT NOT NULL UNIQUE,
                    DataNascimento TEXT NOT NULL,
                    Email TEXT
                );";

                using (SQLiteCommand comando =
                    new SQLiteCommand(sqlClientes, conexao))
                {
                    comando.ExecuteNonQuery();
                }

                string sqlDividas = @"
                CREATE TABLE IF NOT EXISTS Dividas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,

                    ClienteId INTEGER NOT NULL,

                    Valor REAL NOT NULL,

                    Situacao TEXT NOT NULL,

                    DataCriacao TEXT NOT NULL,

                    DataPagamento TEXT,

                    FOREIGN KEY (ClienteId)
                    REFERENCES Clientes(Id)
                );";

                using (SQLiteCommand comando =
                    new SQLiteCommand(sqlDividas, conexao))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}