
using DeckLibrary;

Console.WriteLine("1:вывести колоду\n2:перетосовать");
int act = Convert.ToInt32(Console.ReadLine());

Deck deck = new Deck();
switch(act)
{
    case 1: Console.WriteLine(deck); break;
    case 2: Console.WriteLine(deck.Shuffle()); break;
}