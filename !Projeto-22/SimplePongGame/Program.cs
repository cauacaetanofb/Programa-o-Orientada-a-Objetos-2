// Em Program.cs
namespace SimplePongGame
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // Inicia o programa com o formul�rio do menu
            Application.Run(new MenuForm());
        }
    }
}