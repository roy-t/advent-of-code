using System;
using System.Linq;

// Part One
var result = Input.Groups.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries)
    .Select(answers =>
        answers.ToCharArray()
        .Where(c => char.IsLetter(c))
        .Distinct()
        .Count())
    .Sum();

Console.WriteLine(result);

// Part Two
result = Input.Groups.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries)
    .Select(answers =>
        answers.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(answer => answer.ToCharArray().ToHashSet())
        .Aggregate((a, b) => { a.IntersectWith(b); return a; })
        .Count())
    .Sum();

Console.WriteLine(result);

Console.ReadLine();
