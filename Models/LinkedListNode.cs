namespace VisualizadorEstructuras.Models;

public class LinkedListNode<T>
{
    public T Data { get; set; }
    public LinkedListNode<T>? Next { get; set; }

    public LinkedListNode(T data)
    {
        Data = data;
        Next = null;
    }
} 