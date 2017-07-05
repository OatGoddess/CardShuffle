using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardShuffle.Models
{
    public class ViewCard
    {
        public string Suit { get; private set; }
        public string Value { get; private set; }

        public static List<ViewCard> Create(List<Card> data)
        {
            var result = new List<ViewCard>();

            foreach (var dataPoint in data)
            {
                result.Add(new ViewCard
                {
                    Suit = dataPoint.Suit.ToString().ToLower(),
                    Value = ValueFinder(dataPoint.Value)
                });
            }

            return result;
        }

        private static string ValueFinder(int cardValue)
        {
            switch (cardValue)
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

            return cardValue.ToString();
        }
    }
}
