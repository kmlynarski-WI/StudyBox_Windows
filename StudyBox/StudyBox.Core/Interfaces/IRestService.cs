﻿using StudyBox.Core.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudyBox.Core.Interfaces
{
    public interface IRestService
    {
        Task<List<Flashcard>> GetFlashcards(string deckId);
        Task<List<Flashcard>> GetFlashcards(string deckId, CancellationTokenSource cts);
        Task<Flashcard> GetFlashcardById(string deckId, string flashcardId);
        Task<Flashcard> GetFlashcardById(string deckId, string flashcardId, CancellationTokenSource cts);
        Task<Flashcard> CreateFlashcard(Flashcard flashcard, string deckId, CancellationTokenSource cts);
        Task<Flashcard> CreateFlashcard(Flashcard flashcard, string deckId);
        Task<bool> UpdateFlashcard(Flashcard flashcard, string deckId);
        Task<bool> UpdateFlashcard(Flashcard flashcard, string deckId, CancellationTokenSource cts);
        Task<bool> RemoveFlashcard(string deckId, string flashcardId);
        Task<bool> RemoveFlashcard(string deckId, string flashcardId, CancellationTokenSource cts);
        Task<List<Deck>> GetDecks();
        Task<List<Deck>> GetDecks(CancellationTokenSource cts);
        Task<Deck> GetDeckById(string deckId);
        Task<Deck> GetDeckById(string deckId, CancellationTokenSource cts);
        Task<List<Deck>> GetDecksByName(string name);
        Task<List<Deck>> GetDecksByName(string name, CancellationTokenSource cts);
        Task<Deck> CreateDeck(Deck deck);
        Task<Deck> CreateDeck(Deck deck, CancellationTokenSource cts);
        Task<bool> UpdateDeck(Deck deck);
        Task<bool> UpdateDeck(Deck deck, CancellationTokenSource cts);
        Task<bool> RemoveDeck(string deckId);
        Task<bool> RemoveDeck(string deckId, CancellationTokenSource cts);
    }
}