
Console.WriteLine("Hello!");
int num1 = AskForNumber("Input the first number");
int num2 = AskForNumber("Input the second number");
string action = AskForAction();
Calculate(action, num1, num2);

Console.WriteLine("Press any key to close");
Console.ReadKey();

int AskForNumber(string question)
{
    Console.WriteLine(question + ": ");
    string numText = Console.ReadLine();
    int number = 0;
    if(!int.TryParse(numText, out number))
    {
        throw new Exception("You trippin'");
    }
    return number;
}

string AskForAction()
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[A]dd numbers");
    Console.WriteLine("[S]ubtract numbers");
    Console.WriteLine("[M]ultiply numbers");

    return Console.ReadLine();
}

void Calculate(string action, int num1, int num2)
{
    if(IsLetterEqualInsensitive(action, "A"))
    {
        Console.WriteLine($"{num1} + {num2} = " + (num1 + num2));
    }
    else if (IsLetterEqualInsensitive(action, "S"))
    {
        Console.WriteLine($"{num1} - {num2} = " + (num1 - num2));
    }
    else if(IsLetterEqualInsensitive(action, "M"))
    {
        Console.WriteLine($"{num1} * {num2} = " + (num1 * num2));
    }
    else
    {
        Console.WriteLine("Invalid choice!");
    }
}

bool IsLetterEqualInsensitive(string letter, string expected)
{
    return letter.ToUpper() == expected.ToUpper();
}



char ConvertToGrade(int points)
{
    return points switch
    {
        >= 9 => 'A',
        >= 6 => 'B',
        0 => 'F',
        _ => '!',
    };
}
