using SFML.Graphics;
using SFML.System;

public static class GameData
{
	public enum Mode { Play, Menu, Win, Lose }
	public static Mode gameSTATE = Mode.Play;
	public static RenderWindow window;
	public static Vector2f windowSize = new Vector2f(1300, 700);
	public static string ifMatch = "     ";
	public static List<string> wrongGuesses = new List<string> { };

	public static int highScore = 0;
	public static int currentScore = 0;

	public static string targetWord;
	public static int timeLeft = 10;



}