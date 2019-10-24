using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace snake
{
    class Snake
    {
        public int x, y;
        public Snake(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        int getX()
        {
            return this.x;
        }
        int getY()
        {
            return this.y;
        }
    }
    class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int points = 3;
            Console.CursorVisible = false;
            Random rnd = new Random();
            int width = Console.WindowWidth, height = Console.WindowHeight;
            Snake[] snakearray = new Snake[100];
            Point point = new Point(rnd.Next(window),0);

            for(int i=0; i < snakearray.Length; i++)
            {
                if (i < 3)
                    snakearray[i] = new Snake(width / 2 + i, height / 2);
                else
                    snakearray[i] = new Snake(0, 0);
            }
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        follow();
                        snakearray[0].y--;
                        break;

                    case ConsoleKey.DownArrow:
                        follow();
                        snakearray[0].y++;
                        break;

                    case ConsoleKey.RightArrow:
                        follow();
                        snakearray[0].x++;
                        break;

                    case ConsoleKey.LeftArrow:
                        follow();
                        snakearray[0].x--;
                        break;
                }
                update();
            } while (true);
            void update()
            {

                Console.Clear();

                for (int i = 0; i < points; i++)
                {
                    Console.SetCursorPosition(snakearray[i].x, snakearray[i].y);
                    Console.Write("O");
                }
            }
            void follow()
            {
                for (int i = 3; i> 0 ; i--)
                {
                    snakearray[i] = new Snake(snakearray[i - 1].x, snakearray[i - 1].y);
                }
            }
        }
    }
}
