using B4;

HotDrink drink;
Console.Write("Выберете напито: кофе(1) или чай(2):");
Console.ForegroundColor = ConsoleColor.Red;
int type = Convert.ToInt32(Console.ReadLine());
Console.ResetColor();
if (type == 1)
{
    drink = new CupOfCoffee();
    Console.WriteLine("Тип зерна: арабика или робуста (по умолч. арабика);");
}
else
{
    drink = new CupOfTea();
    Console.WriteLine("Тип листья: зелоный или черный (по умолч. черный);"); 
}

Console.WriteLine("Молоко: 0...10 (по умолч. 3);");
Console.WriteLine("Сахар: 0...5 (по умолч. 3);");
Console.WriteLine("Тип стакана: пластик или стекло (по умолч. пластик);");
Console.WriteLine("Объем: 0,2 или 0,3 (по умолч. 0,2);");

if (type == 1)
    Console.Write("Тпи зерна: ");
else
    Console.Write("Тип листьев: ");
Console.ForegroundColor = ConsoleColor.Red;
string? drinkTypeNull = Console.ReadLine();
string drinkType = drinkTypeNull == null ? "" : drinkTypeNull;
Console.ResetColor();

if (drink is CupOfCoffee coffee)
    coffee.BeanType = drinkType;
else if(drink is CupOfTea tea)
    tea.LeafType = drinkType;

Console.Write("Молоко: ");
Console.ForegroundColor = ConsoleColor.Red;
int milk = Convert.ToInt32(Console.ReadLine());
Console.ResetColor();

Console.Write("Cахар: ");
Console.ForegroundColor = ConsoleColor.Red;
int sugar = Convert.ToInt32(Console.ReadLine());
Console.ResetColor();

Console.Write("Тип стакана: ");
Console.ForegroundColor = ConsoleColor.Red;
string? cupTypeNull = Console.ReadLine();
string cupType = cupTypeNull == null ? "" : cupTypeNull;
Console.ResetColor();

Console.Write("Объем (мл): ");
Console.ForegroundColor = ConsoleColor.Red;
double capacity = Convert.ToDouble(Console.ReadLine());
Console.ResetColor();
if(drink is ICup cup)
{
    cup.Capacity = capacity;
    cup.Volume = cupType;
}

ProcessCup(drink);

void ProcessCup(HotDrink drink)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    drink.AddMilk(milk);
    drink.AddSugar(sugar);
    drink.stringDrink();
    if (drink is ICup cup)
    {

        Console.ForegroundColor = ConsoleColor.Green;
        cup.Wash();
        cup.Refill();
    }
    Console.ResetColor();
}