public class LetterGetter
{
    string sp ="";
    public string GetLetters (string targetWord)
    {
        for (int i = 0; i<targetWord.Length; i++)
        {
            char letter = targetWord [i];
            sp += Convert.ToString(letter);
        }
        return sp;
    }
}