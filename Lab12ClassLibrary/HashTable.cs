using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12;

public class HashTable<T>
{
    private const int DefaultCapacity = 16;
    private HashEntry<T>[] entries;
    public HashTable(int capacity = DefaultCapacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.");

        entries = new HashEntry<T>[capacity];
    }
    
    private int GetEntryIndex(T key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        return Math.Abs(key.GetHashCode()) % entries.Length;
    }
    
    public void Add(T key, T value)
    {
        int index = GetEntryIndex(key);

        // Создаем новыую запись
        var newEntry = new HashEntry<T>(key, value);

        // Если запись пуста, добавляем как первый элемент
        if (entries[index] == null)
        {
            entries[index] = newEntry;
        }
        else
        {
            // Иначе добавляем в начало цепочки
            newEntry.Next = entries[index];
            entries[index] = newEntry;
        }
    }
    
    public T Find(T key)
    {
        int index = GetEntryIndex(key);
        var current = entries[index];

        // Проходим по цепочке, пока не найдем нужный ключ
        while (current != null)
        {
            if (current.Key.Equals(key))
                return current.Value;

            current = current.Next;
        }
        
        throw new KeyNotFoundException($"Key '{key}' not found.");
    }
    
    public bool Remove(T key)
    {
        int index = GetEntryIndex(key);
        var current = entries[index];
        HashEntry<T> previous = null;

        // Проходим по цепочке, чтобы найти элемент
        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                // Если это первый элемент в цепочке
                if (previous == null)
                    entries[index] = current.Next;
                else
                    previous.Next = current.Next;

                return true; // Элемент удален
            }

            previous = current;
            current = current.Next;
        }

        return false; // Ключ не найден
    }
    
    public bool ContainsKey(T key)
    {
        int index = GetEntryIndex(key);
        var current = entries[index];

        while (current != null)
        {
            if (current.Key.Equals(key))
                return true;

            current = current.Next;
        }

        return false;
    }
    
    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();

        for (int i = 0; i < entries.Length; i++)
        {
            sb.Append($"Entry {i}: ");
            var current = entries[i];

            if (current == null)
            {
                sb.AppendLine("empty");
            }
            else
            {
                while (current != null)
                {
                    sb.Append($"{current.Key} -> {current.Value}");
                    current = current.Next;

                    if (current != null)
                        sb.Append(" -> ");
                }
                sb.AppendLine();
            }
        }

        return sb.ToString();
    }
}