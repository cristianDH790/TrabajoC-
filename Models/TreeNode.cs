namespace VisualizadorEstructuras.Models;

public class TreeNode<T>
{
    public T Data { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(T data)
    {
        Data = data;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> child)
    {
        Children.Add(child);
    }

    public bool IsLeaf => Children.Count == 0;
} 