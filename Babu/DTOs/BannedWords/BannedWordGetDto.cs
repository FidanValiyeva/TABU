using Babu.Entities;

namespace Babu.DTOs.BannedWords
{
    public class BannedWordGetDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
    }
}
