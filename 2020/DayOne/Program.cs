using System;
using System.Linq;

var numbers = Input.Numbers
    .Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
    .Select(s => int.Parse(s));

// Part one
var result = numbers
    .SelectMany(_ => numbers, (l, r) => new { Sum = l + r, A = l, B = r })
    .Where(triple => triple.Sum == 2020)
    .Select(triple => triple.A * triple.B)
    .First();

Console.WriteLine(result);

// Part two
var result2 = numbers
    .SelectMany(_ => numbers, (l, r) => new { Sum = l + r, A = l, B = r })
    .SelectMany(_ => numbers, (l, r) => new { Sum = l.Sum + r, A = l.A, B = l.B, C = r })
    .Where(triple => triple.Sum == 2020)
    .Select(triple => triple.A * triple.B * triple.C)
    .First();

Console.WriteLine(result2);

Console.ReadLine();
