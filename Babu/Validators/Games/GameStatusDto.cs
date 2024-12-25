using Babu.Entities;

namespace Babu.Validators.Games
{
    public class GameStatusDto
    {
        public int Success {  get; set; }
        public byte Fail {  get; set; } 
        public byte Skip {  get; set; }
        public Stack<Word>Words { get; set; }
        public int[] UsedWordIds { get; set; }

    }
}
