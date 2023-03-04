
public class LetterCheck
{
   
  string matchAdder = "";
  
  public string checkLetter(string chosenWord, char userGuess)
  {
      for (int i= 0; i<chosenWord.Length; i++)
      {
        bool match = (userGuess == chosenWord[i]);
        if (match)
        {
          matchAdder += userGuess;
        }
        else
        {
           matchAdder += " _ ";
        }

      }
      
      
      return  matchAdder;
      
  }
}