using System;
using System.Linq;

var numbers = Input.Numbers
    .Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
    .Select(s => int.Parse(s));

var result = numbers.SelectMany(_ => numbers, (l, r) => new { Sum = l + r, Left = l, Right = r })
    .Where(triple => triple.Sum == 2020)
    .Select(triple => triple.Left * triple.Right)
    .First();

Console.WriteLine(result);
Console.ReadLine();
