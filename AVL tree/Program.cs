#nullable enable
using System;

public class AvlNode
{
    public int Value;
    public AvlNode? Left;
    public AvlNode? Right;
    public int Height;

    public AvlNode(int value)
    {
        Value = value;
        Height = 1;
    }
}
public class Program
{
    static int GetHeight(AvlNode? node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Height;
    }
    static int GetBalance(AvlNode? node)
    {
        if (node == null)
        {
            return 0;
        }

        return GetHeight(node.Left) - GetHeight(node.Right);
    }
    static void UpdateHeight(AvlNode? node)
    {
        if (node == null)
        {
            return;
        }

        node.Height = 1 + Math.Max(
            GetHeight(node.Left),
            GetHeight(node.Right)
        );
    }

    static AvlNode RotateRight(AvlNode node)
    {
        AvlNode newTop = node.Left!;
        AvlNode? middleSubtree = newTop.Right;

        newTop.Right = node;
        node.Left = middleSubtree;

        UpdateHeight(node);
        UpdateHeight(newTop);
        return newTop;
    }
    static AvlNode RotateLeft(AvlNode node)
    {
        AvlNode newTop = node.Right!;
        AvlNode? middleSubtree = newTop.Left;

        newTop.Left = node;
        node.Right = middleSubtree;

        UpdateHeight(node);
        UpdateHeight(newTop);

        return newTop;
    }

    static void PrintInOrder(AvlNode? node)
    {
        if (node == null)
        {
            return;

            PrintInOrder(node.Left);
            Console.Write(node.Value + " ");
            PrintInOrder(node.Right);
        }

        static int CheckRealHeight(AvlNode? node)
        {
            if (node == null)
            {
                return 0;
            }
            int leftHeight = CheckRealHeight(node.Left);
            if (leftHeight == -1)
            {
                return -1;
            }
            int rightHeight = CheckRealHeight(node.Right);

            if (rightHeight == -1)
            {
                return -1;
            }
            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return -1;
            }
            return 1 + Math.Max(leftHeight, rightHeight);
        }
        static bool IsBalanced(AvlNode? root)
        {
            return CheckRealHeight(root) != -1;
        }

        static void Main()
        {
            static void Main()
            {
                
                AvlNode root = new AvlNode(44);
                root.Left = new AvlNode(37);
                root.Right = new AvlNode(68);
                root.Left.Left = new AvlNode(29);
                root.Left.Right = new AvlNode(41);
                root.Right.Left = new AvlNode(52);
                root.Right.Right = new AvlNode(78);
                root.Right.Left.Right = new AvlNode(61);
                root.Right.Right.Left = new AvlNode(75);
                root.Right.Right.Right = new AvlNode(80);
                
                UpdateHeight(root.Left);
                UpdateHeight(root.Right.Left);
                UpdateHeight(root.Right.Right);
                UpdateHeight(root.Right);
                UpdateHeight(root);

                
                Console.Write("Inorder: ");
                PrintInOrder(root);
                Console.WriteLine();

                Console.WriteLine($"root value:{root.Value}");
                Console.WriteLine($"tree height:{GetHeight(root)}");
                Console.WriteLine($"Is balanced:{IsBalanced(root)}");
         
                AvlNode secondRoot = new AvlNode(8);
                secondRoot.Left = new AvlNode(4);
                secondRoot.Right = new AvlNode(12);
                secondRoot.Left.Left = new AvlNode(2);
                secondRoot.Left.Right = new AvlNode(6);
                secondRoot.Right.Left = new AvlNode(10);
                secondRoot.Right.Right = new AvlNode(14);
                secondRoot.Left.Left.Left = new AvlNode(1);
                secondRoot.Left.Left.Right = new AvlNode(3);
                secondRoot.Left.Right.Left = new AvlNode(5);
                secondRoot.Left.Right.Right = new AvlNode(7);
                secondRoot.Right.Left.Left = new AvlNode(9);
                secondRoot.Right.Left.Right = new AvlNode(11);
                secondRoot.Right.Right.Left = new AvlNode(13);
                secondRoot.Right.Right.Right = new AvlNode(15);

                UpdateHeight(secondRoot.Left.Left);
                UpdateHeight(secondRoot.Left.Right);
                UpdateHeight(secondRoot.Right.Left);
                UpdateHeight(secondRoot.Right.Right);
                UpdateHeight(secondRoot.Left);
                UpdateHeight(secondRoot.Right);
                UpdateHeight(secondRoot);

                Console.WriteLine($"Height after creating 1 to 15: {GetHeight(secondRoot)}");
            }
        }
    }
}
