public class TextFile
{
    public string NameFile { get; set; }

    public bool FileContainsWord(string filePath, string word)
    {
        string text = File.ReadAllText(filePath);
        return text.Contains(word);
    }
}