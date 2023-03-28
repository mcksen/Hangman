using SFML.Graphics;
using SFML.Window;
public class Game
{
	private GameUI ui;
	private MenuUi menu;

	private string targetWord;
	private LetterCheck isMatch;
	private RenderWindow window;
	private char[] blank;
	bool gameON = false;
	bool newGame = false;
	UserInputAllkeys pressKey;

	public Game(RenderWindow wind)
	{
		// Adding a new array of strings, removing all words shoerter than 5 characters and converting to list of strings
		ListCreator Dict = new ListCreator();
		string[] allWords = File.ReadAllLines("C:\\Users\\kseni\\Documents\\HANGMAN.txt");
		List<string> dictionaryONE = Dict.RemoveWords(allWords, 5);
		// Choosing a random word
		WordChooser Ran = new WordChooser();
		targetWord = Ran.chooseTargetWord(dictionaryONE);
		Console.WriteLine(targetWord);
		window = wind;
		// Closing window
		WindowCloser close = new WindowCloser(window);
		pressKey = new UserInputAllkeys(window);
		pressKey.onLetterPressed += HandleLetterPress;
		pressKey.onSPACEpressed += HandleSPACEpressed;
		pressKey.onENTERpressed += HandleENTERPressed;
		isMatch = new LetterCheck();
		isMatch.onWrongLetterPressed += HandleWrongLetter;

		GameData.window = wind;
		menu = new MenuUi();
		ui = new GameUI();
		char blankWord = ' ';
		List<char> pro = new List<char>();
		for (int i = 0; i < targetWord.Length; i++)
		{
			pro.Add(blankWord);

		}
		blank = pro.ToArray();
		Console.WriteLine(blank.Length);
		GameData.ifMatch = new string(blank);

	}
	private void CheckifWon()
	{
		if (GameData.ifMatch == targetWord)
		{
			GameData.isWin = true;
			gameON = false;
		}
	}
	private void HandleWrongLetter(char letter)
	{
		GameData.wrongGuesses.Add(letter.ToString());
		if (GameData.wrongGuesses.Count == 10)
		{
			gameON = false;
		}
	}
	public void HandleSPACEpressed()
	{
		gameON = true;

	}
	public void HandleENTERPressed()
	{
		newGame = true;
	}
	//---------------------------------------------
	// 				HAPPENS EVERY FRAME
	//---------------------------------------------
	//Checking user's input
	private void HandleLetterPress(char letter)
	{
		char[] match = isMatch.checkLetter(blank, targetWord, letter);
		GameData.ifMatch = new string(match);
		CheckifWon();

	}

	public void Play()
	{

		window.DispatchEvents();
		if (gameON)
		{

			ui.ToDraw();

		}
		else
		{

			menu.Drawable();
		}

	}
}