using System.Text.RegularExpressions;

List<string> inputExamples = [
    "two1nine",
    "eightwothree",
    "abcone2threexyz",
    "xtwone3four",
    "4nineeightseven2",
    "zoneight234",
    "7pqrstsixteen"
];

List<int> digits = [];
//inputExamples.ForEach(digit => digits.Add(GetDigits(digit)));

ReadInputFile().ForEach(digit => digits.Add(GetDigitWithRegex(digit)));

Console.WriteLine(GetTotal(digits));

List<string> ReadInputFile() => File.ReadAllLines(@"Input\input.txt").ToList();

int GetDigitWithRegex(string input)
{
    Match digit1 = Regex.Match(input, @"\d|one|two|three|four|five|six|seven|eight|nine");
    Match digit2 = Regex.Match(input, @"\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.RightToLeft);

    return ParseMatch(digit1.Value) * 10 + ParseMatch(digit2.Value);
}

int ParseMatch(string input) => input switch
{
    "one" => 1,
    "two" => 2,
    "three" => 3,
    "four" => 4,
    "five" => 5,
    "six" => 6,
    "seven" => 7,
    "eight" => 8,
    "nine" => 9,
    var d => int.Parse(d)
};

int GetTotal(IEnumerable<int> inputValues)
{
    return inputValues.Sum();
}
