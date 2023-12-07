List<string> inputExamples = [
    "1abc2",
    "pqr3stu8vwx",
    "a1b2c3d4e5f",
    "treb7uchet"
    ];

List<int> digits = [];
//inputExamples.ForEach(digit => digits.Add(GetDigits(digit)));

ReadInputFile().ForEach(digit => digits.Add(GetDigits(digit)));

Console.WriteLine(GetTotal(digits));

List<string> ReadInputFile() => File.ReadAllLines(@"Input\input.txt").ToList();

int GetDigits(string input)
{
    char[] chars = input.Where(char.IsDigit).ToArray();
    string firstLast = string.Concat(chars[0],chars[chars.Length - 1]);
    return Convert.ToInt32(firstLast);
}

int GetTotal(IEnumerable<int> inputValues)
{
    return inputValues.Sum();
}
