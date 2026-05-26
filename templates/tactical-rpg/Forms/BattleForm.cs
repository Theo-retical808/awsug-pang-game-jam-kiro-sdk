using TacticalRPG.Grid;
using TacticalRPG.Combat;
using TacticalRPG.Units;

namespace TacticalRPG.Forms;

/// <summary>
/// Main battle screen with grid display and unit info.
/// </summary>
public class BattleForm : Form
{
    private readonly GridPanel _gridPanel;
    private readonly InfoPanel _infoPanel;
    private readonly TurnManager _turnManager;
    private readonly GridManager _gridManager;

    public BattleForm()
    {
        Text = "Tactical RPG - GAME CLOUD";
        Size = new Size(1000, 700);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Color.FromArgb(15, 15, 25);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        DoubleBuffered = true;

        // Initialize grid
        _gridManager = new GridManager(10, 8);
        _gridManager.SetupDefaultBattle();

        // Grid display panel
        _gridPanel = new GridPanel(_gridManager)
        {
            Location = new Point(10, 10),
            Size = new Size(650, 520)
        };
        _gridPanel.OnCellClicked += HandleCellClick;

        // Info panel on the right
        _infoPanel = new InfoPanel
        {
            Location = new Point(670, 10),
            Size = new Size(310, 640)
        };

        // Turn manager
        _turnManager = new TurnManager(_gridManager);
        _turnManager.OnTurnChanged += UpdateUI;
        _turnManager.OnBattleEnd += HandleBattleEnd;

        // Action buttons
        var endTurnBtn = CreateButton("End Turn", 10, 550);
        endTurnBtn.Click += (_, _) => _turnManager.EndTurn();

        var attackBtn = CreateButton("Attack", 220, 550);
        attackBtn.Click += (_, _) => _turnManager.SetMode(CombatMode.Attack);

        var moveBtn = CreateButton("Move", 430, 550);
        moveBtn.Click += (_, _) => _turnManager.SetMode(CombatMode.Move);

        Controls.Add(_gridPanel);
        Controls.Add(_infoPanel);
        Controls.Add(endTurnBtn);
        Controls.Add(attackBtn);
        Controls.Add(moveBtn);

        _turnManager.StartBattle();
        UpdateUI();
    }

    private void HandleCellClick(int x, int y)
    {
        _turnManager.HandleCellAction(x, y);
        _gridPanel.Invalidate();
        UpdateUI();
    }

    private void UpdateUI()
    {
        var activeUnit = _turnManager.GetActiveUnit();
        _infoPanel.ShowUnitInfo(activeUnit);
        _infoPanel.ShowTurnInfo(_turnManager.CurrentTurn, _turnManager.CurrentPhase);
        _gridPanel.Invalidate();
    }

    private void HandleBattleEnd(string result)
    {
        MessageBox.Show($"Battle Over! {result}", "Result");
    }

    private Button CreateButton(string text, int x, int y)
    {
        return new Button
        {
            Text = text,
            Location = new Point(x, y),
            Size = new Size(200, 40),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.FromArgb(40, 40, 70),
            ForeColor = Color.White,
            Font = new Font("Consolas", 10, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
    }
}
