using SFML.Graphics;
using SFML.System;

public class GameUI
{

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

	Shape hangmanBOX;
	Text wrongTitle;
	List<Sprite> sprites;
	Color back;

	public GameUI()
	{

		padding = new Padding();
		padSize = 100f;
		startingPoint = new Vector2f(0, 0.80f);
		paddedPos = padding.GetPadding(GameData.windowSize, startingPoint, padSize);
		font = new Font("C:/Windows/Fonts/arial.ttf");
		content = new ContentGenerator();

		hangmanBOX = content.MakeHangmanBox(GameData.window);
		sprites = MakeSpriteList();
		back = new Color(159, 226, 219);

	}




	public void ToDraw()

	{
		GameData.window.Clear(back);
		DrawBox();
		DrawScore();
		DrawHIGHscore();
		DrawCharArray();
		DrawWrongGuesseTitle();
		DrawHangMan();
		DrawWrongGuesses();
		DrawTime();
		GameData.window.Display();


	}


	private void DrawCharArray()
	{
		if (GameData.ifMatch != null)
		{
			char[] array = GameData.ifMatch.ToCharArray();
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

				GameData.window.Draw(square);
				GameData.window.Draw(letter);
			}
		}
	}

	// MAKING BOX FOR THE HANGMAN
	private void DrawBox()
	{
		GameData.window.Draw(hangmanBOX);
	}
	public List<Sprite> MakeSpriteList()
	{
		Sprite failONE = content.MakeHangman(new Texture(@"Sprites\FailONE.png"));
		Sprite failTWO = content.MakeHangman(new Texture(@"Sprites\FailTWO.png"));
		Sprite failTHREE = content.MakeHangman(new Texture(@"Sprites\FailTHREE.png"));
		Sprite failFOUR = content.MakeHangman(new Texture(@"Sprites\FailFOUR.png"));
		Sprite failFIVE = content.MakeHangman(new Texture(@"Sprites\FailFIVE.png"));
		Sprite failSIX = content.MakeHangman(new Texture(@"Sprites\FailSIX.png"));
		Sprite failSEVEN = content.MakeHangman(new Texture(@"Sprites\FailSEVEN.png"));
		Sprite failEIGHT = content.MakeHangman(new Texture(@"Sprites\\FailEIGHT.png"));
		Sprite failNINE = content.MakeHangman(new Texture(@"Sprites\FailNINE.png"));
		Sprite failTEN = content.MakeHangman(new Texture(@"Sprites\FailTEN.png"));
		List<Sprite> sprites = new List<Sprite> { failONE, failTWO, failTHREE, failFOUR, failFIVE, failSIX, failSEVEN, failEIGHT, failNINE, failTEN };
		return sprites;
	}
	private void DrawHangMan()
	{


		for (int i = 0; i < GameData.wrongGuesses.Count; i++)
		{
			GameData.window.Draw(sprites[i]);
		}
	}
	private void DrawTime()
	{
		Text time = content.MakeLetters("TIME LEFT: " + GameData.timeLeft.ToString(), font, 30);
		time.Position = new Vector2f(GameData.windowSize.X * 0.11f, 0);
		GameData.window.Draw(time);
	}

	private void DrawWrongGuesses()
	{

		Text[] noMatch = CreateListToDraw(GameData.wrongGuesses);

		// Vector2f startPos = new Vector2f(windowSize.X * 0.1f, windowSize.Y * 0.4f);
		float space = -20f;
		for (int i = 0; i < noMatch.Length; i++)
		{
			// wrongTitle.GetGlobalBounds().Height is 29f
			space += 40f;
			noMatch[i].Position = new Vector2f(wrongTitle.GetGlobalBounds().Width * 1.4f, wrongTitle.Position.Y - 23) + new Vector2f(space, 0);
			GameData.window.Draw(noMatch[i]);

		}
	}


	private Text[] CreateListToDraw(List<string> wrong)
	{
		string word = " ";
		Text list;
		List<Text> notMatch = new List<Text>();
		for (int i = 0; i < wrong.Count; i++)
		{
			word = wrong[i];
			list = content.MakeLetters(word, font, 50);
			notMatch.Add(list);
		}
		return notMatch.ToArray();
	}

	private void DrawWrongGuesseTitle()
	{
		wrongTitle = content.MakeLetters("NO MATCH WITH:", font, 40);
		float width = wrongTitle.GetGlobalBounds().Width;
		float height = wrongTitle.GetGlobalBounds().Height;
		wrongTitle.Origin = new Vector2f(0, height / 2f);
		wrongTitle.Position = new Vector2f(GameData.windowSize.X * 0.09f, GameData.windowSize.Y * 0.5f);
		GameData.window.Draw(wrongTitle);
	}

	private void DrawScore()
	{
		Text score = content.MakeLetters("Your current score is: " + GameData.currentScore, font, 30);
		score.Position = new Vector2f(GameData.windowSize.X * 0.5f, GameData.windowSize.Y * 0.1f);
		GameData.window.Draw(score);
	}

	private void DrawHIGHscore()
	{
		Text score = content.MakeLetters("HIGHSCORE: " + GameData.highScore, font, 30);
		score.Position = new Vector2f(GameData.windowSize.X * 0.47f, GameData.windowSize.Y * 0.2f);
		GameData.window.Draw(score);

	}
}

