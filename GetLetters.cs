public class LetterGetter
{
    public List <string> GetLetters (string targetWord)
    {
        List <string> charArray = new List<string>();
        for (int i = 0; i<targetWord.Length; i++)
        {
            string letter = Convert.ToString(targetWord [i]);
            charArray.Add(letter);
        }
        return charArray;
    }
}