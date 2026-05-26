using TacticalRPG.Units;

namespace TacticalRPG.Forms;

/// <summary>
/// Side panel showing unit info and turn state.
/// </summary>
public class InfoPanel : Panel
{
    private readonly Label _turnLabel;
    private readonly Label _unitNameLabel;
    private readonly Label _unitStatsLabel;
    private readonly Label _phaseLabel;

    public InfoPanel()
    {
        BackColor = Color.FromArgb(25, 25, 40);
        BorderStyle = BorderStyle.FixedSingle;

        _turnLabel = new Label
        {
            ForeColor = Color.Gold,
            Font = new Font("Consolas", 12, FontStyle.Bold),
            Location = new Point(10, 10),
            AutoSize = true,
            Text = "Turn 1"
        };

        _phaseLabel = new Label
        {
            ForeColor = Color.LightGray,
            Font = new Font("Consolas", 9),
            Location = new Point(10, 35),
            AutoSize = true
        };

        _unitNameLabel = new Label
        {
            ForeColor = Color.White,
            Font = new Font("Consolas", 11, FontStyle.Bold),
            Location = new Point(10, 80),
            AutoSize = true
        };

        _unitStatsLabel = new Label
        {
            ForeColor = Color.LightGray,
            Font = new Font("Consolas", 9),
            Location = new Point(10, 110),
            Size = new Size(280, 200),
            AutoSize = false
        };

        Controls.Add(_turnLabel);
        Controls.Add(_phaseLabel);
        Controls.Add(_unitNameLabel);
        Controls.Add(_unitStatsLabel);
    }

    public void ShowUnitInfo(Unit? unit)
    {
        if (unit == null)
        {
            _unitNameLabel.Text = "No unit selected";
            _unitStatsLabel.Text = "";
            return;
        }

        _unitNameLabel.Text = $"{unit.Name} ({unit.Faction})";
        _unitNameLabel.ForeColor = unit.Faction == "Player" ? Color.LightBlue : Color.Salmon;
        _unitStatsLabel.Text = $"HP: {unit.HP}/{unit.MaxHP}\n" +
                               $"ATK: {unit.Attack}\n" +
                               $"DEF: {unit.Defense}\n" +
                               $"Move: {unit.MoveRange}\n" +
                               $"Range: {unit.AttackRange}";
    }

    public void ShowTurnInfo(int turn, string phase)
    {
        _turnLabel.Text = $"Turn {turn}";
        _phaseLabel.Text = phase;
    }
}
