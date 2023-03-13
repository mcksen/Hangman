
public class LetterCheck
{
	public delegate void WrongLetterEvent(char letter);
	public event WrongLetterEvent onWrongLetterPressed;
	// UseWrongGuess wrong = new UseWrongGuess();
	public char[] checkLetter(char[] blankWord, string chosenWord, char userGuess)
	{
		bool anyMatch = false;
		for (int i = 0; i < chosenWord.Length; i++)
		{
			bool match = (userGuess == chosenWord[i]);
			if (match)
			{
				blankWord[i] = chosenWord[i];
				anyMatch = true;
			}

		}
		if (!anyMatch && onWrongLetterPressed != null)
		{
			onWrongLetterPressed(userGuess);
		}



		return blankWord;


	}

}