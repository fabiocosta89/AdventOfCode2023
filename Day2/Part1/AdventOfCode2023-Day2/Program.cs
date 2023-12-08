using System.Text.RegularExpressions;

string[] inputExample = [
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
    "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
    "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
];

Cubes requiredMaxCubes = new()
{
    Red = 12,
    Green = 13,
    Blue = 14
};

List<int> passingIds = [];

string[] inputFile = ReadInputFile();

//TransformInput(inputExample);
TransformInput(inputFile);

Console.WriteLine(passingIds.Sum());

string[] ReadInputFile()
{
    return File.ReadAllLines(@"input.txt");
}

void TransformInput(string[] input)
{
    foreach (string inputItem in input)
    {
        int gameId = int.Parse(Regex.Match(inputItem, @"\d+").Value);
        string[] splited = inputItem.Split(';');

        Cubes maxCubesInTheGame = new();

        foreach (string item in splited)
        {
            maxCubesInTheGame.Red = ExtractValues(maxCubesInTheGame.Red, item, @"\d+ red");
            maxCubesInTheGame.Green = ExtractValues(maxCubesInTheGame.Green, item, @"\d+ green");
            maxCubesInTheGame.Blue = ExtractValues(maxCubesInTheGame.Blue, item, @"\d+ blue");
        }

        if (maxCubesInTheGame.Red <= requiredMaxCubes.Red
            && maxCubesInTheGame.Green <= requiredMaxCubes.Green
            && maxCubesInTheGame.Blue <= requiredMaxCubes.Blue)
        {
            passingIds.Add(gameId);
        }
    }
}

int ExtractValues(int red, string item, string pattern)
{
    int redTest = ReturnNumberFromString(item, pattern);
    if (redTest > red)
    {
        return redTest;
    }

    return red;
}

int ReturnNumberFromString(string input, string pattern)
{
    Match red = Regex.Match(input, pattern);
    if (red.Success)
    {
        return int.Parse(Regex.Match(red.Value, @"\d+").Value);
    }

    return 0;
}

class Cubes
{
    public int Red { get; set; } = 0;
    public int Green { get; set; } = 0;
    public int Blue { get; set; } = 0;
}