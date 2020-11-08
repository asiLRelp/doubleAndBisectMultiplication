using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace doubleAndBisectMultiplication
{
    public class Program
    {
        public static int Main()
        {
            Console.Write("Bitte geben Sie zwei ganze Zahlen ein, die multipliziert werden sollen und bestaetigen Sie jeweils mit Enter.\n");
            while (true)
            {
                Console.Write("Zahl 1: ");
                int? a = ReadNumber();
                if (a == null)
                    return 0;
                Console.Write("Zahl 2: ");
                int? b = ReadNumber();
                if (b == null)
                    return 0;
                Console.WriteLine("\nDanke!\n\nDas Ergebnis der Multiplikation von {0} und {1} ist {2}\n", a, b, Mul((int)a, (int)b));
                Console.WriteLine("\n Zum Beenden des Programms geben Sie bitte \"exit\" ein oder druecken Sie Strg+C.\n" +
                    "Um das Programm von vorne zu starten drücken Sie bitte Enter:\n");
                if (Console.ReadLine() == "exit")
                    return 0;
            }
        }

        private static int? ReadNumber()
        {
            int a, i = 0;
            bool number = true;
            while (true)
            {
                string input = Console.ReadLine();
                Int32.TryParse(input, out a);
                if (a == Int32.MinValue)
                {
                    Console.WriteLine("Diese Zahl ist leider betragsmaessig zu gross, mein Horizont geht nur von {0} bis {1}.\n" +
                        "Probieren Sie es doch nochmal mit einer betragsmaessig kleineren Zahl.", Int32.MinValue + 1, Int32.MaxValue);
                    Console.Write("Bitte geben Sie eine ganze Zahl ein: ");
                }

                else if (!Int32.TryParse(input, out a))
                {
                    i++;
                    if (i == 5)
                        return null;

                    char[] chars = input.ToCharArray();


                    number = chars.Skip(1).All(c => char.IsNumber(c));
                    
                    if (chars.Length == 0)
                        Console.WriteLine("Das war keine ganze Zahl.");

                    else if (!number || (number && !char.IsNumber(chars[0])&& chars[0] != '-'))
                    {
                        Console.WriteLine("Das war keine ganze Zahl.");
                    }
                    else if (number)
                    {
                        Console.WriteLine("Diese Zahl ist leider betragsmaessig zu gross, mein Horizont geht nur von {0} bis {1}.\n" +
                            "Probieren Sie es doch nochmal mit einer betragsmaessig kleineren Zahl.", Int32.MinValue+1, Int32.MaxValue);
                    }
                    if (i == 4)
                    {
                        Console.WriteLine("Letzter Versuch, wenn Sie dieses Mal keine ganze Zahl innerhalb meines Horizonts eintippen wird das Programm beendet...");
                    }
                    Console.Write("Bitte geben Sie eine ganze Zahl ein: ");
                }
                else return a;
            }
        }

        public static int Mul(int x, int y)
        {
            int a = Math.Abs(x), b = Math.Abs(y);
            int result = 0;
            int twos = 2, i = 1;
            while(a >= twos)
            {
                twos *= 2;
                if (twos < 0)
                    break;
                i++;
            }
            int[] arrayA = new int[i], arrayB = new int[i];
            for (int j = 0; j < i; j++){
                arrayA[j] = a % 2;
                a /= 2;
                arrayB[j] = b;
                b *= 2;
                if (b < 0)
                {
                    Console.WriteLine("\nSorry, das Ergebnis ist zu gross, mein Horizont hoert bei {0} bzw. {1} auf..." +
                        "Versuchen Sie es bitte nochmal mit kleineren Zahlen :-)\n", Int32.MinValue+1, Int32.MaxValue);
                    return Main();
                }
            }

            //Console.WriteLine("\na:         b:\n");
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine("{0}          {1}", arrayA[j], arrayB[j]);
                result += arrayA[j] * arrayB[j];
            }
            //Console.WriteLine("\nFun fact: Die binaere Darstellung von {0} ist {1}.\n", Math.Abs(x), Convert.ToString(Math.Abs(x), 2));

            if ((x < 0) ^ (y < 0))
                return -result;
            else
                return result;
        }
    }
}
