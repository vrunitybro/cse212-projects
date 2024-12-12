using System.Security.Cryptography.X509Certificates;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
     {
        if (value == Data) return; // Avoid duplicate values

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if(value == Data) return true;

        if(value<Data)
        {
            //Check left subtree
            return Left != null && Left.Contains(value);

        }

        else
        {
            //Check right subtree
            return Right != null && Right.Contains(value);

        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight()??0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}