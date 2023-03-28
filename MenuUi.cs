using SFML.Graphics;
using SFML.System;

public class MenuUi
{
	ContentGenerator content = new ContentGenerator();
	private Font font;
	Texture back;
	public MenuUi()
	{
		font = new Font("C:/Windows/Fonts/arial.ttf");
		back = new Texture("C:\\Users\\kseni\\Professional coding\\WORDLE\\Sprites\\b.jpg");
	}

	public void Drawable()
	{
		GameData.window.Clear(Color.White);
		DrawBack();
		DrawGameName();
		DrawStart();

		if (GameData.wrongGuesses.Count == 10)
		{
			GameData.window.Clear(Color.White);
			DrawGameOver();
			DrawNewGame();
		}

		if (GameData.isWin)
		{
			GameData.window.Clear(Color.White);
			DrawGameWon();
			DrawNewGame();
		}
		GameData.window.Display();
	}









	public void DrawGameName()
	{


		Text title = content.MakeLetters("~HANGMAN~", font, 160);
		title.Position = new Vector2f(GameData.windowSize.X / 2f, GameData.windowSize.Y * 0.34f);
		GameData.window.Draw(title);
	}

	public void DrawStart()
	{
		Text toStart = MakeInstructions("Press SPACE to start a new game");
		GameData.window.Draw(toStart);
	}
	public void DrawNewGame()
	{
		Text newGame = MakeInstructions("Press ENTER to play again");
		GameData.window.Draw(newGame);
	}
	public void DrawBack()
	{
		Sprite background = new Sprite(back);

		background.Scale = new Vector2f(0.815f, 0.59f);

		GameData.window.Draw(background);

	}
	private void DrawGameOver()
	{
		Text gameOver = MakeAnnouncment("GAME OVER!", 100);
		GameData.window.Draw(gameOver);
	}
	private void DrawGameWon()
	{
		Text win = MakeAnnouncment("GAME CLEARED!", 100);
		GameData.window.Draw(win);
	}
	private void DrawCORRECTannouncment()
	{
		Text correct = MakeAnnouncment("YAY!");
		for (int i = 0; i < GameData.ifMatch.Length; i++)
		{
			GameData.window.Draw(correct);
		}
	}
	private void DrawINCORRECTannouncment()
	{
		Text incorrect = MakeAnnouncment("NAY!");
		for (int i = 0; i < GameData.wrongGuesses.Count; i++)
		{

			GameData.window.Draw(incorrect);

		}
	}
	private Text MakeAnnouncment(string message, uint size = 300)
	{
		Text anonsment = content.MakeLetters(message, font);
		anonsment.CharacterSize = size;
		float width = anonsment.GetGlobalBounds().Width;
		float height = anonsment.GetGlobalBounds().Height;
		anonsment.Color = new Color(255, 215, 0);
		anonsment.Origin = new Vector2f(width / 2f, height / 2f);
		anonsment.Position = new Vector2f(GameData.windowSize.X / 2f, GameData.windowSize.Y * 0.4f);
		return (anonsment);
	}

	private Text MakeInstructions(string message)
	{
		Text instruction = content.MakeLetters(message, font, 45);
		instruction.Position = new Vector2f(GameData.windowSize.X / 2f, GameData.windowSize.Y * 0.8f);
		return instruction;
	}
}