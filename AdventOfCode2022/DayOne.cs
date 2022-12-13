namespace AdventOfCode2022;

public class DayOne
{
    public void Run()
    {
        var input = LoadInput();

        var elves = new Dictionary<int, int>();
        var elfCounter = 0;

        var numberOneElf = -1;
        var numberOneElfFood = -1;

        foreach (var s in input)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                elfCounter++;
                continue;
            }

            elves.TryGetValue(elfCounter, out var currentTotal);
            int.TryParse(s, out var lineVal);
            currentTotal += lineVal;
            elves[elfCounter] = currentTotal;

            if (numberOneElfFood < currentTotal)
            {
                numberOneElf = elfCounter;
                numberOneElfFood = currentTotal;
            }
        }

        Console.WriteLine($"Number One Elf is: {numberOneElf} with {numberOneElfFood} calories");

        var foodList = elves.Values.ToList();
        foodList = foodList.OrderDescending().ToList();

        var topThreeTotal = 0;
        for (int i = 0; i < 3; i++)
        {
            topThreeTotal += foodList[i];
        }
        
        Console.WriteLine($"Top Three Total: {topThreeTotal} calories");
    }

    private string[] LoadInput()
    {
        return File.ReadAllLines(@"Inputs\DayOneInput.txt");
    }
}