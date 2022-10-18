using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckLibrary
{
    public class Card  
    {
        private Card() { }

        public Card(int rank, Suit suit)
        {
            if(rank < 1 && rank > 13) throw new ArgumentOutOfRangeException();

            this.rank = rank;
            this.suit = suit;
        }

        public int rank { get; private set; }
        public Suit suit { get; private set; }

        public override string ToString()
        {
            string res = rank.ToString();
            switch(suit)
            {
                case Suit.Clubs: res += '♣'; break;
                case Suit.Diamonds: res += '♦'; break;
                case Suit.Hearts: res += '♥'; break;
                case Suit.Spades: res += '♠'; break;
            };
            return res;
        }
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades,
    }
}