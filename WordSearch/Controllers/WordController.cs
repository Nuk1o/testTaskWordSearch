using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace WordSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        /*public IActionResult SearchFile([FromQuery] string word)
        {
            List<TextFile> foundFiles = new List<TextFile>();
            TextFile textFile = new TextFile();
            FileInfo fileInfo;

            // Получаем все файлы в указанной директории
            string[] files = Directory.GetFiles(_filesDirectory);

            foreach (string filePath in files)
            {
                fileInfo = new FileInfo(filePath);

                if (textFile.FileContainsWord(filePath, word))
                {
                    textFile.NameFile = fileInfo.Name;
                    foundFiles.Add(textFile);
                }
            }
            if (foundFiles.Count == 0)
            {
                return Ok("Word not found");
            }
            string json = JsonSerializer.Serialize(foundFiles);

            return Ok(json);
        }*/
        [HttpGet, Route("search")]
        public async Task<IActionResult> SearchWordAsync([FromQuery] string word)
        {
            SearchWord searchWord = new SearchWord();
            var foundFiles = await searchWord.FindWordAsync(word);

            if (foundFiles.Count == 0)
            {
                return NotFound("Word not found");
            }

            string json = JsonSerializer.Serialize(foundFiles);
            return Ok(json);
        }
    }
}