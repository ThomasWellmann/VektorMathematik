using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace VektorMathematik
{
    internal class Lobby : Screen
    {
        Random rnd = new Random(DateTime.Now.Millisecond);
        Vector v1;
        Vector v2;
        public override Screen Start()
        {
            ResizeWindow();
            Console.WriteLine($"Welcome to the Vector-Calculator!");
            Console.WriteLine();

            GetVectors();

            DoMath();

            Console.ReadKey();
            return this;
        }

        private void GetVectors()
        {
            Console.WriteLine($"If you want to start with random Vectors, press \"1\".");
            Console.WriteLine($"Or if you want to choose your Vectors's values, press \"2\".");
            float[] v1Values = new float[3];
            float[] v2Values = new float[3];
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    v1Values = [NextFloat(rnd), NextFloat(rnd), NextFloat(rnd)];
                    v2Values = [NextFloat(rnd), NextFloat(rnd), NextFloat(rnd)];
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    string[] v1Input = new string[3];
                    string[] v2Input = new string[3];
                    Console.WriteLine($"Type a X-Value for your Vector 1: ");
                    v1Input[0] = Console.ReadLine();
                    if (float.TryParse(v1Input[0], out v1Values[0])) ;
                    Console.WriteLine($"Type a Y-Value for your Vector 1: ");
                    v1Input[1] = Console.ReadLine();
                    if (float.TryParse(v1Input[1], out v1Values[1])) ;
                    Console.WriteLine($"Type a Z-Value for your Vector 1: ");
                    v1Input[2] = Console.ReadLine();
                    if (float.TryParse(v1Input[2], out v1Values[2])) ;

                    Console.WriteLine($"Type a X-Value for your Vector 2: ");
                    v2Input[0] = Console.ReadLine();
                    if (float.TryParse(v1Input[0], out v2Values[0])) ;
                    Console.WriteLine($"Type a Y-Value for your Vector 2: ");
                    v2Input[1] = Console.ReadLine();
                    if (float.TryParse(v1Input[1], out v2Values[1])) ;
                    Console.WriteLine($"Type a Z-Value for your Vector 2: ");
                    v2Input[2] = Console.ReadLine();
                    if (float.TryParse(v1Input[2], out v2Values[2])) ;
                    break;
                }
            }
            Vector v1 = new Vector(v1Values[0], v1Values[1], v1Values[2]);
            Vector v2 = new Vector(v2Values[0], v2Values[1], v2Values[2]);

            Console.WriteLine($"Your Vectors are:");
            Console.WriteLine($"Vector 1: {v1}");
            Console.WriteLine($"Vector 2: {v2}");
            Console.WriteLine();
        }

        private void DoMath()
        {
            Console.WriteLine($"The sum of your Vectors is:");
            Console.WriteLine($"{v1.Add()}");
            Console.WriteLine();
            Console.WriteLine($"The difference of your Vectors is:");
            Console.WriteLine($"{v1.Subtract()}");
            Console.WriteLine();

        }

        static float NextFloat(Random random) //StackOverflow
        {
            var buffer = new byte[4];
            random.NextBytes(buffer);
            return BitConverter.ToSingle(buffer, 0);
        }
    }
}
