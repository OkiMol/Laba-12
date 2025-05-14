namespace Lab12;

public class ListNode<T>
{
    public T? Data { get; set; }
    
    public ListNode<T>? Next { get; set; }
    
    public ListNode<T>? Previous { get; set; }

    public ListNode()
    {
        Data = default(T);
        Next = null;
        Previous = null;
    }

    public ListNode(T value)
    {
        Data = value;
        Next = null;
        Previous = null;
    }

    public override string ToString()
    {
        return Data?.ToString() ?? "null";
    }
    
}