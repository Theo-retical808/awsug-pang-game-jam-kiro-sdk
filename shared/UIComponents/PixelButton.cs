namespace GameCloud.Shared.UIComponents;

/// <summary>
/// A styled button with consistent game-like appearance.
/// </summary>
public class PixelButton : Button
{
    public PixelButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 2;
        FlatAppearance.BorderColor = Color.White;
        BackColor = Color.FromArgb(40, 40, 60);
        ForeColor = Color.White;
        Font = new Font("Consolas", 11, FontStyle.Bold);
        Cursor = Cursors.Hand;
        Size = new Size(200, 40);
    }

    public void SetColors(Color background, Color border, Color text)
    {
        BackColor = background;
        FlatAppearance.BorderColor = border;
        ForeColor = text;
    }
}
