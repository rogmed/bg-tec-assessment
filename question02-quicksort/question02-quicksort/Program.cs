using System.Globalization;

const int MaxElements = 10;

Console.WriteLine($"Quicksort (max {MaxElements} elements)");

int count;
while (true)
{
    Console.Write($"Enter number of elements to sort (1-{MaxElements}): ");
    var line = Console.ReadLine();
    if (int.TryParse(line, out count) && count >= 1 && count <= MaxElements)
        break;
    Console.WriteLine("Invalid number. Please enter an integer between 1 and 10.");
}

double[] items = new double[count];
for (int i = 0; i < count; i++)
{
    while (true)
    {
        Console.Write($"Element {i + 1}: ");
        var input = Console.ReadLine();
        if (double.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var v))
        {
            items[i] = v;
            break;
        }
        // Try parse with current culture as fallback (makes console friendlier)
        if (double.TryParse(input, out v))
        {
            items[i] = v;
            break;
        }
        Console.WriteLine("Invalid number. Enter an integer or floating point number.");
    }
}

Console.WriteLine("\nElements in input order:");
Console.WriteLine(string.Join(", ", items));

var sorted = Quicksorter.Sort(items);

Console.WriteLine("\nElements after quicksort:");
Console.WriteLine(string.Join(", ", sorted));

// Keep console open when run outside debugger
Console.WriteLine("\nPress Enter to exit...");
Console.ReadLine();
