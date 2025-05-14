using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12;

public class HashEntry<T>
{
    public T? Key { get; set; }
    public T? Value { get; set; }
    public HashEntry<T>? Next { get; set; }

    public HashEntry()
    {
        Key = default(T);
        Value = default(T);
        Next = null;
    }

    public HashEntry(T key, T value)
    {
        Key = key;
        Value = value;
        Next = null;
    }

    public override string ToString()
    {
        return Value?.ToString() ?? "null";
    }

    public override int GetHashCode()
    {
        return Value?.GetHashCode() ?? 0;
    }
}