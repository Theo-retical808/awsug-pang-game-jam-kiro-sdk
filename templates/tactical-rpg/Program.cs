using TacticalRPG.Forms;

namespace TacticalRPG;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new BattleForm());
    }
}
