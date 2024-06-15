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
        #region Variables
        Random rnd = new Random(DateTime.Now.Millisecond);                                                    //to do: ClearBoard(), RestartVectors()
        private static string[][] introText = [
            [//a0
                "Welcome to the Vector-Calculator!"//0
            ],[//a1
                "If you want to start with random Vectors, press \"1\".",//0
                "Or if you want to choose your Vectors's values, press \"2\"."//1
            ],[//a2
                "Type a X-Value between -99 and 99 for your Vector v0:",//0
                "Type a Y-Value between -99 and 99 for your Vector v0:",//1
                "Type a Z-Value between -99 and 99 for your Vector v0:",//2
                "Type a X-Value between -99 and 99 for your Vector v1:",//3
                "Type a Y-Value between -99 and 99 for your Vector v1:",//4
                "Type a Z-Value between -99 and 99 for your Vector v1:"//5
            ],[//a3
                "Your Vectors are:",//0
                "Vector v0: ",//1
                "Vector v1: "//2
            ],[//a4
                "Now that you have your Vectors you can do various math operations with them:",//0
                "(1) Addition: Get the sum of your Vectors;",//1
                "(2) Subtraction: Get the difference of your Vectors;",//2
                "(3) Multiplication: Get the product of one of the Vectors with a Scalar;",//3
                "(4) Scalar-Product: Get the scalar product by multiplying your Vectors;",//4
                "(5) Cross-Product: Get the cross product by multiplying your Vectors;",//5
                "(6) Distance: Get the distance between your Vectors or others of your liking;",//6
                "(7) Distance: Get the distance between two new Vectors;",//7
                "(8) Length: Get the length of one of your Vectors;",//8
                "(9) Quadratlänge: ???;"//9
            ]];
        private string[][] mathText = [
            [//a0
                "(1) The sum of your Vectors is:"//0
            ],[//a1
                "(2) The difference of your Vectors is:"//0
            ],[//a2
                "(3) To choose between your Vectors, press \"1\" (v0) or \"2\" (v1).",//0
                "v0: Now pick a number between -99 and 99 to be your Scalar.",//1
                "The product of v0 with thr Scalar is:",//2
                "v1: Now type a number to be your Scalar.",//3
                "The product of v1 with the Scalar is:"//4
            ],[//a3
                "(4) The scalar product of your Vectors is:"//0
            ],[//a4
                "(5) The cross product of your Vectors is:"//0
            ],[//a5
                "(6) The distance between your Vectors is of:",//0
                "units"//1
            ],[//a6
                "(7) The distance between your Vectors is of:",//0
                "units"//1
            ],[//a7
                "(8) To choose between your Vectors, press \"1\" (v0) or \"2\" (v1).",//0
                "v0: Your Vector has a lenght of:",//1
                "v1: Your Vector has a lenght of:",//2
                "units"//3
            ],[//a8
                "(9) "//0
            ]];
        #endregion

        public override Screen Start()
        {
            ResizeWindow();
            Console.WriteLine(introText[0][0]);
            Console.WriteLine();

            DoMath(GetVectors());

            Console.ReadKey();
            return this;
        }

        private Vector[] GetVectors()
        {
            Console.WriteLine(introText[1][0]);
            Console.WriteLine(introText[1][1]);
            Console.WriteLine();
            Vector[] vArr;
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    vArr = [new Vector(NextFloat(), NextFloat(), NextFloat()), new Vector(NextFloat(), NextFloat(), NextFloat())];
                    break;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    vArr = GetNewVectors();
                    GetTextSpacements();
                    break;
                }
            }

            for (int i = 0; i < introText[3].GetLength(0); i++)
            {
                Console.WriteLine(introText[3][i] + $"{((i != 0) ? vArr[i - 1] : "")}");
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
                    Console.WriteLine($"{mathText[0][0]}\n{_v[0].Add(_v[1])}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.WriteLine($"{mathText[1][0]}\n{_v[0].Subtract(_v[1])}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    Console.WriteLine(mathText[2][0]);
                    key = Console.ReadKey(true);
                    float scalar;
                    if (key.Key == ConsoleKey.D1)
                    {
                        Console.WriteLine(mathText[2][1]);
                        scalar = GetSkalar();
                        Console.WriteLine($"{mathText[2][2]}\n{_v[0].Multiply(scalar)}");
                    }
                    else if (key.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine(mathText[2][3]);
                        scalar = GetSkalar();
                        Console.WriteLine($"{mathText[2][4]}\n{_v[1].Multiply(scalar)}");
                    }
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    Console.WriteLine($"{mathText[3][0]}\n{_v[0].ScalarProduct(_v[1])}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D5)
                {
                    Console.WriteLine($"{mathText[4][0]}\n{_v[0].CrossProduct(_v[1])}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D6)
                {
                    Console.WriteLine($"{mathText[5][0]}\n{_v[0].GetDistance(_v[1])} {mathText[5][1]}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D7)
                {
                    Vector[] vArr = GetNewVectors();

                    for (int i = 0; i < introText[3].GetLength(0); i++)
                    {
                        Console.WriteLine(introText[3][i] + $"{((i != 0) ? vArr[i - 1] : "")}");
                    }
                    Console.WriteLine($"{mathText[6][0]}\n{Vector.S_GetDistance(vArr[0], vArr[1])} {mathText[5][1]}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D8)
                {
                    Console.WriteLine(mathText[7][0]);
                    key = Console.ReadKey(true);
                    while (true)
                    {
                        if (key.Key == ConsoleKey.D1)
                        {
                            Console.WriteLine($"{mathText[7][1]}\n{_v[0].GetLength()} {mathText[7][3]}");
                            break;
                        }
                        else if (key.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine($"{mathText[7][2]}\n{_v[1].GetLength()} {mathText[7][3]}");
                            break;
                        }
                    }
                        
                    WaitForNext();
                    continue;
                }
            }
        }

        private Vector[] GetNewVectors()
        {
            string[] v1Input = new string[3];
            string[] v2Input = new string[3];
            float[] v1Values = new float[3];
            float[] v2Values = new float[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(introText[2][i]);
                v1Input[i] = Console.ReadLine();
                if (float.TryParse(v1Input[i], out v1Values[i])) ;
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(introText[2][i + 3]);
                v2Input[i] = Console.ReadLine();
                if (float.TryParse(v2Input[i], out v2Values[i])) ;
            }
            Vector[] vArr = [new Vector(v1Values[0], v1Values[1], v1Values[2]), new Vector(v2Values[0], v2Values[1], v2Values[2])];
            return vArr;
        }

        private static void WaitForNext()
        {
            Console.ReadKey(true);
            GetTextSpacements();
        }

        private static float GetSkalar()
        {
            float skalar = 1f;
            string input = Console.ReadLine();
            if (input.Length < 5)
            {
                if (float.TryParse(input, out skalar)) ;
            }
            return skalar;
        }

        private static void DoMathText()
        {
            for (int i = 0; i < introText[4].GetLength(0); i++)
            {
                Console.WriteLine(introText[4][i]);
            }
            GetTextSpacements();
        }

        private static void GetTextSpacements()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        private float NextFloat()
        {
            int rndValue = rnd.Next(-1000, 1001);
            return (float)rndValue / 10;
        }
    }
}
