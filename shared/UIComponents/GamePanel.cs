namespace GameCloud.Shared.UIComponents;

/// <summary>
/// A double-buffered panel for smooth rendering.
/// Use for custom drawing areas.
/// </summary>
public class GamePanel : Panel
{
    public GamePanel()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        BackColor = Color.Black;
    }
}
