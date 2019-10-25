using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
            Snake[] snakearray = new Snake[100];
            Random rnd = new Random();
            int basebody, points, width, height, dx, dy, sleep=60;
            Snake point;
            game();
            void game()
            {
                do
                {
                    basebody = 3;
                    points = 0;
                    dx = -1;
                    dy = 0;
                    Console.CursorVisible = false;
                    width = Console.WindowWidth;
                    height = Console.WindowHeight;
                    point = new Snake(rnd.Next(0, width), rnd.Next(0, height));

                    for (int i = 0; i < snakearray.Length; i++)
                    {
                        if (i < basebody)
                            snakearray[i] = new Snake(width / 2 + i, height / 2);
                        else
                            snakearray[i] = new Snake(0, 0);
                    }
                    do
                    {
                        do
                        {
                            update();
                            checkPointCollision();
                            follow();
                            snakearray[0].x += dx;
                            snakearray[0].y += dy;
                            Thread.Sleep(sleep);
                            checkCollisions();
                        } while (!Console.KeyAvailable);
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.UpArrow:
                                dx = 0;
                                dy = -1;
                                break;

                            case ConsoleKey.DownArrow:
                                dx = 0;
                                dy = 1;
                                break;

                            case ConsoleKey.RightArrow:
                                dx = 1;
                                dy = 0;
                                break;

                            case ConsoleKey.LeftArrow:
                                dx = -1;
                                dy = 0;
                                break;
                            case ConsoleKey.Add:
                                sleep += 10;
                                break;
                            case ConsoleKey.Subtract:
                                sleep -= 10;
                                break;
                        }
                    } while (true);

                } while (true);
            }

            void update()
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(snakearray[0].x, snakearray[0].y);
                Console.Write("O");
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 1; i < basebody + points; i++)
                {
                    Console.SetCursorPosition(snakearray[i].x, snakearray[i].y);
                    Console.Write("O");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(point.x, point.y);
                Console.WriteLine("O");
            }
            void follow()
            {
                for (int i = basebody + points; i > 0; i--)
                {
                    snakearray[i] = new Snake(snakearray[i - 1].x, snakearray[i - 1].y);
                }
            }
            void checkCollisions()
            {
                int i = 2;
                while (!(snakearray[0].x == snakearray[i].x & snakearray[0].y == snakearray[i].y) && i < basebody + points)
                {
                    i++;
                }
                if (i < basebody + points)
                {
                    gameOver();
                }
                else if (snakearray[0].x < 0 || snakearray[0].x > width || snakearray[0].y < 0 || snakearray[0].y > height)
                    gameOver();
            }
            void checkPointCollision()
            {
                if (snakearray[0].x == point.x && snakearray[0].y == point.y)
                {
                    points++;
                    point = new Snake(rnd.Next(0, width), rnd.Next(0, height));
                }
            }
            void gameOver()
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("GAME OVER | PRESS ENTER TO RESTART");
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                    game();
                else
                    Environment.Exit(0);
            }

        }
    }
}