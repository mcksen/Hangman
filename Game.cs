using SFML.Graphics;
using SFML.Window;
public class Game
{
	private GameUI ui;
	private GameData data;
	private string targetWord;
	private LetterCheck isMatch;
	private RenderWindow window;
	private char[] blank;
	public Game(RenderWindow wind)
	{
		// Adding a new array of strings, removing all words shoerter than 5 characters and converting to list of strings
		ListCreator Dict = new ListCreator();
		string[] allWords = File.ReadAllLines("C:\\Users\\kseni\\Documents\\HANGMAN.txt");
		List<string> dictionaryONE = Dict.RemoveWords(allWords, 6);
		// Choosing a random word
		WordChooser Ran = new WordChooser();
		targetWord = Ran.chooseTargetWord(dictionaryONE);
		Console.WriteLine(targetWord);
		window = wind;
		// Closing window
		WindowCloser close = new WindowCloser(window);
		UserInputAllkeys pressKey = new UserInputAllkeys(window);
		pressKey.onLetterPressed += HandleLetterPress;
		isMatch = new LetterCheck();
		data = new GameData();
		data.window = wind;

		ui = new GameUI(data);
		char blankWord = ' ';
		List<char> pro = new List<char>();
		for (int i = 0; i < targetWord.Length; i++)
		{
			pro.Add(blankWord);

		}
		blank = pro.ToArray();
		Console.WriteLine(blank.Length);
		data.ifMatch = new string(blank);

	}
	//---------------------------------------------
	// 				HAPPENS EVERY FRAME
	//---------------------------------------------
	//Checking user's input
	private void HandleLetterPress(char letter)
	{
		char[] match = isMatch.checkLetter(blank, targetWord, letter);
		data.ifMatch = new string(match);

	}
	public void Play()
	{
		window.DispatchEvents();
		ui.ToDraw();
	}
}