namespace VisualizadorEstructuras.Models;

public class Stack<T>
{
    private LinkedListNode<T>? _top;
    private int _count;

    public int Count => _count;
    public bool IsEmpty => _top == null;

    // Push - Agregar elemento al tope
    public void Push(T data)
    {
        var newNode = new LinkedListNode<T>(data)
        {
            Next = _top
        };
        _top = newNode;
        _count++;
    }

    // Pop - Remover y retornar el elemento del tope
    public T Pop()
    {
        if (_top == null)
            return default!;

        var data = _top.Data;
        _top = _top.Next;
        _count--;
        return data;
    }

    // Peek - Ver el elemento del tope sin removerlo
    public T Peek()
    {
        return _top != null ? _top.Data : default!;
    }

    // Obtener todos los elementos (útil para mostrar historial)
    public List<T> ToList()
    {
        var result = new List<T>();
        var current = _top;
        while (current != null)
        {
            result.Add(current.Data);
            current = current.Next;
        }
        return result;
    }
} 