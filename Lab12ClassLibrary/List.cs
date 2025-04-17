namespace Lab12;

public class List<T>
{
    public Point<T>? begin;

    public List()
    {
        begin = null;
    }

    public void Add(T item)
    {
        var newPoint = new Point<T>(item);
        if (begin == null)
            begin = newPoint;
        else
            AddToEnd(newPoint);
    }

    public void AddToEnd(Point<T> item)
    {
        var pointer = begin;
        while (pointer.Next != null)
            pointer = pointer.Next;
        pointer.Next = item;
    }

    public void AddToBegin(Point<T> item)
    {
        item.Next = begin;
        begin = item;   
    }

    public void Clear()
    {
        begin = null;
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
}