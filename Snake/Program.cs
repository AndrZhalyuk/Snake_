using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            VerticalLine v1 = new VerticalLine(0, 10, 5, '%');
            Draw(v1);

            Console.SetWindowSize(80, 25);
            // Встановлення розміру консоль
            Console.SetBufferSize(80, 25);
            

            //Намалювання рамки             
            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine drownLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            upLine.Draw();
            drownLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

           

            //Накид точок
            Point p = new Point(4, 5, '*');
            Figure fSnake = new Snake(p, 4, Direction.RIGHT);
            Draw(fSnake);
            Snake snake = (Snake) fSnake;

            HorizontalLine h1 = new HorizontalLine(0, 5, 6, '&');

            List<Figure> figures = new List<Figure>();
            figures.Add(fSnake);
            figures.Add(v1);
            figures.Add(h1);

            foreach(var f in figures)
            {
                f.Draw();
            }

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Console.CursorVisible = false;
            
            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(150);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                   
                }               
                snake.Move();
            }
            
        }
        static void Draw(Figure figure)
        {
            figure.Draw();
        }


    }
}
