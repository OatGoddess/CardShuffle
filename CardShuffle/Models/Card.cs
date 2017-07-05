using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardShuffle.Models
{
    public enum CardSuits
    {
        Clubs = 1,
        Diamonds = 2,
        Hearts = 3,
        Spades = 4
    };

    public class Card
    {
        public Card(CardSuits suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        public CardSuits Suit { get; private set; }
        public int Value { get; private set; }
    }
}
