using SFML.Graphics;
using SFML.Window;

public class UserInputAllkeys
{
	public delegate void LetterEvent(char letter);
	public event LetterEvent onLetterPressed;
	public delegate void AltEvent();
	public event AltEvent onSPACEpressed;
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

		else if (e.Code == Keyboard.Key.Space && onSPACEpressed != null)
		{
			onSPACEpressed();
		}
	}
}