
public class LetterCheck
{


	public bool checkLetter(string chosenWord, char userGuess)
	{
		bool matchAdder = false;
		for (int i = 0; i < chosenWord.Length; i++)
		{
			bool match = (userGuess == chosenWord[i]);
			if (match)
			{
				matchAdder = true;
			}



		}


		return matchAdder;

	}
}