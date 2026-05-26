namespace TacticalRPG.Grid;

/// <summary>
/// Renders the tactical grid with units and highlights.
/// </summary>
public class GridPanel : Panel
{
    private readonly GridManager _grid;
    private const int CellSize = 60;

    public event Action<int, int>? OnCellClicked;
    public List<(int x, int y)> HighlightedCells { get; set; } = new();
    public Color HighlightColor { get; set; } = Color.FromArgb(80, 100, 200, 100);

    public GridPanel(GridManager grid)
    {
        _grid = grid;
        DoubleBuffered = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        BackColor = Color.FromArgb(20, 20, 35);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;

        // Draw grid
        for (int x = 0; x < _grid.Width; x++)
        for (int y = 0; y < _grid.Height; y++)
        {
            var rect = new Rectangle(x * CellSize, y * CellSize, CellSize - 1, CellSize - 1);
            var tile = _grid.Tiles[x, y];

            // Tile background
            var tileColor = tile.IsWalkable ? Color.FromArgb(30, 35, 50) : Color.FromArgb(15, 15, 20);
            using var tileBrush = new SolidBrush(tileColor);
            g.FillRectangle(tileBrush, rect);

            // Highlight
            if (HighlightedCells.Contains((x, y)))
            {
                using var hlBrush = new SolidBrush(HighlightColor);
                g.FillRectangle(hlBrush, rect);
            }

            // Grid lines
            using var pen = new Pen(Color.FromArgb(50, 60, 80));
            g.DrawRectangle(pen, rect);

            // Draw unit
            if (tile.Occupant != null)
            {
                DrawUnit(g, tile.Occupant, rect);
            }
        }
    }

    private void DrawUnit(Graphics g, Units.Unit unit, Rectangle cell)
    {
        var color = unit.Faction == "Player" ? Color.DodgerBlue : Color.Crimson;
        var unitRect = new Rectangle(cell.X + 10, cell.Y + 10, cell.Width - 20, cell.Height - 20);

        using var brush = new SolidBrush(color);
        g.FillEllipse(brush, unitRect);

        // Unit initial
        using var font = new Font("Consolas", 10, FontStyle.Bold);
        using var textBrush = new SolidBrush(Color.White);
        var initial = unit.Name[..1];
        var textSize = g.MeasureString(initial, font);
        g.DrawString(initial, font, textBrush,
            cell.X + (cell.Width - textSize.Width) / 2,
            cell.Y + (cell.Height - textSize.Height) / 2);

        // HP bar
        var hpPercent = (float)unit.HP / unit.MaxHP;
        var barRect = new Rectangle(cell.X + 5, cell.Y + cell.Height - 8, cell.Width - 10, 5);
        using var bgBrush = new SolidBrush(Color.FromArgb(40, 40, 40));
        g.FillRectangle(bgBrush, barRect);
        var hpColor = hpPercent > 0.5f ? Color.LimeGreen : hpPercent > 0.25f ? Color.Yellow : Color.Red;
        using var hpBrush = new SolidBrush(hpColor);
        g.FillRectangle(hpBrush, barRect.X, barRect.Y, (int)(barRect.Width * hpPercent), barRect.Height);
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        int x = e.X / CellSize;
        int y = e.Y / CellSize;
        if (_grid.InBounds(x, y))
            OnCellClicked?.Invoke(x, y);
    }
}
