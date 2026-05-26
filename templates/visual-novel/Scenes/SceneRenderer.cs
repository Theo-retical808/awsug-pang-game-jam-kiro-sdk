namespace VisualNovel.Scenes;

/// <summary>
/// Renders scene backgrounds and character portraits.
/// Override or extend for custom visual effects.
/// </summary>
public class SceneRenderer : Panel
{
    private string _currentScene = "default";
    private Color _backgroundColor = Color.FromArgb(20, 20, 40);

    // Scene color palette (replace with actual images for your game)
    private readonly Dictionary<string, Color> _sceneColors = new()
    {
        ["default"] = Color.FromArgb(20, 20, 40),
        ["forest"] = Color.FromArgb(15, 40, 20),
        ["city"] = Color.FromArgb(30, 30, 50),
        ["beach"] = Color.FromArgb(40, 60, 80),
        ["night"] = Color.FromArgb(5, 5, 15)
    };

    public SceneRenderer()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
    }

    public void LoadScene(string sceneName)
    {
        _currentScene = sceneName;

        if (_sceneColors.TryGetValue(sceneName, out var color))
            _backgroundColor = color;
        else
            _backgroundColor = Color.FromArgb(20, 20, 40);

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;

        // Draw background
        using var brush = new SolidBrush(_backgroundColor);
        g.FillRectangle(brush, ClientRectangle);

        // Draw scene name (debug helper - remove for final game)
        using var font = new Font("Consolas", 9);
        using var textBrush = new SolidBrush(Color.FromArgb(80, 255, 255, 255));
        g.DrawString($"Scene: {_currentScene}", font, textBrush, 10, 10);
    }
}
