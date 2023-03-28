
using System.Text;
using SFML.Graphics;

public class LetterCheck
{

	public delegate void WrongLetterEvent(char letter);
	public event WrongLetterEvent onWrongLetterPressed;

	// UseWrongGuess wrong = new UseWrongGuess();
	public string checkLetter(string blankWord, string chosenWord, char userGuess)
	{
		bool anyMatch = false;
		StringBuilder stringbuilder = new StringBuilder(blankWord);

		for (int i = 0; i < chosenWord.Length; i++)
		{
			bool match = (userGuess == chosenWord[i]);
			if (match)
			{

				stringbuilder[i] = chosenWord[i];
				anyMatch = true;
			}

		}
		if (!anyMatch && onWrongLetterPressed != null)
		{
			onWrongLetterPressed(userGuess);

		}



		return stringbuilder.ToString();


	}

}