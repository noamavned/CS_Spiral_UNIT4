using System;
using Unit4.TurtleLib;

namespace Spiral
{
    internal class Program
    {
        public static void Spiral(int size, int step = 20, int delay = 0)
        {
            int[,] m = new int[size, size];
            int[] loc = new int[2] { 0, 0 };
            int[] lastLoc = new int[2] { 0, 0 };
            int p = 1;
            Turtle pen = new Turtle();
            pen.SetVisible(false);
            pen.SetDelay(delay);
            pen.MoveForward((size / 2) * step);
            pen.TurnLeft(90);
            pen.MoveForward((size / 2) * step);
            pen.TurnRight(90);
            pen.TailDown();
            int deg = 0;
            while (p <= size * size)
            {
                lastLoc[0] = loc[0];
                lastLoc[1] = loc[1];
                m[loc[0], loc[1]] = p;
                if (loc[1] + 1 < size && m[loc[0], loc[1] + 1] == 0)
                {
                    if (loc[0] == 0)
                    {
                        loc[1] += 1;
                    }
                    else if (m[loc[0] - 1, loc[1]] != 0)
                    {
                        loc[1] += 1;
                    }
                    else
                    {
                        loc[0] -= 1;
                    }
                }
                else if (loc[0] + 1 < size && m[loc[0] + 1, loc[1]] == 0)
                {
                    loc[0] += 1;
                }
                else if (loc[1] - 1 >= 0 && m[loc[0], loc[1] - 1] == 0)
                {
                    loc[1] -= 1;
                }
                else if (loc[0] - 1 >= 0 && m[loc[0] - 1, loc[1]] == 0)
                {
                    loc[0] -= 1;
                }
                int degNeeded = 0;
                if (loc[0] - lastLoc[0] != 0)
                {
                    if (loc[0] > lastLoc[0])
                    {
                        degNeeded = 180 - deg;
                        deg = 180;
                    }
                    else
                    {
                        degNeeded = 0 - deg;
                        deg = 0;
                    }
                }
                else if(loc[1] - lastLoc[1] != 0)
                {
                    if (loc[1] > lastLoc[1])
                    {
                        degNeeded = 90 - deg;
                        deg = 90;
                    }
                    else
                    {
                        degNeeded = 270 - deg;
                        deg = 270;
                    }
                }
                pen.TurnRight(degNeeded);
                if (p != size * size)
                {
                    pen.MoveForward(step);
                }
                p += 1;
            }
        }

        static void Main(string[] args)
        {
            int TEMP;
            System.Console.Write("Enter size: ");
            string size = Console.ReadLine();
            TEMP = int.Parse(size);
            System.Console.Write("Enter step: ");
            string step = Console.ReadLine();
            System.Console.Write("Enter delay: ");
            string delay = Console.ReadLine();
            if(step == "")
            {
                if (delay == "")
                {
                    Spiral(size: int.Parse(size));
                }
                else
                {
                    Spiral(size: int.Parse(size), delay: int.Parse(delay));
                }
            }
            else
            {
                if (delay == "")
                {
                    Spiral(size: int.Parse(size), step: int.Parse(step));
                }
                else
                {
                    Spiral(int.Parse(size), delay: int.Parse(delay), step: int.Parse(step));
                }
            }
        }
    }
}
