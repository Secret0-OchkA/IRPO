
using _4С;

orders order = new orders { itemname = "name", unitCount = 10, unitCost = 2.5 };
Console.WriteLine($"{order.itemname} cost: {order.Cost}");