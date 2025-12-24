// See https://aka.ms/new-console-template for more information
using System.Globalization;

var encoding = Console.OutputEncoding;

var omega = 'Ω';
Console.WriteLine(omega);
Console.WriteLine((int)omega);

CultureInfo cultureInfo = CultureInfo.CurrentCulture;
double num = 1.56;
Console.WriteLine(num);

CultureInfo.CurrentCulture = new CultureInfo("en-US");
Console.WriteLine(num);

var date = new DateTime(2025, 3, 2, 12, 16, 14);
Console.WriteLine(date.ToString("d", CultureInfo.InvariantCulture));

Console.ReadKey();
