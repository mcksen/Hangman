using SFML.Graphics;
using SFML.System;
using SFML.Window;
public class ContentGenerator
{
	public Shape MakeSquare()
	{
		float boxSize = 210f;
		Vector2f size = new Vector2f(boxSize, boxSize);
		Shape figure = new RectangleShape(size);

		figure.FillColor = new Color(Color.White);

		float squarseHeight = figure.GetLocalBounds().Height;
		float squareWidth = figure.GetLocalBounds().Width;
		figure.Origin = new Vector2f(0, squarseHeight / 2f);

		return figure;

	}

	public Text MakeLetters(string letter, Font font)
	{
		Text letters = new Text(letter, font);
		letters.Color = new Color(Color.Black);
		letters.CharacterSize = 190;
		float letterHeight = letters.GetLocalBounds().Height;
		float letterWidth = letters.GetLocalBounds().Width;
		letters.Origin = new Vector2f(letterWidth / 2f, 0);
		return letters;
	}
}