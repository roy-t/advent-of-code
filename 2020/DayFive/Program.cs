using System;
using System.Collections;
using System.Linq;

// Part One
var result = Input.BoardingPasses.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
    .Select(p => p.ToCharArray())
    .Select(p => new { Row = p.Take(7).ToArray(), Column = p.Skip(7).Take(3).ToArray() })
    .Select(p =>
    {
        var bitarray = new BitArray(p.Row.Select(c => c == 'B' ? true : false).Reverse().ToArray());
        var bytes = new byte[1];
        bitarray.CopyTo(bytes, 0);
        var row = bytes[0];

        bitarray = new BitArray(p.Column.Select(c => c == 'R' ? true : false).Reverse().ToArray());
        bytes = new byte[1];
        bitarray.CopyTo(bytes, 0);
        var column = bytes[0];

        return new { Row = row, Column = column };
    })
    .Select(p => p.Row * 8 + p.Column)
    .Max();

Console.WriteLine(result);

// Part Two
var allIds = Enumerable.Range(0, 128).SelectMany(_ => Enumerable.Range(0, 8), (l, r) => new { Row = (byte)l, Column = (byte)r })
    .Select(p => (p.Row * 8) + p.Column);

var seen = Input.BoardingPasses.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
    .Select(p => p.ToCharArray())
    .Select(p => new { Row = p.Take(7).ToArray(), Column = p.Skip(7).Take(3).ToArray() })
    .Select(p =>
    {
        var bitarray = new BitArray(p.Row.Select(c => c == 'B' ? true : false).Reverse().ToArray());
        var bytes = new byte[1];
        bitarray.CopyTo(bytes, 0);
        var row = bytes[0];

        bitarray = new BitArray(p.Column.Select(c => c == 'R' ? true : false).Reverse().ToArray());
        bytes = new byte[1];
        bitarray.CopyTo(bytes, 0);
        var column = bytes[0];

        return new { Row = row, Column = column };
    })
    .Select(p => (p.Row * 8) + p.Column)
    .ToHashSet();

var myId = allIds.Where(id => !seen.Contains(id) && seen.Contains(id + 1) && seen.Contains(id - 1)).Single();

Console.WriteLine(myId);

Console.ReadLine();
