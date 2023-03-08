using SFML.Graphics;
using SFML.Window;

public class UserInputAllkeys
{
	public delegate void LetterEvent(char letter);
	public event LetterEvent onLetterPressed;
	RenderWindow winDOW;
	public UserInputAllkeys(RenderWindow window)
	{
		winDOW = window;
		window.KeyPressed += HandleKeyPress;
	}
	public void HandleKeyPress(object? sender, KeyEventArgs e)
	{
		if ((int)e.Code <= 25)
		{
			string let = Convert.ToString(e.Code);
			let = let.ToLower();
			char letter = Convert.ToChar(let);

			if (onLetterPressed != null)
			{
				onLetterPressed(letter);
			}
		}
	}

}