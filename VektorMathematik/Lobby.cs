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
        Random rnd = new Random(DateTime.Now.Millisecond);
        private static string[][] introText = [
            [//a0
                "Welcome to the Vector-Calculator!"//0
            ],[//a1
                "If you want to start with random Vector, press \"1\".",//0
                "Or if you want to choose your own Vector, press \"2\"."//1
            ],[//a2
                "Type a X-Value between -99 and 99 for your Vector v1:",//0
                "Type a Y-Value between -99 and 99 for your Vector v1:",//1
                "Type a Z-Value between -99 and 99 for your Vector v1:",//2
                "Type a X-Value between -99 and 99 for your Vector v2:",//3
                "Type a Y-Value between -99 and 99 for your Vector v2:",//4
                "Type a Z-Value between -99 and 99 for your Vector v2"//5
            ],[//a3
                "Your Vector are:",//0
                "Vector v1: ",//1
                "Vector v2: "//2
            ],[//a4
                "Now that you have your Vector you can do various math operations with them:",//0
                "(1) Addition: Get the sum of your Vector;",//1
                "(2) Subtraction: Get the difference of your Vector;",//2
                "(3) Multiplication: Get the product of one of the Vector with a Scalar;",//3
                "(4) Scalar-Product: Get the scalar product by multiplying your Vector;",//4
                "(5) Cross-Product: Get the cross product by multiplying your Vector;",//5
                "(6) Distance: Get the distance between your Vector or others of your liking;",//6
                "(7) Distance: Get the distance between two new Vector;",//7
                "(8) Length: Get the length of one of your Vector;",//8
                "(9) Square-Length: Get the length of one of your Vector squared;",//9
                "(ESC) Restart Vector;"
            ]];
        private string[][] mathText = [
            [//a0
                "To choose between your Vector, press \"1\" (v1) or \"2\" (v2).",//0
                "v1: ",//1
                "v2: ",//2
                "units",//3,
                "Press any key to try again."//4
            ],[//a1
                "(1) The sum of your Vector is:"//0
            ],[//a2
                "(2) The difference of your Vector is:"//0
            ],[//a3
                "(3) ",//0
                "Now pick a number between -99 and 99 to be your Scalar.",//1
                "The product of v0 with thr Scalar is:",//2
                "The product of v1 with the Scalar is:"//3
            ],[//a4
                "(4) The scalar product of your Vector is:"//0
            ],[//a5
                "(5) The cross product of your Vector is:"//0
            ],[//a6
                "(6) The distance between your Vector is:",//0
            ],[//a7
                "(7) The distance between your Vector is:",//0
            ],[//a8
                "(8) ",//0
                "Your Vector has a lenght of:",//1
            ],[//a9
                "(9) ",//0
                "The square length of your Vector is:"//1
            ]];
        #endregion

        public override Screen Start()
        {
            ResizeWindow();
            Console.Clear();

            PrintStart();

            DoMath(GetVectors());
            return this;
        }

        private static void PrintStart()
        {
            Console.WriteLine();
            PrintText(introText[0][0]);
            Console.WriteLine();
            PrintText(introText[1][0]);
            PrintText(introText[1][1]);
        }

        private Vector[] GetVectors()
        {
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
            return vArr;
        }

        private static void PrintVectors(Vector[] _vArr)
        {
            for (int i = 0; i < introText[3].GetLength(0); i++)
            {
                PrintText(introText[3][i] + $"{((i != 0) ? _vArr[i - 1] : "")}");
            }
            Console.WriteLine();
        }

        private Screen DoMath(Vector[] _vArr)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                PrintVectors(_vArr); 
                PrintDoMathText();
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    PrintText($"{mathText[1][0]}\n   {_vArr[0].Add(_vArr[1])}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    PrintText($"{mathText[2][0]}\n   {_vArr[0].Subtract(_vArr[1])}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    PrintText(mathText[3][0] + mathText[0][0]);
                    key = Console.ReadKey(true);
                    float scalar;
                    if (key.Key == ConsoleKey.D1)
                    {
                        PrintText(mathText[0][1] + mathText[3][1]);
                        scalar = GetSkalar();
                        PrintText($"{mathText[3][2]}\n   {_vArr[0].Multiply(scalar)}");
                    }
                    else if (key.Key == ConsoleKey.D2)
                    {
                        PrintText(mathText[0][2] + mathText[3][1]);
                        scalar = GetSkalar();
                        PrintText($"{mathText[3][3]}\n   {_vArr[1].Multiply(scalar)}");
                    }
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    PrintText($"{mathText[4][0]}\n   {_vArr[0].ScalarProduct(_vArr[1])}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D5)
                {
                    PrintText($"{mathText[5][0]}\n   {_vArr[0].CrossProduct(_vArr[1])}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D6)
                {
                    PrintText($"{mathText[6][0]}\n   {_vArr[0].GetDistance(_vArr[1])} {mathText[0][3]}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D7)
                {
                    Vector[] vArr = GetNewVectors();

                    PrintVectors(vArr) ;

                    PrintText($"{mathText[7][0]}\n   {Vector.S_GetDistance(vArr[0], vArr[1])} {mathText[0][3]}");
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D8)
                {
                    PrintText(mathText[8][0] + mathText[0][0]);
                    key = Console.ReadKey(true);
                    while (true)
                    {
                        if (key.Key == ConsoleKey.D1)
                        {
                            PrintText($"{mathText[0][1] + mathText[8][1]}\n   {_vArr[0].GetLength()} {mathText[0][3]}");
                            break;
                        }
                        else if (key.Key == ConsoleKey.D2)
                        {
                            PrintText($"{mathText[0][2] + mathText[8][1]}\n   {_vArr[1].GetLength()} {mathText[0][3]}");
                            break;
                        }
                    }
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.D9)
                {
                    PrintText(mathText[9][0] + mathText[0][0]);
                    key = Console.ReadKey(true);
                    while (true)
                    {
                        if (key.Key == ConsoleKey.D1)
                        {
                            PrintText($"{mathText[0][1] + mathText[9][1]}\n   {_vArr[0].GetSquareLength()} {mathText[0][3]}");
                            break;
                        }
                        else if (key.Key == ConsoleKey.D2)
                        {
                            PrintText($"{mathText[0][2] + mathText[9][1]}\n   {_vArr[1].GetSquareLength()} {mathText[0][3]}");
                            break;
                        }
                    }
                    WaitForNext();
                    continue;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return this;
                }
            }
        }

        private Vector[] GetNewVectors()
        {
            string v1Input;
            string v2Input;
            float[] v1Values = new float[3];
            float[] v2Values = new float[3];
            for (int i = 0; i < 3; i++)
            {
                PrintText(introText[2][i]);
                Console.SetCursorPosition(3, Console.GetCursorPosition().Top);
                v1Input = Console.ReadLine();
                SetValueTo0(v1Input, i);
                if (float.TryParse(v1Input, out v1Values[i])) ;
            }
            for (int i = 0; i < 3; i++)
            {
                PrintText(introText[2][i + 3]);
                Console.SetCursorPosition(3, Console.GetCursorPosition().Top);
                v2Input = Console.ReadLine();
                SetValueTo0(v2Input, i);
                if (float.TryParse(v2Input, out v2Values[i])) ;
            }
            Vector[] vArr = [new Vector(v1Values[0], v1Values[1], v1Values[2]), new Vector(v2Values[0], v2Values[1], v2Values[2])];
            return vArr;
        }

        private static void SetValueTo0(string _input, int i = 0)
        {
            if (_input == "")
            {
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top - 1);
                PrintText("0");
            }
        }

        private void WaitForNext()
        {
            Console.WriteLine();
            PrintText(mathText[0][4]);
            Console.ReadKey(true);
            GetTextSpacements();
        }

        private static float GetSkalar()
        {
            float skalar = 1f;
            string input = Console.ReadLine();
            if (input.Length < 4)
            {
                SetValueTo0(input);
                if (float.TryParse(input, out skalar)) ;
            }
            return skalar;
        }

        private static void PrintDoMathText()
        {
            for (int i = 0; i < introText[4].GetLength(0); i++)
            {
                PrintText(introText[4][i]);
            }
            GetTextSpacements();
        }

        private static void GetTextSpacements()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        private static void PrintText(string _text)
        {
            Console.SetCursorPosition(3, Console.GetCursorPosition().Top);
            Console.WriteLine(_text);
        }

        private float NextFloat()
        {
            int rndValue = rnd.Next(-1000, 1001);
            return (float)rndValue / 10;
        }
    }
}
