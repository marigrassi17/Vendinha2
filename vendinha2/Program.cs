using vendinha2.DataBase;

namespace vendinha2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            CriarBanco criar = new CriarBanco();
            criar.CriarTabelas();

            Application.Run(new Cadastro());
        }
    }
}