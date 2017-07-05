using CardShuffle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardShuffle.BL
{
    public class CardManager
    {
        private List<Card> _cards;

        public CardManager()
        {
            CreateCards();
        }

        public List<Card> CurrentCards
        {
            get
            {
                return _cards;
            }
        }

        private void CreateCards()
        {
            _cards = new List<Card>();

            for (int i = 1; i <= 13; i++)
            {
                _cards.Add(new Card(CardSuits.Clubs, i));
                _cards.Add(new Card(CardSuits.Diamonds, i));
                _cards.Add(new Card(CardSuits.Hearts, i));
                _cards.Add(new Card(CardSuits.Spades, i));
            }
        }

        public List<Card> Sort()
        {
            _cards = _cards.OrderBy(s => s.Value).ThenBy(s => s.Suit).ToList();

            return _cards;
        }

        public List<Card> Shuffle()
        {
            _cards.Shuffle();

            return _cards;
        }
    }
}
