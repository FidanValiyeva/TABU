﻿using Babu.Entities;
using FluentValidation;
using System.Data;

namespace Babu.Validators.Games
{
    public class GameCreateDto
    {
       
        public int BannedWordCount { get; set; }
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public int Time { get; set; }       
        public string LanguageCode { get; set; }
       


    }
}