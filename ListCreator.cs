
public class ListCreator
  {
   
  
  public List<string> RemoveWords(string [] array, int p)
  {
      List <string> sourceFile = array.ToList();
      List <string> dictionary = new List<string>();
      for (int i=0; i<sourceFile.Count; i++)
      {
        string nom = sourceFile[i];
        if (nom.Length == p)
        {
          dictionary.Add(nom);
        }
        
      }
      
      return dictionary;
  }

    
}