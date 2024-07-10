namespace App.Web.Models.ViewModels
{
    public class PdfView
    {
        public Guid Guid { get; set; }
        public int Words { get; set; }
        public int Characters { get; set; }
        public int DuplicateWords { get; set; }

        public PdfView From(PDF pdf)
        {
            return new PdfView
            {
                Guid = pdf.Guid,
                Words = pdf.Words,
                Characters = pdf.Characters,
                DuplicateWords = pdf.DuplicateWords
            };
        }
    }
}
