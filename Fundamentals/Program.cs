
List<string> toDos = [];

string userOption = "";
do
{
    Console.WriteLine("Hello!");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    userOption = Console.ReadLine();

    if(userOption.ToUpper() == "S")
    {
        if(toDos.Count == 0)
        {
            Console.WriteLine("No TODOs have been added yet.");
        }
        else
        {
            PrintToDos();
            Console.WriteLine("----");
            Console.WriteLine("What do you want to do?");
        }
    }
    else if(userOption.ToUpper() == "A")
    {
        string description = "";
        do
        {
            Console.Write("Enter the TODO description: ");
            description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("The description cannot be empty.");
            }
            else if (toDos.Contains(description))
            {
                Console.WriteLine("The description must be unique.");
            }
        }
        while (string.IsNullOrWhiteSpace(description));
        
        toDos.Add(description);
        Console.WriteLine($"TODO successfully added: {description}");
    }
    else if(userOption.ToUpper() == "R")
    {
        bool isRemoved = false;
        do
        {
            if (toDos.Count == 0)
            {
                Console.WriteLine("No TODOs have been added yet.");
                break;
            }
            else
            {
                Console.WriteLine("Select the index of the TODO you want to remove:");
                PrintToDos();
            }
            string indexString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(indexString))
            {
                Console.WriteLine("Selected index cannot be empty.");
            }
            else if (int.TryParse(indexString, out int index))
            {
                if (index < 1 || index > toDos.Count)
                {
                    Console.WriteLine("The given index is not valid.");
                }
                else
                {
                    toDos.RemoveAt(index - 1);
                    isRemoved = true;
                }
            }
            else
            {
                Console.WriteLine("You didn't even enter a number.");
            }
        }
        while (!isRemoved);
    }
}
while (userOption.ToUpper() != "E");

Console.WriteLine("Please, click something to close the app.");
Console.ReadKey();


void PrintToDos()
{
    for (int i = 0; i < toDos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {toDos[i]}.");
    }
}

// RemoveToDo, AddToDo, ShowToDos
