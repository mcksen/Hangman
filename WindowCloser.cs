using SFML.Graphics;
using SFML.Window;

public class WindowCloser
{
	private RenderWindow winDOW;
	public WindowCloser(RenderWindow window)
	{
		winDOW = window;
		window.Closed += HandleClose;
		window.KeyPressed += HandleKeyPress;
	}

	public void HandleClose(object? sender, EventArgs e)
	{
		winDOW.Close();
	}
	public void HandleKeyPress(object? sender, KeyEventArgs e)
	{
		if (e.Code == Keyboard.Key.Escape)
		{
			winDOW.Close();
		}
	}
}
