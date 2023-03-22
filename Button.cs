using SFML.Graphics;
using SFML.System;
public class Button
{

	Font font = new Font("C:/Windows/Fonts/arial.ttf");
	Shape shape;
	Text title;
	Sprite image;
	public Button(Vector2f buttonSize, Vector2f position, Color color, string text = "")
	{
		shape = new RectangleShape(buttonSize);
		float width = shape.GetGlobalBounds().Width;
		float height = shape.GetGlobalBounds().Height;
		shape.Position = position;
		Color buttonFillColor = color;
		title = new Text(text, font);
		title.Color = new Color(Color.Black);
		float textWidth = title.GetGlobalBounds().Width;
		float textHeight = title.GetGlobalBounds().Height;
		title.Origin = new Vector2f(textWidth / 2f, textHeight / 2f);
		title.Position = new Vector2f(width / 2f, height / 2f);
	}
	public Button(Vector2f buttonSize, Vector2f position, string text, string path = "")
	{
		Shape shape = new RectangleShape(buttonSize);
		float width = shape.GetGlobalBounds().Width;
		float height = shape.GetGlobalBounds().Height;
		shape.Position = position;
		Texture texture = new Texture(path);
		image = new Sprite(texture);
		title = new Text(text, font);
		title.Color = new Color(Color.Black);
		float textWidth = title.GetGlobalBounds().Width;
		float textHeight = title.GetGlobalBounds().Height;
		title.Origin = new Vector2f(textWidth / 2f, textHeight / 2f);
		title.Position = new Vector2f(width / 2f, height / 2f);
	}

	public void DrawButton(RenderWindow window)
	{

		window.Draw(shape);
		window.Draw(title);
		window.Draw(image);
	}
}