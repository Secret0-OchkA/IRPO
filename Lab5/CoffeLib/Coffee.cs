using System;
using System.Windows.Media.Imaging;

namespace Lab5.CoffeLib
{
    abstract class Coffee
    {
        protected int Price { get; set; }
        public string Image { get; set; }

        public virtual int GetPrice() => Price;
        public virtual BitmapImage GetImage()
            => new BitmapImage(new Uri(Image, UriKind.Relative));
    }

    #region CoffeeType
    class Americano : Coffee
    {
        public Americano()
        {
            Price = 100;
            Image = "Americano.jpg";
        }
    }
    class Cappuccino : Coffee
    {
        public Cappuccino()
        {
            Price = 110;
            Image = "Cappuccino.jpg";
        }
    }
    class Espresso : Coffee
    {
        public Espresso()
        {
            Price = 120;
            Image = "Espresso.jpg";
        }
    }
    class Cocoa : Coffee
    {
        public Cocoa()
        {
            Price = 130;
            Image = "Cocoa.jpg";
        }
    }
    #endregion



    abstract class CoffeeDecorator : Coffee
    {
        readonly Coffee baseComponet;

        public CoffeeDecorator(Coffee coffee) => baseComponet = coffee;

        public override int GetPrice() => Price + baseComponet.GetPrice();
        public override BitmapImage GetImage() => baseComponet.GetImage();
    }

    #region DecoratorsType
    class CoffeeMilk : CoffeeDecorator
    {
        public CoffeeMilk(Coffee coffee) : base(coffee) => Price = 10;
    }
    class CoffeeSugar : CoffeeDecorator
    {
        public CoffeeSugar(Coffee coffee) : base(coffee) => Price = 15;
    }
    #endregion



    class CoffeeMaker
    {
        Coffee makeCoffee;

        public CoffeeMaker BaseCoffee(Coffee coffee)
        {
            this.makeCoffee = coffee;
            return this;
        }

        public CoffeeMaker AddMilk()
        {
            makeCoffee = new CoffeeMilk(makeCoffee);
            return this;
        }
        public CoffeeMaker AddSugar()
        {
            makeCoffee = new CoffeeSugar(makeCoffee);
            return this;
        }

        public Coffee Build() => makeCoffee;

        public BitmapImage GetImage() => makeCoffee.GetImage();
    }
}
