using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsAnalysis
{
    public class Node
    {
        public string data;
        public Node next;

        public Node(string data)
        {
            this.data = data;
            next = null;
        }

    }
    public class StackLinkList:IStack
    {
        public EventHandler<string> StackState;
        private Node Head;
        private int _size;

        public StackLinkList()
        {
            _size = 0;
            Head = null;
        }
        public void Push(string data)
        {
            Node newNode = new Node(data);
            if (IsFull())
            {
                StackState(this, "Stact is Full.......");
            }
            else if (IsEmpty())
            {
                Head = newNode;
            }
            else
            {
                Node temp = Head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }

                temp.next = newNode;
            }
            _size++;
        }
        public string Pop()
        {
            if (IsEmpty())
            {
                StackState(this, "Stack is Empty......");
                return null;
            }
            else
            {
                string str = "";
                if (Head.next == null)
                {
                    str = Head.data;
                    Head = null;
                    return str;
                }
                Node temp = Head;
                Node prev = null;
                while (temp.next != null)
                {
                    prev = temp;
                    temp = temp.next;
                }
                str = temp.data;
                prev.next = null;
                _size--;
                return str;
            }
        }
        public bool IsEmpty()
        {
            return Head == null;
        }
        public bool IsFull()
        {
            return _size >= 50;
        }
        public int Size()
        {
            return _size;
        }
    }
}
