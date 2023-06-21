using System.Collections.Generic;

public class Kata
{
    public static void Main()
    {
        // Test
        var t = GetPINs("11");
        // ...should return ["11", "12", "14", "21", "22", "24", "41", "42", "44"]
    }

    public static List<string> GetPINs(string observed)
    {
        var numbers = new string[observed.Length];

        for (int i = 0; i < observed.Length; i++)
        {
            numbers[i] = observed[i] switch
            {
                '1' => "124",
                '2' => "1235",
                '3' => "236",
                '4' => "1457",
                '5' => "24568",
                '6' => "3569",
                '7' => "478",
                '8' => "05789",
                '9' => "689",
                _ => "08",
            };
        }

        return FindAllPins(new List<string>(), "", numbers, observed.Length);
    }

    public static List<string> FindAllPins(List<string> result, string currentSequence, string[] availableNumbers, int length)
    {
        if (currentSequence.Length == length)
        {
            result.Add(currentSequence);
            return result;
        }

        foreach (char c in availableNumbers[currentSequence.Length])
            FindAllPins(result, new string(currentSequence + c), availableNumbers, length);

        return result;
    }
}