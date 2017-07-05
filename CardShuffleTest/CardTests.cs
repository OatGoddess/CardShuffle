using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardShuffle.BL;
using CardShuffle.Models;
using System.Collections.Generic;

namespace CardShuffleTest
{
    [TestClass]
    public class CardTests
    {
        private bool CompareCards(List<ViewCard> x, List<ViewCard> y)
        {
            if(x.Count != y.Count)
            {
                return false;
            }

            for (int i = 0; i < x.Count; i++)
            {
                if(!((x[i].Suit == y[i].Suit) && (x[i].Value == y[i].Value)))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CompareCards(List<Card> x, List<ViewCard> y)
        {
            if (x.Count != y.Count)
            {
                return false;
            }

            for (int i = 0; i < x.Count; i++)
            {
                if (!((x[i].Suit.ToString().ToLower() == y[i].Suit) && (ValueConverter(x[i].Value) == y[i].Value)))
                {
                    return false;
                }
            }

            return true;
        }

        private string ValueConverter(int value)
        {
            switch (value)
            {
                case 11:
                    return "jack";
                case 12:
                    return "queen";
                case 13:
                    return "king";
                case 1:
                    return "ace";
            }

            return value.ToString();
        }

        [TestMethod]
        public void CardShuffleTest()
        {
            var cardManager = new CardManager();
            var startingCards = ViewCard.Create(cardManager.CurrentCards);
            var result = ViewCard.Create(cardManager.Shuffle());

                Assert.IsFalse(CompareCards(startingCards, result));
        }

        [TestMethod]
        public void CardSortTest()
        {
            var cardManager = new CardManager();
            var startingCards = ViewCard.Create(cardManager.CurrentCards);
            var result = ViewCard.Create(cardManager.Sort());

                Assert.IsTrue(CompareCards(startingCards, result));
        }

        [TestMethod]
        public void CardShuffleThenSortTest()
        {
            var cardManager = new CardManager();
            var startingCards = ViewCard.Create(cardManager.CurrentCards);
            var shuffleResult = ViewCard.Create(cardManager.Shuffle());

                Assert.IsFalse(CompareCards(startingCards, shuffleResult));

            var result = ViewCard.Create(cardManager.Sort());

                Assert.IsTrue(CompareCards(startingCards, result));
        }

        [TestMethod]
        public void CreateViewCard()
        {
            var cardManager = new CardManager();
            var startingCards = cardManager.CurrentCards;

            var result = ViewCard.Create(startingCards);

            Assert.IsTrue(CompareCards(startingCards, result));
        }
    }
}
