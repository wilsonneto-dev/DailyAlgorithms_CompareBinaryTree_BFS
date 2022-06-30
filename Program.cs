
Node tree1 = new(1, new(2), new(3));
Node tree2 = new(1, new(2), new(3));
Node tree3 = new(1, new(2, new(4), new(5)), new(3));
Node tree4 = new(1, new(2, new(4), new(5)), new(3));

Console.WriteLine("Comparing Binary Trees");

Console.WriteLine($"Test 1 = equals = {(Solution.IsEquals(tree1, tree2) ? "OK" : "X")}");
Console.WriteLine($"Test 2 = not equals = {(!Solution.IsEquals(tree2, tree3) ? "OK" : "X")}");
Console.WriteLine($"Test 2 = equals = {(Solution.IsEquals(tree3, tree4) ? "OK" : "X")}");
Console.WriteLine($"Test 2 = not equals = {(!Solution.IsEquals(tree4, tree1) ? "OK" : "X")}");


class Node
{
    internal Node(int value, Node? left = null, Node? right = null)
    {
        Value = value;
        Left = left;
        Right = Right;
    }

    public int Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
}

static class Solution
{
    internal static bool IsEquals(Node rootNode1, Node rootNode2)
    {
        Queue<(Node?, Node?)> queue = new Queue<(Node?, Node?)>();
        queue.Enqueue((rootNode1, rootNode2));

        while (queue.Count > 1)
        {
            var (node1, node2) = queue.Dequeue();

            if (node1 is null || node2 is null)
                if (node1 != node2)
                    return false;
                else
                    continue;

            if (node1.Value != node2.Value)
                return false;

            queue.Enqueue((node1.Right, node2.Right));
            queue.Enqueue((node1.Left, node2.Left));
        }
        return true;
    }
}