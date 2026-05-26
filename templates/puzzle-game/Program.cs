using PuzzleGame.Forms;

namespace PuzzleGame;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new GameForm());
    }
}
