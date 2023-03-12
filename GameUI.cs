using SFML.Graphics;
using SFML.System;

public class GameUI
{
	private Vector2f windowSize;
	private float boxSize;
	private Padding padding;
	private Vector2f startingPoint;
	private float padSize;
	private Vector2f paddedPos;
	private Font font;
	private TextListAdder textList;
	private List<Text> targetCHARlist;
	private ContentGenerator content;
	private Vector2f size;
	private Shape[] squares;
	private GameData data;
	Shape hangmanBOX;
	public GameUI(GameData wind)
	{
		windowSize = new Vector2f(1300, 700);

		padding = new Padding();
		padSize = 100f;
		startingPoint = new Vector2f(0, 0.80f);
		paddedPos = padding.GetPadding(windowSize, startingPoint, padSize);
		font = new Font("C:/Windows/Fonts/arial.ttf");
		content = new ContentGenerator();
		data = wind;

	}




	public void ToDraw()

	{
		data.window.Clear(Color.Green);
		DrawBox();
		DrawCharArray();
		DrawHangMan();

		data.window.Display();


	}


	private void DrawCharArray()
	{
		if (data != null && data.ifMatch != null)
		{
			char[] array = data.ifMatch.ToCharArray();
			ContentGenerator content = new ContentGenerator();
			Vector2f initialpos = paddedPos;
			float space = 0;

			for (int i = 0; i < array.Length; i++)
			{
				string oneChar = Convert.ToString(array[i]);
				Text letter = content.MakeLetters(oneChar, font);
				Shape square = content.MakeSquare();
				square.Position = initialpos + new Vector2f(space, 0);
				space += 220f;
				float height = square.GetGlobalBounds().Height;
				float width = square.GetGlobalBounds().Width;
				letter.Position = new Vector2f(square.Position.X + width / 2f, (square.Position.Y - height / 2f) - 20f);

				data.window.Draw(square);
				data.window.Draw(letter);
			}
		}
	}

	// MAKING BOX FOR THE HANGMAN
	private void DrawBox()
	{
		hangmanBOX = content.MakeHangmanBox(data.window);
		data.window.Draw(hangmanBOX);
	}
	public List<Sprite> MakeSpriteList()
	{
		Sprite failONE = content.MakeHangman(new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\FailONE.png"));
		Sprite failTWO = content.MakeHangman(new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\FailTWO.png"));
		Sprite failTHREE = content.MakeHangman(new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\FailTHREE.png"));
		Sprite failFOUR = content.MakeHangman(new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\FailFOUR.png"));
		Sprite failFIVE = content.MakeHangman(new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\FailFIVE.png"));
		Sprite failSIX = content.MakeHangman(new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\FailSIX.png"));
		Sprite failSEVEN = content.MakeHangman(new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\FailSEVEN.png"));
		Sprite failEIGHT = content.MakeHangman(new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\FailEIGHT.png"));
		Sprite failNINE = content.MakeHangman(new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\FailNINE.png"));
		Sprite failTEN = content.MakeHangman(new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\FailTEN.png"));
		List<Sprite> sprites = new List<Sprite> { failONE, failTWO, failTHREE, failFOUR, failFIVE, failSIX, failSEVEN, failEIGHT, failNINE, failTEN };
		return sprites;
	}
	private void DrawHangMan()
	{

		List<Sprite> sprites = MakeSpriteList();
		for (int i = 0; i < sprites.Count; i++)
		{
			data.window.Draw(sprites[i]);
		}
	}



}