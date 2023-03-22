using SFML.Graphics;
using SFML.System;

public class GameData
{
	public static RenderWindow window;
	public static Vector2f windowSize = new Vector2f(1300, 700);
	public static string ifMatch = "     ";
	public static List<string> wrongGuesses = new List<string> { };
	public static bool isWin = false;
	public static int highScore = 0;
	public static int currentScore = 0;
}