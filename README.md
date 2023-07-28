## Description:
Alright, detective, one of our colleagues successfully observed our target person, Robby the robber. We followed him to a secret warehouse, where we assume to find all the stolen stuff. The door to this warehouse is secured by an electronic combination lock. Unfortunately our spy isn't sure about the PIN he saw, when Robby entered it.

The keypad has the following layout:
```
┌───┬───┬───┐
│ 1 │ 2 │ 3 │
├───┼───┼───┤
│ 4 │ 5 │ 6 │
├───┼───┼───┤
│ 7 │ 8 │ 9 │
└───┼───┼───┘
    │ 0 │
    └───┘
```
He noted the PIN ```1357```, but he also said, it is possible that each of the digits he saw could actually be another adjacent digit (horizontally or vertically, but not diagonally). E.g. instead of the ```1``` it could also be the ```2``` or ```4```. And instead of the ```5``` it could also be the ```2```, ```4```, ```6``` or ```8```.

He also mentioned, he knows this kind of locks. You can enter an unlimited amount of wrong PINs, they never finally lock the system or sound the alarm. That's why we can try out all possible (*) variations.

(*) possible in sense of: the observed PIN itself and all variations considering the adjacent digits

Can you help us to find all those variations? It would be nice to have a function, that returns an array (or a list in Java/Kotlin and C#) of all variations for an observed PIN with a length of 1 to 8 digits. We could name the function ```getPINs``` (```get_pins``` in python, ```GetPINs``` in C#). But please note that all PINs, the observed one and also the results, must be strings, because of potentially leading '0's. We already prepared some test cases for you.

Detective, we are counting on you!

***For C# user:*** Do not use Mono. Mono is too slower when run your code.
### My solution
```C#
using System.Collections.Generic;

public class Kata
{
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

    public static List<string> FindAllPins(List<string> result, string currentSequence,
        string[] availableNumbers, int length)
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
```
