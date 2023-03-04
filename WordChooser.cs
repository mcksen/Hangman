
public class WordChooser
  {
   Random rnd = new Random();
  public string chooseTargetWord (List <string> list)
  {
    int targetWord = rnd.Next (list.Count);
    return list[targetWord];
  }
  string targetWordSpace = "";
  public string hideLetters (string word)
  {
    foreach (int i in word)
        {
          targetWordSpace += " _ ";
        }

      return targetWordSpace;
    }
  }