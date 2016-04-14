using System;

namespace MathProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // define our binary tree from the bottom up
            Point leaf1 = new Point(9, null, null);
            Point leaf2 = new Point(7, null, null);
            Point leaf3 = new Point(8, null, null);
            Point leaf4 = new Point(1, null, null);
            Point leftNode = new Point(4, leaf1, leaf2);
            Point rightNode = new Point(3, leaf3, leaf4);
            Point root = new Point(5, leftNode, rightNode);

            Console.WriteLine(sumNodes(root));
            Console.ReadLine();

        }


        public class Point
        {
            public int Value { get; set; }
            public Point LeftNode { get; set; }
            public Point RightNode { get; set; }

            public Point(int value, Point leftNode, Point rightNode) 
            {
                Value = value;
                LeftNode = leftNode;
                RightNode = rightNode;
            }
        }

        public static int sumNodes(Point root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.LeftNode == null && root.RightNode == null) // no child nodes, return value
            {
                return root.Value;
            }

            return root.Value + Math.Max(sumNodes(root.LeftNode), sumNodes(root.RightNode)); // otherwise, look one level down
        
        }


    }

}
