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
        private static string[][] mathText = [
            [//a0
                $"Welcome to the Vector-Calculator!"//0
            ],[//a1
                $"If you want to start with random Vectors, press \"1\".",//0
                $"Or if you want to choose your Vectors's values, press \"2\"."//1
            ],[//a2
                $"Type a X-Value for your Vector v0:",//0
                $"Type a Y-Value for your Vector v0:",//1
                $"Type a Z-Value for your Vector v0:",//2
                $"Type a X-Value for your Vector v1:",//3
                $"Type a Y-Value for your Vector v1:",//4
                $"Type a Z-Value for your Vector v1:"//5
            ],[//a3
                $"Your Vectors are:",//0
                $"Vector v0: ",//1
                $"Vector v1: "//2
            ],[
                $"Now that you have your Vectors you can do various math operations with them:",
                $"(1) Addition: Get the sum of your Vectors;",
                $"(2) Subtraction: Get the difference of your Vectors;",
                $"(3) Multiplication: Get the product of one of the Vectors with a Skalar;",
                $"(4) Distance: Get the distance between your Vectors or other of your liking;",
                $"(5) Length: Get the length of one of your Vectors;",
                $"(6) Quadratlänge: ???;"
            ]];
        public override Screen Start()
        {
            ResizeWindow();
            Console.WriteLine(mathText[0][0]);
            Console.WriteLine();

            DoMath(GetVectors());

            Console.ReadKey();
            return this;
        }

        private Vector[] GetVectors()
        {
            Console.WriteLine(mathText[1][0]);
            Console.WriteLine(mathText[1][1]);
            Console.WriteLine();
            float[] v1Values = new float[3];
            float[] v2Values = new float[3];
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    v1Values = [NextFloat(), NextFloat(), NextFloat()];
                    v2Values = [NextFloat(), NextFloat(), NextFloat()];
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    string[] v1Input = new string[3];
                    string[] v2Input = new string[3];
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine(mathText[2][i]);
                        v1Input[i] = Console.ReadLine();
                        if (float.TryParse(v1Input[i], out v1Values[i])) ;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine(mathText[2][i + 3]);
                        v2Input[i] = Console.ReadLine();
                        if (float.TryParse(v2Input[i], out v2Values[i])) ;
                    }
                    GetTextSpacements();
                    break;
                }
            }
            Vector[] vArr = [new Vector(v1Values[0], v1Values[1], v1Values[2]), new Vector(v2Values[0], v2Values[1], v2Values[2])];

            for (int i = 0; i < mathText[3].GetLength(0); i++)
            {
                Console.WriteLine(mathText[3][i] + $"{((i != 0) ? vArr[i - 1] : "")}");
            }
            Console.WriteLine();
            return vArr;
        }

        private void DoMath(Vector[] _v)
        {
            while (true)
            {
                DoMathText();
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    Console.WriteLine($"(1) The sum of your Vectors is:");
                    Console.WriteLine($"{_v[0].Add(_v[1])}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.WriteLine($"(2) The difference of your Vectors is:");
                    Console.WriteLine($"{_v[0].Subtract(_v[1])}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    Console.WriteLine($"(3) To choose between your Vectors, press \"1\" (v0) or \"2\" (v1).");
                    key = Console.ReadKey();
                    float skalar;
                    if (key.Key == ConsoleKey.D1)
                    {
                        Console.WriteLine($"v0: Now type a number to be your Skalar.");
                        skalar = GetSkalar();
                        Console.WriteLine($"The product of v0 with the Skalar is:");
                        Console.WriteLine($"{_v[0].Multiply(skalar)}");
                    }
                    else if (key.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine($"v1: Now type a number to be your Skalar.");
                        skalar = GetSkalar();
                        Console.WriteLine($"The product of v1 with the Skalar is:");
                        Console.WriteLine($"{_v[1].Multiply(skalar)}");
                    }
                    WaitForNext();
                    continue;
                }
            }

        }

        private static void WaitForNext()
        {
            Console.ReadKey(true);
            GetTextSpacements();
        }

        private static float GetSkalar()
        {
            string input = Console.ReadLine();
            if (float.TryParse(input, out float skalar)) ;
            return skalar;
        }

        private static void DoMathText()
        {
            for (int i = 0; i < mathText[4].GetLength(0); i++)
            {
                Console.WriteLine(mathText[4][i]);
            }
            GetTextSpacements();
        }

        private static void GetTextSpacements()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        private float NextFloat()
        {
            int rndValue = rnd.Next(-1000, 1001) / 10;
            return (float)rndValue;
        }
    }
}
