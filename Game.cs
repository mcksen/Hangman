using SFML.Graphics;
using SFML.Window;
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
		// Adding a new array of strings, removing all words shoerter than 5 characters and converting to list of strings
		ListCreator Dict = new ListCreator();
		string[] allWords = File.ReadAllLines("C:\\Users\\kseni\\Documents\\HANGMAN.txt");
		dictionaryONE = Dict.RemoveWords(allWords, 5);
		// Choosing a random word
		Reset();
		window = wind;
		time = new Timer(1000);
		time.Elapsed += HandleTimerElapsed;



		// Closing window
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
			GameData.isLose = true;
			GameOver();

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
			GameData.isWin = true;
			GameOver();
		}
	}
	private void HandleWrongLetter(char letter)
	{
		GameData.wrongGuesses.Add(letter.ToString());
		if (GameData.wrongGuesses.Count == 10)
		{
			GameData.isLose = true;
			GameOver();
		}
	}
	public void HandleSPACEpressed()
	{
		time.Start();
		GameData.gameON = true;

	}
	public void HandleENTERPressed()
	{
		Reset();
	}
	public void GameOver()
	{
		GameData.gameON = false;

	}
	//---------------------------------------------
	// 				HAPPENS EVERY FRAME
	//---------------------------------------------
	//Checking user's input
	private void HandleLetterPress(char letter)
	{
		if (GameData.gameON)
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
		GameData.isWin = false;
		GameData.timeLeft = 10;
		GameData.isLose = false;
	}
	public void Play()
	{

		window.DispatchEvents();
		if (GameData.gameON)
		{

			ui.ToDraw();

		}
		else
		{

			menu.Drawable();
		}

	}
}