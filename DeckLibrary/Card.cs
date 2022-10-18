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
            res += suit switch
            {
                Suit.Clubs => '♣',
                Suit.Diamonds => '♦',
                Suit.Hearts => '♥',
                Suit.Spades => '♠',
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