using System.Data.SQLite;

namespace vendinha2.DataBase
{
    public class BancoDados
    {
        private string conexaoString =
            "Data Source=vendinha.db;Version=3;";

        public SQLiteConnection AbrirConexao()
        {
            SQLiteConnection conexao =
                new SQLiteConnection(conexaoString);

            conexao.Open();

            return conexao;
        }
    }
}