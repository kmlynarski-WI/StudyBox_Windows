﻿using GalaSoft.MvvmLight.Messaging;
using StudyBox.Core.Models;

namespace StudyBox.Messages
{
    public class DataMessageToExam : MessageBase
    {
        public Deck DeckInstance { get; set; }

        public DataMessageToExam(Deck deck)
        {
            this.DeckInstance = deck;
        }
    }
}
