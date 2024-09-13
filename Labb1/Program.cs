
string userInput = GetUserInput();
Console.WriteLine();

long totalSum = 0;

for (int i = 0; i < userInput.Length; i++)
{
    char startChar = userInput[i];
    if (!char.IsDigit(startChar))
    {
        continue;
    }

    bool numberPatternWasFound = NumberPatternWasFound(i, startChar, userInput);
    if (!numberPatternWasFound)
    {
        continue;
    }

    string pattern = WriteColoredUserInputAndGetPattern(i, startChar, userInput);

    if (long.TryParse(pattern, out long rowNumber))
    {
        totalSum += rowNumber;
    }

    Console.ResetColor();
    Console.WriteLine();
}

Console.WriteLine($"\nTotal: {totalSum}");

static string GetUserInput()
{
    Console.WriteLine("Write a text of your choice");
    return Console.ReadLine();
}

static bool NumberPatternWasFound(int i, char startChar, string userInput)
{
    for (int j = i + 1; j < userInput.Length; j++)
    {
        if (!char.IsDigit(userInput[j]))
        {
            return false;
        }

        if (userInput[j] == startChar)
        {
            return true;
        }
    }

    return false;
}

static string WriteColoredUserInputAndGetPattern(int i, char startChar, string userInput)
{
    bool changeColor = false;
    string pattern = "";
    for (int k = 0; k < userInput.Length; k++)
    {
        char charToWrite = userInput[k];

        if (k >= i && !changeColor)
        {
            pattern += userInput[k];
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        Console.Write(charToWrite);

        if (k > i && charToWrite == startChar)
        {
            changeColor = true;
        }
    }

    return pattern;
}

