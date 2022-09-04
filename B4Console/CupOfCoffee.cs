using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B4
{
    public class CupOfCoffee : HotDrink, ICup
    {

        public string BeanType { get; set; } = "арабика";
        public double Capacity { get; set; } = 0.2;
        public string Volume { get; set; } = "пластик";

        public override void AddMilk(int milk)
        {
            Milk = milk;
            Console.WriteLine($"В кофе добавлено молоко: {Milk}");
        }

        public override void AddSugar(int sugar)
        {
            Sugar = sugar;
            Console.WriteLine($"В кофе добавлен сахар: {Sugar}");
        }

        public void Refill()
        {
            Console.WriteLine($"Повторить кофе объемом {Capacity} мл");
        }

        public void Wash()
        {
            Console.WriteLine($"Вымыть {BeanType} чашку с кофе");
        }

        public override void stringDrink()
        {
            Console.WriteLine($"Получите кофе: {BeanType}");
        }
    }

    public class CupOfTea : HotDrink, ICup
    {

        public string LeafType { get; set; } = "черный";
        public double Capacity { get; set; } = 0.2;
        public string Volume { get; set; } = "пластик";

        public override void AddMilk(int milk)
        {
            Milk = milk;
            Console.WriteLine($"В чай добавлено молоко: {Milk}");
        }

        public override void AddSugar(int sugar)
        {
            Sugar = sugar;
            Console.WriteLine($"В чай добавлен сахар: {Sugar}");
        }

        public void Refill()
        {
            Console.WriteLine($"Повторить чай объемом {Capacity} мл");
        }

        public void Wash()
        {
            Console.WriteLine($"Вымыть {LeafType} чашку с чаем");
        }

        public override void stringDrink()
        {
            Console.WriteLine($"Получите чай: {LeafType}");
        }
    }
}