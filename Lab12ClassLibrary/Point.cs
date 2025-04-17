namespace Lab12;

public class Point<T>
{
    public T? Data { get; set; }
    
    public Point<T>? Next { get; set; }

    public Point()
    {
        Data = default(T);
        Next = null;
    }

    public Point(T value)
    {
        Data = value;
        Next = null;
    }

    public override string ToString()
    {
        return Data?.ToString() ?? "null";
    }
    
}