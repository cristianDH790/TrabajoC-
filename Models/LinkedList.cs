namespace VisualizadorEstructuras.Models;

public class LinkedList<T>
{
    private LinkedListNode<T>? _head;
    private int _count;

    public int Count => _count;
    public bool IsEmpty => _head == null;

    // Agregar al final (FIFO para catálogo)
    public void AddLast(T data)
    {
        var newNode = new LinkedListNode<T>(data);
        
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        _count++;
    }

    // Buscar por criterio
    public T? Find(Func<T, bool> predicate)
    {
        var current = _head;
        while (current != null)
        {
            if (predicate(current.Data))
                return current.Data;
            current = current.Next;
        }
        return default;
    }

    // Obtener todos los elementos
    public List<T> ToList()
    {
        var result = new List<T>();
        var current = _head;
        while (current != null)
        {
            result.Add(current.Data);
            current = current.Next;
        }
        return result;
    }

    // Eliminar por criterio
    public bool Remove(Func<T, bool> predicate)
    {
        if (_head == null) return false;

        if (predicate(_head.Data))
        {
            _head = _head.Next;
            _count--;
            return true;
        }

        var current = _head;
        while (current.Next != null)
        {
            if (predicate(current.Next.Data))
            {
                current.Next = current.Next.Next;
                _count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }
} 