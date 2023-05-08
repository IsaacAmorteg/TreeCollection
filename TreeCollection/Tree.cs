using System;
using System.Collections;
using System.Collections.Generic;

namespace TreeCollection
{
    public class Tree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Left { get; set; }
            public Node? Right { get; set; }

            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private Node? _root;
        private bool _isReversed;

        public Tree(bool isReversed = false)
        {
            _root = null;
            _isReversed = isReversed;
        }

        public void Add(T newElement)
        {
            if (_root == null)
            {
                _root = new Node(newElement);
            }
            else
            {
                var current = _root;
                var parent = _root;

                while (current != null)
                {
                    parent = current;

                    if (newElement.CompareTo(current.Value) < 0)
                    {
                        current = current.Left;
                    }
                    else if (newElement.CompareTo(current.Value) > 0)
                    {
                        current = current.Right;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                if (newElement.CompareTo(parent.Value) < 0)
                {
                    parent.Left = new Node(newElement);
                }
                else if (newElement.CompareTo(parent.Value) > 0)
                {
                    parent.Right = new Node(newElement);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_isReversed)
            {
                foreach (var item in TraversePostOrder(_root))
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var item in TraverseInOrder(_root))
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> TraverseInOrder(Node node)
        {
            if (node != null)
            {
                foreach (var item in TraverseInOrder(node.Left))
                {
                    yield return item;
                }

                yield return node.Value;

                foreach (var item in TraverseInOrder(node.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> TraversePostOrder(Node node)
        {
            if (node != null)
            {
                foreach (var item in TraversePostOrder(node.Right))
                {
                    yield return item;
                }

                yield return node.Value;

                foreach (var item in TraversePostOrder(node.Left))
                {
                    yield return item;
                }
            }
        }
    }
}
