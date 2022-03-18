using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsAnalysis
{
    public class Stack:IStack
    {
        public EventHandler<string> StackState;
        private const int _MaxSize = 50;
        public string[] ArrayOfCars;
        private int _num;

        public Stack()
        {
            ArrayOfCars = new string[_MaxSize];
            _num = 0;
        }

        public void Push(string car)
        {
            if (!IsFull())
            {
                ArrayOfCars[_num] = car;
                _num += 1;
            }
            else
            {
                StackState(this, "Parking is Full");
            }
        }

        public string Pop()
        {
            if (IsEmpty())
            {
                StackState(this, "Stack Is Empty......");
                return null;
            }
            _num -= 1;
            string temp = ArrayOfCars[_num];
            ArrayOfCars[_num] = null;
            return temp;
        }
        //public string Display()
        //{
        //    string result="";
        //    foreach (var car in ArrayOfCars)
        //        result += car + "\n";
        //    return result;
        //}

        public bool Find(string Car)
        {
            for (int i = 0; i < _num; i++)
                if (ArrayOfCars[i] == Car)
                    return true;
            return false;
        }
        public int GetCar(string Car)
        {
            int i = 0;
            for (i = 0; i < _num; i++)
                if (ArrayOfCars[i] == Car)
                    break;
            return i;
        }
        public bool IsFull()
        {
            return _num >= _MaxSize;
        }

        public bool IsEmpty()
        {
            return _num <= 0;
        }
        public int Size()
        {
            return _num;
        }
    }
}
