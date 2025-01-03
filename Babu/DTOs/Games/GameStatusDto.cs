﻿using Babu.DTOs.Words;
using Babu.Entities;

namespace Babu.DTOs.Games
{
    public class GameStatusDto
    {
        public int Success { get; set; }
        public byte Fail { get; set; }
        public byte Skip { get; set; }
        public Stack<WordForGameDto> Words { get; set; }
        public IEnumerable<int> UsedWordIds { get; set; }
        public int MaxSkipCount {  get; set; }
    }
}
