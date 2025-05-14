using ClassLibraryLab10;
using System;

namespace Lab12;

public class List<T> where T : IInit, new()
{
    public ListNode<T>? begin;
    public ListNode<T>? end;

    public List()
    {
        begin = null;
        end = null;
    }

    public List(int length)
    {
        for (int i = 0; i < length; i++)
        {
            var data = new T();
            data.RandomInit();
            var item = new ListNode<T>(data);
            Add(item.Data); 
        }
    }

    public void Add(T item)
    {
        var newListNode = new ListNode<T>(item);
        if (begin == null)
            begin = end = newListNode;
        else
        {
            end.Next = newListNode;
            newListNode.Previous = end;
            end = newListNode;
        }
    }

    public void AddToBegin(T item)
    {
        var newListNode = new ListNode<T>(item);
        if (begin == null)
            begin = end = newListNode;
        else
        {
            newListNode.Next = begin;
            begin.Previous = newListNode;
            begin = newListNode;
        }
    }

    public void AddAt(T item, int listNode)
    {
        if (listNode < 1) throw new ArgumentOutOfRangeException("Номер меньше 1."); ;
        var newListNode = new ListNode<T>(item);
        if (begin == null && listNode == 1)
        {
            begin = end = newListNode;
            return;
        }

        if (listNode == 1)
        {
            newListNode.Next = begin;
            begin.Previous = newListNode;
            begin = newListNode;
            return;
        }

        var current = begin;
        for (var i = 1; i < listNode; i++)
        {
            if (current == null)
                throw new ArgumentOutOfRangeException("Номер выходит за пределы списка.");
            current = current.Next;
        }

        if (current == null)
        {
            end.Next = newListNode;
            newListNode.Previous = end;
            end = newListNode;
        }
        else
        {
            newListNode.Next = current;
            newListNode.Previous = current.Previous;
            if (current.Previous != null)
                current.Previous.Next = newListNode;
            current.Previous = newListNode;
        }
    }

    public void Clear()
    {
        begin = null;
        end = null;
    }

    public bool Contains(T item)
    {
        var current = begin;
        while (current != null && !current.Equals(item))
            current = current.Next;
        return current != null;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null)
            throw new Exception("array is null");
        if (arrayIndex < 0 || arrayIndex >= array.Length)
            throw new Exception("arrayIndex is out of range");
        if (array.Length - arrayIndex < Count)
            throw new Exception("Not enough elements in array");
        var current = begin;
        var i = arrayIndex;
        while (current != null && i < array.Length)
        {
            array[i++] = current.Data;
            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        if (begin.Data.Equals(item))
        {
            begin = begin.Next;
            return true;
        }
        else
        {
            var current = begin;
            while (current != null && !current.Equals(item))
                current = current.Next;
            if (current == null)
                return false;
            else
            {
                current.Next = current.Next.Next;
                return true;
            }
        }    
    }

    public void RemoveAfter(T item)
    {
        if (begin == null) throw new Exception("Список пуст.");

        var current = begin;

        while (current != null && !current.Data.Equals(item))
            current = current.Next;

        if (current == null) throw new Exception($"В списке нет элемента с информационным полем {item}.");

        current.Next = null;
        end = current;
    }

    public int Count
    {
        get
        {
            int count = 0;
            if (begin == null) return 0;
            var current = begin;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    public void PrintList()
    {
        var current = begin;
        var count = 1;
        while (current != null)
        {
            Console.WriteLine($"{count}: {current.Data}");
            current = current.Next;
            count++;
        }
    }

    public object Clone()
    {
        var newList = new List<T>();
        if (begin == null) return newList;

        var current = begin;
        while (current != null)
        {
            var newItem = (T)((ICloneable)current.Data!).Clone();
            newList.Add(newItem);
            current = current.Next;
        }
        return newList;
    }
}