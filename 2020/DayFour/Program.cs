using System;
using System.Linq;

// Part One
var result = Input.Passports.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries)
    .Select(p => p.Split(new[] { '\n', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries))
    .Select(passport =>
    {
        return passport.Select(part =>
        {
            var required = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            return required.Contains(part.Split(':')[0]);
        })
        .Sum(b => b ? 1 : 0);
    })
    .Where(s => s == 7)
    .Count();

Console.WriteLine(result);

// Part Two
result = Input.Passports.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries)
    .Select(p => p.Split(new[] { '\n', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries))
    .Select(passport =>
    {
        return passport.Select(part =>
        {
            var required = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            var field = part.Split(':')[0];
            var data = part.Split(':')[1];
            if (required.Contains(field))
            {
                return new { Field = field, Data = data };
            }
            return null;
        })
        .Select(tuple =>
        {
            var colours = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            return tuple?.Field switch
            {
                "byr" when int.TryParse(tuple.Data, out var number) && number >= 1920 && number <= 2002 => true,
                "iyr" when int.TryParse(tuple.Data, out var number) && number >= 2010 && number <= 2020 => true,
                "eyr" when int.TryParse(tuple.Data, out var number) && number >= 2020 && number <= 2030 => true,
                "hgt" when tuple.Data.Contains("in", StringComparison.InvariantCultureIgnoreCase) && int.TryParse(tuple.Data.TakeWhile(c => char.IsDigit(c)).ToArray(), out var number) && number >= 59 && number <= 76 => true,
                "hgt" when tuple.Data.Contains("cm", StringComparison.InvariantCultureIgnoreCase) && int.TryParse(tuple.Data.TakeWhile(c => char.IsDigit(c)).ToArray(), out var number) && number >= 150 && number <= 193 => true,
                "hcl" when tuple.Data.StartsWith('#') && tuple.Data.Skip(1).All(c => (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f')) => true,
                "ecl" when colours.Contains(tuple.Data) => true,
                "pid" when tuple.Data.Length == 9 && tuple.Data.All(c => char.IsDigit(c)) => true,
                _ => false,
            };
        })
        .Sum(b => b ? 1 : 0);
    })
    .Where(s => s == 7)
    .Count();

Console.WriteLine(result);

Console.ReadLine();
