using System;
using System.Linq;

// Part One
var trees = Input.Slope
    .Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
    .Select((s, i) => new { Slope = s, Offset = i * 3 })
    .Select(s => s.Slope[s.Offset % s.Slope.Length] == '#' ? 1 : 0)
    .Sum();

Console.WriteLine(trees);

// Part Two
var move0 = new { X = 1, Y = 1, Id = 0 };
var move1 = new { X = 3, Y = 1, Id = 1 };
var move2 = new { X = 5, Y = 1, Id = 2 };
var move3 = new { X = 7, Y = 1, Id = 3 };
var move4 = new { X = 1, Y = 2, Id = 4 };

var moves = new[] { move0, move1, move2, move3, move4 };

var result = Input.Slope
    .Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
    .Select((s, i) => new { Slope = s, Index = i })
    .SelectMany(_ => moves, (l, r) => new { Slope = l.Slope, Index = l.Index, MoveX = r.X, MoveY = r.Y, MoveId = r.Id })
    .Where(s => s.Index % s.MoveY == 0)
    .Select(s => new { Tree = s.Slope[s.MoveX * s.Index / s.MoveY % s.Slope.Length] == '#' ? 1 : 0, MoveId = s.MoveId })
    .GroupBy(s => s.MoveId)
    .Select(g => g.Sum(s => (double)s.Tree))
    .Aggregate((a, b) => a * b);

Console.WriteLine(result);

Console.ReadLine();
