using SFML.Graphics;

using Timer = System.Timers.Timer;
public class Game
{
	private GameUI ui;
	private MenuUi menu;
	private LetterCheck letterChecker;
	private RenderWindow window;
	private UserInputAllkeys pressKey;
	private WordChooser Ran = new WordChooser();
	private List<string> dictionaryONE;
	private Timer time;
	public Game(RenderWindow wind)
	{

		ListTrimmer Dict = new ListTrimmer();
		string[] allWords = File.ReadAllLines(@"bin\HANGMAN.txt");
		dictionaryONE = Dict.RemoveWords(allWords, 5);

		Reset();
		window = wind;
		time = new Timer(1000);
		time.Elapsed += HandleTimerElapsed;




		WindowCloser close = new WindowCloser(window);
		pressKey = new UserInputAllkeys(window);
		pressKey.onLetterPressed += HandleLetterPress;
		pressKey.onSPACEpressed += HandleSPACEpressed;
		pressKey.onENTERpressed += HandleENTERPressed;
		letterChecker = new LetterCheck();
		letterChecker.onWrongLetterPressed += HandleWrongLetter;

		GameData.window = wind;
		menu = new MenuUi();
		ui = new GameUI();
		char blankWord = ' ';
		List<char> pro = new List<char>();
		for (int i = 0; i < GameData.targetWord.Length; i++)
		{
			pro.Add(blankWord);

		}


		GameData.ifMatch = new string(pro.ToArray());


	}

	private void HandleTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
	{
		GameData.timeLeft--;
		if (GameData.timeLeft == 0)
		{
			GameData.gameSTATE = GameData.Mode.Lose;
			GameOver();

		}
	}

	private void ChangeCurrentScore()
	{
		if (GameData.gameSTATE == GameData.Mode.Win)
		{
			GameData.currentScore++;
		}
		else if (GameData.gameSTATE == GameData.Mode.Lose)
		{
			GameData.currentScore = 0;
		}

	}

	~Game()
	{
		pressKey.onLetterPressed -= HandleLetterPress;
		pressKey.onSPACEpressed -= HandleSPACEpressed;
		pressKey.onENTERpressed -= HandleENTERPressed;
		letterChecker.onWrongLetterPressed -= HandleWrongLetter;
	}
	private void CheckifWon()
	{
		if (GameData.ifMatch == GameData.targetWord)
		{
			GameData.gameSTATE = GameData.Mode.Win;
			GameOver();
		}
	}
	private void HandleWrongLetter(char letter)
	{
		GameData.wrongGuesses.Add(letter.ToString());
		if (GameData.wrongGuesses.Count == 10)
		{
			GameData.gameSTATE = GameData.Mode.Lose;
			GameOver();
		}
	}
	public void HandleSPACEpressed()
	{
		time.Start();
		GameData.gameSTATE = GameData.Mode.Play;


	}
	public void HandleENTERPressed()
	{
		Reset();
	}
	public void GameOver()
	{

		time.Stop();
		ChangeCurrentScore();

	}
	//---------------------------------------------
	// 				HAPPENS EVERY FRAME
	//---------------------------------------------

	private void HandleLetterPress(char letter)
	{
		if (GameData.gameSTATE == GameData.Mode.Play)
		{
			GameData.ifMatch = letterChecker.checkLetter(GameData.ifMatch, GameData.targetWord, letter);
			CheckifWon();
		}
	}

	public void Reset()
	{
		GameData.targetWord = Ran.chooseTargetWord(dictionaryONE);
		Console.WriteLine(GameData.targetWord);
		GameData.ifMatch = "     ";
		GameData.wrongGuesses.Clear();
		GameData.gameSTATE = GameData.Mode.Menu;
		GameData.timeLeft = 10;


	}
	public void Play()
	{

		window.DispatchEvents();
		if (GameData.gameSTATE == GameData.Mode.Play)
		{

			ui.ToDraw();

		}
		else
		{

			menu.Drawable();
		}

	}
}