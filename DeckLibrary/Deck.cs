using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckLibrary
{
    public class Deck
    {
        const int deckSize = 52;
        List<Card> cards = new List<Card>(deckSize);

        public Deck()
        {
            for (Suit suit = 0; suit <= Suit.Spades; suit++)
                for (int rank = 1; rank <= 13; rank++)
                    cards.Add(new Card(rank, suit));
        }

        public Card this[int index]
        {
            get => cards[index];
            set => cards[index] = value;
        }
        
        public Deck Shuffle()
        {
            Random rnd = new Random(DateTime.Now.Second);
            cards = cards.OrderBy(c => rnd.Next()).ToList();
            return this;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            for(int i = 0,k = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++, k++)
                    stringBuilder.Append($"{cards[k].ToString()}\t");
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }
    }
}