public static class ScoreManager
{

	private static string path = "C:/tmp/hangmanScore.txt";

	public static void TrySetHighScore()
	{
		if (GameData.currentScore > GameData.highScore)
		{
			GameData.highScore = GameData.currentScore;
			Save();
		}
	}

	public static void Save()
	{

		File.WriteAllText(path, GameData.highScore.ToString());

	}


	public static void Load()
	{
		if (File.Exists(path))
		{
			GameData.highScore = int.Parse(File.ReadAllText(path));
		}
	}
}