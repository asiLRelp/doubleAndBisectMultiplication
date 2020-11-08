using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace doubleAndBisectMultiplication
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Bitte geben Sie zwei ganze Zahlen ein, die multipliziert werden sollen und bestaetigen Sie jeweils mit Enter.\n");
            while (true)
            {
                Console.Write("Zahl 1: ");
                int? a = ReadNumber();
                if (a == null)
                    return;
                Console.Write("Zahl 2: ");
                int? b = ReadNumber();
                if (b == null)
                    return;
                Console.WriteLine("\nDanke!\n\nDas Ergebnis der Multiplikation von {0} und {1} ist {2}\n", a, b, Mul((int)a, (int)b));
                Console.WriteLine("\n Zum Beenden des Programms geben Sie bitte \"exit\" ein oder druecken Sie Strg+C.\n" +
                    "Um das Programm von vorne zu starten drücken Sie bitte Enter:\n");
                if (Console.ReadLine() == "exit")
                    return;
            }
        }

        private static int? ReadNumber()
        {
            // Exit Programm if maxInvalidInput invalid numbers were entered.
            int maxInputTrials = 5;
            for (int count = 0; count <= maxInputTrials; count++)
            {
                Console.Write("\nBitte geben Sie eine ganze Zahl ein: ");
                string input = Console.ReadLine();
                bool parsingWorked = Int32.TryParse(input, out int number);
                if (!parsingWorked)
                {
                    char[] chars = input.ToCharArray();
                    bool isNumber = chars.Length > 0 && chars.Skip(1).All(c => char.IsNumber(c)) && (char.IsNumber(chars[0]) || chars[0] == '-');
                    if (!isNumber)
                        Console.WriteLine("Das war keine ganze Zahl.");
                    else if (isNumber)
                    {
                        Console.WriteLine("Diese Zahl ist leider betragsmaessig zu gross, mein Horizont geht nur von {0} bis {1}. " +
                            "Probieren Sie es doch nochmal mit einer betragsmaessig kleineren Zahl.", Int32.MinValue+1, Int32.MaxValue);
                    }
                }
                else if (number == Int32.MinValue)
                {
                    Console.WriteLine("Diese Zahl ist leider betragsmaessig zu gross, mein Horizont geht nur von {0} bis {1}. " +
                        "Probieren Sie es doch nochmal mit einer betragsmaessig kleineren Zahl.", Int32.MinValue + 1, Int32.MaxValue);
                }
                else return number;
                if (count == maxInputTrials - 1)
                    Console.WriteLine("Letzter Versuch, wenn Sie dieses Mal keine ganze Zahl innerhalb meines Horizonts eintippen wird das Programm beendet...");
            }
            return null;
        }

        public static int Mul(int x, int y)
        {
            int absX = Math.Abs(x), absY = Math.Abs(y);
            int result = 0;
            int twos = 2, requiredArrayLength = 1;
            while(absX >= twos && twos > 0)
            {
                twos *= 2;
                requiredArrayLength++;
            }
            Console.WriteLine("{0}", requiredArrayLength);
            //Console.WriteLine("\na:         b:\n");
            int[] arrayX = new int[requiredArrayLength], arrayY = new int[requiredArrayLength];
            arrayX[0] = absX % 2;
            arrayY[0] = absY;
            for (int i = 1; i < requiredArrayLength; i++){
                absY *= 2;
                if (absY < 0)
                {
                    Console.WriteLine("\nSorry, das Ergebnis ist zu gross, mein Horizont hoert bei {0} bzw. {1} auf... " +
                        "Versuchen Sie es bitte nochmal mit kleineren Zahlen :-)\n", Int32.MinValue + 1, Int32.MaxValue);
                    Main();
                    return 0;
                }
                arrayY[i] = absY;
                
                absX /= 2;
                arrayX[i] = absX % 2;
                Console.WriteLine("{0}          {1}", arrayX[i], arrayY[i]);
            }
            for (int j = 0; j < requiredArrayLength; j++)
                result += arrayX[j] * arrayY[j];
            //Console.WriteLine("\nDie binaere Darstellung von {0} ist {1}.\n", Math.Abs(x), Convert.ToString(Math.Abs(x), 2));
            if ((x < 0) ^ (y < 0))
                return -result;
            else
                return result;
        }
    }
}
