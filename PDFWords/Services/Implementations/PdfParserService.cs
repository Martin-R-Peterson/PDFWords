using App.Web.Services.Interfaces;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
namespace App.Web.Services.Implementations
{
    public class PdfParserService : IPdfParserService
    {
        public async Task<(int Words, int Characters, int DuplicateWords)> ParsedPdfAsync(Stream pdfStream)
        {
            return await Task.Run(() =>
            {
                var words = new List<string>();
                int characters = 0;

                using (PdfDocument document = PdfDocument.Open(pdfStream))
                {
                    foreach (Page page in document.GetPages())
                    {
                        foreach (Word word in page.GetWords())
                        {
                            words.Add(word.Text.ToLower());
                            characters += word.Text.Length;
                        }
                    }
                }
                int duplicateWords = words.Count - words.Distinct().Count();
                return (words.Count, characters, duplicateWords);
            });
        }
    }
}
