using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly State initialState;

        public FA1()
        {
            var one = new State { Name = "первое", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var two = new State { Name = "второе", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var three = new State { Name = "третье", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
            var four = new State { Name = "четвертое", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
            var finish = new State { Name = "конечное", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

            one.Transitions['0'] = two;
            one.Transitions['1'] = three;

            two.Transitions['0'] = four;
            two.Transitions['1'] = finish;

            three.Transitions['0'] = finish;
            three.Transitions['1'] = three;

            four.Transitions['0'] = four;
            four.Transitions['1'] = four;

            finish.Transitions['0'] = four;
            finish.Transitions['1'] = finish;

            initialState = one;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = initialState;
            foreach (var c in s)
            {
                if (current.Transitions.ContainsKey(c))
                {
                    current = current.Transitions[c];
                }
                else
                {
                    return false;
                }
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        private readonly State initialState;

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
        public static State finish = new State()
        {
            Name = "конечное",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public FA2()
        {
            one.Transitions['0'] = two;
            one.Transitions['1'] = thre;

            two.Transitions['0'] = one;
            two.Transitions['1'] = finish;

            thre.Transitions['0'] = finish;
            thre.Transitions['1'] = one;

            finish.Transitions['0'] = thre;
            finish.Transitions['1'] = two;

            initialState = one;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = initialState;
            foreach (var c in s)
            {
                if (current.Transitions.ContainsKey(c))
                {
                    current = current.Transitions[c];
                }
                else
                {
                    return false;
                }
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        private readonly State initialState;

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
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        public static State finish = new State()
        {
            Name = "финишное",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        public FA3()
        {
            one.Transitions['0'] = two;
            one.Transitions['1'] = thre;

            two.Transitions['0'] = one;
            two.Transitions['1'] = thre;

            thre.Transitions['0'] = one;
            thre.Transitions['1'] = finish;

            finish.Transitions['0'] = finish;
            finish.Transitions['1'] = finish;

            initialState = one;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = initialState;
            foreach (var c in s)
            {
                if (current.Transitions.ContainsKey(c))
                {
                    current = current.Transitions[c];
                }
                else
                {
                    return false;
                }
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "1110111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
