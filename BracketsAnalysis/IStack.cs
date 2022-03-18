using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsAnalysis
{
    public interface IStack
    {
        void Push(string ring);
        string Pop();
        bool IsFull();
        bool IsEmpty();
        int Size();
    }
}
