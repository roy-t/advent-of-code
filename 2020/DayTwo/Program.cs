using System;
using System.Linq;
using MoreLinq;

// Part One
var valid = Input.Passwords
    .Split(new char[] { '-', ' ', ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
    .Batch(4, e => e.ToArray())
    .Select(batch => new { Min = int.Parse(batch[0]), Max = int.Parse(batch[1]), Letter = batch[2][0], Password = batch[3] })
    .Where(p => p.Password.Count(c => c == p.Letter) >= p.Min)
    .Where(p => p.Password.Count(c => c == p.Letter) <= p.Max)
    .Count();

Console.WriteLine(valid);

// Part Two
valid = Input.Passwords
    .Split(new char[] { '-', ' ', ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
    .Batch(4, e => e.ToArray())
    .Select(batch => new { Min = int.Parse(batch[0]), Max = int.Parse(batch[1]), Letter = batch[2][0], Password = batch[3] })
    .Where(p => p.Password[p.Min - 1] == p.Letter ^ p.Password[p.Max - 1] == p.Letter)
    .Count();

Console.WriteLine(valid);
Console.ReadLine();
