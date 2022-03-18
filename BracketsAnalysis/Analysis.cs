using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsAnalysis
{
    public class Analysis
    {
        public EventHandler<string> State;
        Stack stack;
        StackLinkList stackLinkList;
        public Analysis(Stack stack = null, StackLinkList stackLinkList = null)
        {
            if (stack == null)
            {
                this.stackLinkList = stackLinkList;
                this.stackLinkList.StackState += stack_StackState;
            }
            else
            {
                this.stack = stack;
                this.stack.StackState += stack_StackState;
            }
        }

        private void stack_StackState(object sender, string e)
        {
            State(this, e);
        }

        public string InFix(string numbers)
        {
            string str = numbers[0].ToString();
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == '|')
                {
                    if (str != "")
                    {
                        if (stack == null)
                            stackLinkList.Push(str);
                        else
                            stack.Push(str);
                        str = "";
                    }
                    continue;
                }
                else if (IsOperatorForInFix(numbers[i - 1], numbers[i]))
                {
                    if (str != "")
                        if (stack == null)
                            stackLinkList.Push(str);
                        else
                            stack.Push(str);
                    string op1, op2;
                    if (stack == null)
                    {
                        op2 = stackLinkList.Pop();
                        op1 = stackLinkList.Pop();
                    }
                    else
                    {
                        op2 = stack.Pop();
                        op1 = stack.Pop();
                    }

                    str = "(" + op1 + numbers[i].ToString() + op2 + ")";
                    if (stack == null)
                        stackLinkList.Push(str);
                    else
                        stack.Push(str);
                    str = "";
                }
                else
                    str += numbers[i];
            }
            if (stack == null)
                return stackLinkList.Pop();
            else
                return stack.Pop();
        }
        public string PostFix(string numbers)
        {
            string result = "";
            string temp;
            result += numbers[0];// bara halati ke ebarat ba -2+1+4 ye adad manfi shoro she 
            for (int i = 1; i < numbers.Length; i++)
            {

                if (IsOperatorForPostFix(numbers[i - 1], numbers[i]))
                {
                    if (stackLinkList == null)
                    {
                        if (stack.IsEmpty())
                        {
                            stack.Push(numbers[i].ToString());
                        }
                        else
                        {
                            temp = stack.Pop();
                            if (OperatorPriority(numbers[i], temp))
                                stack.Push(temp);
                            else
                                while (!OperatorPriority(numbers[i], temp))
                                {
                                    result += temp;/////////
                                    if (stack.IsEmpty())
                                        break;
                                    temp = stack.Pop();
                                    if(OperatorPriority(numbers[i], temp))
                                    {
                                        stack.Push(temp);
                                        break;
                                    }
                                }
                            stack.Push(numbers[i].ToString());
                            //'|' bara joda kardan adad chan raghamikenar ham
                            // 12+4*3 --> 12|4|3*+
                        }
                        result += '|';
                    }
                    else
                    {
                        if (stackLinkList.IsEmpty())
                        {
                            stackLinkList.Push(numbers[i].ToString());
                        }
                        else
                        {
                            temp = stackLinkList.Pop();
                            if (OperatorPriority(numbers[i], temp))
                                stackLinkList.Push(temp);
                            else
                                while (!OperatorPriority(numbers[i], temp))
                                {
                                    result += temp;/////////
                                    if (stackLinkList.IsEmpty())
                                        break;
                                    temp = stackLinkList.Pop();
                                    if (OperatorPriority(numbers[i], temp))
                                    {
                                        stackLinkList.Push(temp);
                                        break;
                                    }
                                }
                            stackLinkList.Push(numbers[i].ToString());
                            //'|' bara joda kardan adad chan raghamikenar ham
                            // 12+4*3 --> 12|4|3*+
                        }
                        result += '|';
                    }

                }
                else
                    result += numbers[i];
            }
            if (stackLinkList == null)
            {
                int stacksize = stack.Size();
                if (stacksize != 0)
                    for (int i = 0; i < stacksize; i++)
                        result += stack.Pop();
            }
            else
            {
                int stacksize = stackLinkList.Size();
                if (stacksize != 0)
                    for (int i = 0; i < stacksize; i++)
                        result += stackLinkList.Pop();
            }
            return result;
        }

        public bool IsOperatorForPostFix(char op1, char op2)// send Two char if str[i-1] is number and no operand then khown str[i] as operand ;
        {
            var x = new char[] { '*', '/', '%', '-', '+' };
            if (x.Contains(op2) && (!x.Contains(op1)))//agar *2 bashe true va agar +- bashe false
                return true;
            return false;

            //var match = str.IndexOfAny("*&#".ToCharArray()) != -1;
            //var match = str.IndexOfAny(new char[] { '*', '&', '#' }) != -1;

            //return str.IndexOfAny("*/+-%".ToCharArray()) >= 0;
            //in return bara vaghti ee ke in halat 2+-3 ro dar nazar nemigire va -3 ro yek adad joda nemishnase 
        }
        public bool IsOperatorForInFix(char op1, char op2)
        {
            var x = new char[] { '*', '/', '%', '-', '+' };
            if (x.Contains(op2) && op1 != '|')
                return true;
            return false;
        }
        public bool OperatorPriority(char op1, string op2)
        {
            int index1, index2;
            string operand = "+-*/%";
            int[] isp = { 0, 0, 1, 1, 1, 1 };
            index1 = operand.IndexOf(op1);
            index2 = operand.IndexOf(op2);
            if (isp[index1] > isp[index2])
                return true;
            return false;
        }
    }
}
