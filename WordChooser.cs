
public class WordChooser
  {
   Random rnd = new Random();
  public string chooseTargetWord (List <string> list)
  {
    int targetWord = rnd.Next (list.Count);
    return list[targetWord];
  }
  
  }