
public class LetterCheck
{


	public char[] checkLetter(char[] blankWord, string chosenWord, char userGuess)
	{

		for (int i = 0; i < chosenWord.Length; i++)
		{
			bool match = (userGuess == chosenWord[i]);
			if (match)
			{
				blankWord[i] = chosenWord[i];
			}



		}

		return blankWord;


	}
}