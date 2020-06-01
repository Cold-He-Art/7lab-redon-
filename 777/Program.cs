using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _777
{
    public class Drob : IComparable<Drob>, IEquatable<Drob>
    {
        private int nNum;
        private int dDen;

        Drob(int Num, int Den)
        {
            nNum = Num;
            dDen = Den;
        }
        public int Num => nNum;
        public int Den => dDen;

        private static int NOD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a * b != 0)
            {
                if (a >= b)
                    a = a % b;
                else
                    b = b % a;
            }
            return a + b;
        }

        private static int NOK(int a, int b)
        {
            int nod = NOD(a, b);
            return (a * b) / nod;
        }

        public int CompareTo(Drob other)
        {
            return this.Num * other.Den - other.Num * this.Den;
        }
        public bool Equals(Drob other)
        {
            return this.CompareTo(other) == 0;
        }
        public string ToDoubleString()
        {
            double k = (double)Num / (double)Den;
            return String.Format("{0}", k);
        }
        public override string ToString()
        {
            int nod = NOD(Num, Den);
            nNum = Num / nod;
            dDen = Den / nod;
            if (Den < 0)
            {
                nNum = -1 * nNum;
                dDen = Math.Abs(dDen);
            }
            return String.Format("{0}/{1}", Num, Den);
        }
        public static Drob operator *(Drob a, Drob b)
        {
            int NewNum = a.Num * b.Num;
            int NewDen = a.Den * b.Den;
            int nod = NOD(NewNum, NewDen);
            NewNum = NewNum / nod;
            NewDen = NewDen / nod;
            return new Drob(NewNum, NewDen);
        }
        public static Drob operator /(Drob a, Drob b)
        {
            int NewNum = a.Num * b.Den;
            int NewDen = a.Den * b.Num;
            int nod = NOD(NewNum, NewDen);
            NewNum = NewNum / nod;
            NewDen = NewDen / nod;
            return new Drob(NewNum, NewDen);
        }
        public static Drob operator +(Drob a, Drob b)
        {
            int NewNum1, NewNum2, NewDen;
            int nok = NOK(a.Den, b.Den);
            int k1 = nok / a.Den;
            int k2 = nok / b.Den;
            NewDen = nok;
            NewNum1 = a.Num * k1;
            NewNum2 = b.Num * k2;
            int NewNumerator = NewNum1 + NewNum2;
            return new Drob(NewNumerator, NewDen);
        }
        public static Drob operator -(Drob a, Drob b)
        {
            int NewNum1, NewNum2, NewDen;
            int nok = NOK(a.Den, b.Den);
            int k1 = nok / a.Den;
            int k2 = nok / b.Den;
            NewDen = nok;
            NewNum1 = a.Num * k1;
            NewNum2 = b.Num * k2;
            int NewNumerator = NewNum1 - NewNum2;
            return new Drob(NewNumerator, NewDen);
        }

        public static bool operator >(Drob a, Drob b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator <(Drob a, Drob b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator ==(Drob a, Drob b)
        {
            return a.CompareTo(b) == 0;
        }
        public static bool operator !=(Drob a, Drob b)
        {
            return a.CompareTo(b) != 0;

        }


        public static explicit operator Drob(double x)
        {
            int X = (int)x;
            double dr = 1;
            int osn = 1;
            dr = x - X;
            while (dr != 0)
            {
                x = x * 10;
                X = (int)x;
                dr = x - X;
                osn = osn * 10;
            }
            return new Drob((int)x, osn);
        }
        public static explicit operator double(Drob x)
        {
            return (double)(x.Num) / (double)(x.Den);
        }
        public static implicit operator int(Drob x)
        {
            return (int)(x.Num / x.Den);
        }


        static void Sort<T>(T[] objects) where T : IComparable<T>
        {
            for (int i = 0; i < objects.Length; i++)
                for (int j = i; j < objects.Length; j++)
                {
                    if (objects[i].CompareTo(objects[j]) > 0)
                    {
                        T time = objects[i];
                        objects[i] = objects[j];
                        objects[j] = time;
                    }
                }
        }
        static void Main(string[] args)
        {
            double EnterDouble;
            Console.WriteLine("\nEnter the number(throw ,):");
            try
            {
                EnterDouble = Convert.ToDouble(Console.ReadLine());
                Drob x = (Drob)EnterDouble;
                Console.WriteLine("x = " + x);
                Console.WriteLine("x = " + x.ToDoubleString());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error format!");
            }
            try
            {
                Console.WriteLine("\nEnter the number(throw / ):");
                string Str = Console.ReadLine();
                int a = 0, b = 1;
                string str = null;
                for (int i = 0; i < Str.Length; i++)
                {
                    if (Str[i] == '/')
                    {
                        a = Convert.ToInt32(str);
                        str = null;
                        continue;
                    }
                    str = str + Str[i];
                }
                b = Convert.ToInt32(str);
                if (b == 0)
                {
                    Console.WriteLine("invalid denominator");
                }
                else
                {
                    Drob x = new Drob(a, b);
                    Console.WriteLine("x = " + x);
                    Console.WriteLine("x = " + x.ToDoubleString());
                    Console.WriteLine(" ");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error format!");
            }

            var x1 = new Drob(20, 14);
            var x2 = new Drob(5, 4);
            Console.WriteLine("x1 = " + x1 + "=" + x1.ToDoubleString());
            Console.WriteLine("x2 = " + x2 + "=" + x2.ToDoubleString());
            Console.WriteLine("x1/x2 = " + x1 / x2);
            Console.WriteLine("x1*x2 = " + x1 * x2);
            Console.WriteLine("x1+x2 = " + (x1 + x2));
            Console.WriteLine("x1-x2 = " + (x1 - x2));
            if (x1 > x2)
                Console.WriteLine("\n" + x1 + " is bigger");
            if (x1 < x2)
                Console.WriteLine(x2 + "is bigger");
            if (x1 == x2)
                Console.WriteLine("x1=x2");
            if (x1 != x2)
                Console.WriteLine("x1!=x2\n");


            double d1 = (double)x1;
            double d2;
            d2 = 10.3;
            x2 = (Drob)d2;
            int i1 = x1;
            Console.WriteLine("{1} = {0}", d1, x1);
            Console.WriteLine("{1} = {0}", i1, x1);
            Console.WriteLine("10.3 = {0}", x2);


            Console.WriteLine("\nSort:");
            Drob[] Arr = new Drob[3];
            Arr[0] = new Drob(10, 3);
            Arr[1] = new Drob(28, 4);
            Arr[2] = new Drob(9, 31);

            Sort<Drob>(Arr);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Arr[i] + " = " + Arr[i].ToDoubleString());
            }
            Console.Read();

        }



    }


}

