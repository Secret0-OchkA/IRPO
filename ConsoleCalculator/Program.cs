using Lab2;

Calculator calculator = new Calculator();

double a = 10, b = 20;
Console.WriteLine($"{a} + {b} = {calculator.Sum(a, b)}");
Console.WriteLine($"{a} - {b} = {calculator.Sub(a, b)}");
Console.WriteLine($"{a} / {b} = {calculator.Div(a, b)}");
Console.WriteLine($"{a} * {b} = {calculator.Mul(a, b)}");