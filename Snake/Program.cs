using System;
using System.Collections.Generic;
using System.Threading;

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
            Walls walls = new Walls(80, 25);
            walls.Draw();     

            //Накид точок
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();                                   

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Console.CursorVisible = false;
            
            while (true)
            {
                
                    if (walls.IsHit(snake) || snake.IsHitTail())
                    {                        
                        break;
                    }
                    if (snake.Eat(food))
                    {
                        food = foodCreator.CreateFood();
                        food.Draw();
                    }
                    else
                    {
                        snake.Move();
                    }
                    Thread.Sleep(100);
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        snake.HandleKey(key.Key);

                    }
                    snake.Move();
            }               
                
            
            
        }
       


    }
}
