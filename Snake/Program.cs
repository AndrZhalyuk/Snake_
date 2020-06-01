using System;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            // Встановлення розміру консоль
            Console.SetBufferSize(80, 25);
            

            //Намалювання рамки             
            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine drownLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            upLine.Drow();
            drownLine.Drow();
            leftLine.Drow();
            rightLine.Drow();

           

            //Накид точок
            Point p1 = new Point(4, 5, '*');
            Snake snake = new Snake(p1, 4, Direction.RIGHT);
            snake.Drow();

            Console.ReadLine();
        }

    }
}
