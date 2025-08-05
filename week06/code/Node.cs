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
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else if (Left.Data == value)
                return;
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else if (Right.Data == value)
                return;
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
            return true;
        if (Left is not null && Left.Contains(value))
            return true;
        if (Right is not null && Right.Contains(value))
            return true;
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return Math.Max(leftHeight, rightHeight) + 1; // Replace this line with the correct return statement(s)
    }
}