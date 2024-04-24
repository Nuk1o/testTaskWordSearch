using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

public class SearchWord
{
    private readonly string _filesDirectory = @"C:\Users\Nukio\source\repos\testTaskWordSearch\WordSearch\Properties\Resources\examples\";

    public async Task<List<TextFile>> FindWordAsync(string word)
    {
        List<TextFile> foundFiles = new List<TextFile>();

        string[] files = Directory.GetFiles(_filesDirectory);

        // Параллельный поиск по файлам
        await Task.WhenAll(files.Select(async filePath =>
        {
            FileInfo fileInfo = new FileInfo(filePath);
            TextFile textFile = new TextFile();

            if (textFile.FileContainsWord(filePath, word))
            {
                textFile.NameFile = fileInfo.Name;
                foundFiles.Add(textFile);
            }
        }));

        return foundFiles;
    }
}