using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    public class FA1
    {
        public static State one = new State()
        {
            Name = "первое",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State two = new State()
        {
            Name = "второе",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State thre = new State()
        {
            Name = "третье",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State four = new State()
        {
            Name = "четвертое",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public static State finish = new State()
        {
            Name = "конечное",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = one;

        public FA1()
        {

            one.Transitions['0'] = two;
            one.Transitions['1'] = thre;

            two.Transitions['0'] = four;
            two.Transitions['1'] = finish;

            thre.Transitions['0'] = finish;
            thre.Transitions['1'] = thre;

            four.Transitions['0'] = four;
            four.Transitions['1'] = four;

            finish.Transitions['0'] = four;
            finish.Transitions['1'] = finish;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public static State evenZerosEvenOnes = new State()
        {
            Name = "evenZerosEvenOnes",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State oddZerosEvenOnes = new State()
        {
            Name = "oddZerosEvenOnes",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State evenZerosOddOnes = new State()
        {
            Name = "evenZerosOddOnes",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State oddZerosOddOnes = new State()
        {
            Name = "oddZerosOddOnes",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = evenZerosEvenOnes;

        public FA2()
        {
            evenZerosEvenOnes.Transitions['0'] = oddZerosEvenOnes;
            evenZerosEvenOnes.Transitions['1'] = evenZerosOddOnes;

            oddZerosEvenOnes.Transitions['0'] = evenZerosEvenOnes;
            oddZerosEvenOnes.Transitions['1'] = oddZerosOddOnes;

            evenZerosOddOnes.Transitions['0'] = oddZerosOddOnes;
            evenZerosOddOnes.Transitions['1'] = evenZerosEvenOnes;

            oddZerosOddOnes.Transitions['0'] = evenZerosOddOnes;
            oddZerosOddOnes.Transitions['1'] = oddZerosEvenOnes;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public static State start = new State()
        {
            Name = "start",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State seenOne = new State()
        {
            Name = "seenOne",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State seenTwoOnes = new State()
        {
            Name = "seenTwoOnes",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = start;

        public FA3()
        {
            start.Transitions['0'] = start;
            start.Transitions['1'] = seenOne;

            seenOne.Transitions['0'] = start;
            seenOne.Transitions['1'] = seenTwoOnes;

            seenTwoOnes.Transitions['0'] = seenTwoOnes;
            seenTwoOnes.Transitions['1'] = seenTwoOnes;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s1 = "0111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s1);
            Console.WriteLine(result1);

            String s2 = "0001";
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s2);
            Console.WriteLine(result2);

            String s3 = "1101";
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s3);
            Console.WriteLine(result3);
        }
    }
}
