using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Jhenna-Rae Foronda-Caldetera, 11423409 
 * CPTS 321, SPRING 2017, January 20
 * HW1 - Bst Console */ 


namespace ConsoleBST
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.value = value;
        }

        // helper function for BST insert function
        public void InsertHelper(Node root, int newData)
        {
            // create temp Node of root
            // so we do not alter original root
            Node temp;
            temp = root;

            // create new Node for every newData that passes through
            Node newNode;
            newNode = new Node(newData);

            // if newData is less than root's value
            // we go left of tree
            if (newNode.value < temp.value)
            {
                // check if left node is empty
                // if so, add newNode
                if (temp.left == null)
                {  temp.left = newNode; }

                // else set temp root to left node
                // recursively find empty slot 
                else
                {
                    temp = temp.left;
                    InsertHelper(temp, newData);
                }
            }
            // else if newData is greater than root's value
            // we go right of tree 
            else if (newNode.value > temp.value)
            {
                // check if right node is empty
                // if so, add newNode
                if (temp.right == null)
                { temp.right = newNode; }

                // else set temp root to right node
                // recursively find empty slot 
                else
                {
                    temp = temp.right;
                    InsertHelper(temp, newData);
                }
            }        
        }

        // helper function for BST inOrder
        public void InOrderHelper(Node root)
        {
            // will keep looping until it reaches an empty root
            if (root != null)
            {
                // recursively calls InOrderHelper function
                // all the way through the left side of the tree 
                // until null, meaning the end 
                InOrderHelper(root.left);
                Console.Write(root.value + " ");
                // same as the first function call except 
                // it traverses through the right side of the tree
                InOrderHelper(root.right);
            }
        }
    }

    class BST
    {
        public Node root;
        public int count;
        public int levels = 1;
        public int depth;

        // BST tree constructor
        // initialize root to null
        public BST()
        {
            root = null;
        }

      
        public void Insert(int data)
        {
            // if root is empty, 
            // create new node with data
            if (root == null)
            { root = new Node(data); }

            // else call helper function 
            // passing through root and data
            else
            { root.InsertHelper(root, data); }
            
        
        }


        public int CountNodes(Node node)
        {
            // either root is empty or we reaches empty node
            if (node == null)
            { return 0;  }

            // leaf node is encountered
            if (node.left == null && node.right == null)
            { return 1; }

            else
            {  return 1 + CountNodes(node.left) + CountNodes(node.right); }
        }

        public int CountLevels(Node node)
        {
            // root is empty or reached empty node
            if (node == null)
            {
                return 0;
            }

            // we found leaf node
            else if (node.left == null && node.right == null)
            {
                return 1;
            }
            // recursively goes down left subtree and right tree
            else
            {
                return CountLevels(node.left) + CountLevels(node.right);
            }
        }

        public int MinDepth(int NumNodes)
        {
            // minimum depth is log2(n + 1)
            // n is the number of nodes
            return Convert.ToInt32(Math.Log(NumNodes + 1, 2));
        }


        // InOrder traversal through tree 
        public void InOrder()
        {
            // will keep looping through tree 
            // until root equals null
            // calls helper function
            if (root != null)
            {
                root.InOrderHelper(root);
                
            }
        }

        public void DisplayStats()
        {
            count = CountNodes(root);
            levels += CountLevels(root);
            depth = MinDepth(count);

            Console.Write("     Number of nodes: " + count);
            Console.Write("\n     Number of levels: " + levels);
            Console.Write("\n     Minimum number of levels that a tree with " + count + " nodes could have = " + depth);
            
        }
    }

    
        class Program
        {
            static void Main(string[] args)
            {
                // ask for user input
                Console.WriteLine("Enter collection of numbers between [0-100], searated by spaces: ");
                String Input;
                // get user input
                Input = Console.ReadLine();

                // create new instance of tree
                BST tree = new BST();

                Char space = ' ';
                // split string by space  
                String [] substrings = Input.Split(space);

                // take care of duplicates by creating unique array
                var uniqueArray = substrings.Distinct().ToArray();


                Console.Write("Tree Contents: ");

                // loop through array 
                // insert every element
                foreach (String s in uniqueArray)
                    {
                        // convert string values to int
                        // insert converted values into tree
                        int x = Convert.ToInt32(s);
                        tree.Insert(x);
                    }
                
                    // call InOrder function 
                    tree.InOrder();

                Console.Write("\nTree statistics:\n");
                tree.DisplayStats();

                Console.WriteLine("\nDone");
            }
        }
}
