namespace VisualizadorEstructuras.Models;

public class Tree<T>
{
    public TreeNode<T>? Root { get; private set; }

    public Tree(T data)
    {
        Root = new TreeNode<T>(data);
    }

    public Tree()
    {
        Root = null;
    }

    // Agregar nodo hijo al nodo raíz
    public void AddChild(T data)
    {
        if (Root == null)
        {
            Root = new TreeNode<T>(data);
        }
        else
        {
            Root.AddChild(new TreeNode<T>(data));
        }
    }

    // Agregar nodo hijo a un nodo específico
    public void AddChildToNode(TreeNode<T> parent, T data)
    {
        parent.AddChild(new TreeNode<T>(data));
    }

    // Buscar nodo por valor
    public TreeNode<T>? FindNode(Func<T, bool> predicate)
    {
        if (Root == null) return null;
        return FindNodeRecursive(Root, predicate);
    }

    private TreeNode<T>? FindNodeRecursive(TreeNode<T> node, Func<T, bool> predicate)
    {
        if (predicate(node.Data))
            return node;

        foreach (var child in node.Children)
        {
            var result = FindNodeRecursive(child, predicate);
            if (result != null)
                return result;
        }

        return null;
    }

    // Recorrido en profundidad (DFS)
    public List<T> DepthFirstTraversal()
    {
        var result = new List<T>();
        if (Root != null)
        {
            DepthFirstTraversalRecursive(Root, result);
        }
        return result;
    }

    private void DepthFirstTraversalRecursive(TreeNode<T> node, List<T> result)
    {
        result.Add(node.Data);
        foreach (var child in node.Children)
        {
            DepthFirstTraversalRecursive(child, result);
        }
    }

    // Recorrido en anchura (BFS)
    public List<T> BreadthFirstTraversal()
    {
        var result = new List<T>();
        if (Root == null) return result;

        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Add(current.Data);

            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }

    // Obtener nodos hoja (sin hijos)
    public List<TreeNode<T>> GetLeafNodes()
    {
        var leafNodes = new List<TreeNode<T>>();
        if (Root != null)
        {
            GetLeafNodesRecursive(Root, leafNodes);
        }
        return leafNodes;
    }

    private void GetLeafNodesRecursive(TreeNode<T> node, List<TreeNode<T>> leafNodes)
    {
        if (node.Children.Count == 0)
        {
            leafNodes.Add(node);
        }
        else
        {
            foreach (var child in node.Children)
            {
                GetLeafNodesRecursive(child, leafNodes);
            }
        }
    }

    // Calcular altura del árbol
    public int GetHeight()
    {
        if (Root == null) return 0;
        return GetHeightRecursive(Root);
    }

    private int GetHeightRecursive(TreeNode<T> node)
    {
        if (node.Children.Count == 0) return 1;

        int maxHeight = 0;
        foreach (var child in node.Children)
        {
            int childHeight = GetHeightRecursive(child);
            if (childHeight > maxHeight)
                maxHeight = childHeight;
        }

        return maxHeight + 1;
    }

    // Contar total de nodos
    public int GetNodeCount()
    {
        if (Root == null) return 0;
        return GetNodeCountRecursive(Root);
    }

    private int GetNodeCountRecursive(TreeNode<T> node)
    {
        int count = 1; // Contar el nodo actual
        foreach (var child in node.Children)
        {
            count += GetNodeCountRecursive(child);
        }
        return count;
    }

    // Obtener todos los nodos
    public List<TreeNode<T>> GetAllNodes()
    {
        var nodes = new List<TreeNode<T>>();
        if (Root != null)
        {
            GetAllNodesRecursive(Root, nodes);
        }
        return nodes;
    }

    private void GetAllNodesRecursive(TreeNode<T> node, List<TreeNode<T>> nodes)
    {
        nodes.Add(node);
        foreach (var child in node.Children)
        {
            GetAllNodesRecursive(child, nodes);
        }
    }
} 