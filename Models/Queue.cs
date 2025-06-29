namespace VisualizadorEstructuras.Models;

public class Queue<T>
{
    private LinkedListNode<T>? _front;
    private LinkedListNode<T>? _rear;
    private int _count;

    public int Count => _count;
    public bool IsEmpty => _front == null;

    // Enqueue - Agregar elemento al final
    public void Enqueue(T data)
    {
        var newNode = new LinkedListNode<T>(data);
        
        if (_rear == null)
        {
            _front = _rear = newNode;
        }
        else
        {
            _rear.Next = newNode;
            _rear = newNode;
        }
        _count++;
    }

    // Dequeue - Remover y retornar el primer elemento
    public T Dequeue()
    {
        if (_front == null)
            return default!;

        var data = _front.Data;
        _front = _front.Next;
        
        if (_front == null)
            _rear = null;
            
        _count--;
        return data;
    }

    // Peek - Ver el primer elemento sin removerlo
    public T Peek()
    {
        return _front != null ? _front.Data : default!;
    }

    // Obtener todos los elementos
    public List<T> ToList()
    {
        var result = new List<T>();
        var current = _front;
        while (current != null)
        {
            result.Add(current.Data);
            current = current.Next;
        }
        return result;
    }
} 