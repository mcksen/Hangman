using SFML.Graphics;
using SFML.System;

public class ContentGenerator
{


	private Shape hangmanBOX;
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

	public Text MakeLetters(string letter, Font font, uint characterSize = 190)
	{
		Text letters = new Text(letter, font);
		letters.Color = new Color(Color.Black);
		letters.CharacterSize = characterSize;
		float letterHeight = letters.GetLocalBounds().Height;
		float letterWidth = letters.GetLocalBounds().Width;
		letters.Origin = new Vector2f(letterWidth / 2f, 0);
		return letters;
	}

	public Shape MakeHangmanBox(RenderWindow window)
	{
		hangmanBOX = MakeSquare();
		hangmanBOX.FillColor = new Color(Color.Transparent);
		hangmanBOX.OutlineColor = new Color(Color.Black);
		float width = hangmanBOX.GetGlobalBounds().Width;
		float height = hangmanBOX.GetGlobalBounds().Height;
		hangmanBOX.OutlineThickness = 5f;
		hangmanBOX.Scale = new Vector2f(1.2f, 1.3f);
		hangmanBOX.Origin = new Vector2f(width / 2f, height / 2f);
		hangmanBOX.Position = new Vector2f(window.Size.X * 0.8f, window.Size.Y * 0.25f);
		return hangmanBOX;
	}

	public Sprite MakeHangman(Texture texture)
	{
		Sprite failONE = new Sprite(texture);
		failONE.Position = new Vector2f(hangmanBOX.Position.X, hangmanBOX.Position.Y);
		float picWidth = failONE.GetGlobalBounds().Width;
		float picHeight = failONE.GetGlobalBounds().Height;
		failONE.Origin = new Vector2f(picWidth / 2f, picHeight / 2f);
		return failONE;
	}

}