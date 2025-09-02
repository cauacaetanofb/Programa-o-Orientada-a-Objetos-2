// Em Program.cs
namespace SimplePongGame
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // Inicia o programa com o formulário do menu
            Application.Run(new MenuForm());
        }
    }
}