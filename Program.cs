internal class Program
{

    class snake
    {
        int Height = 20;
        int Width = 30;

        int[] x = new int[50];
        int[] y = new int[50];

        int fruitX;
        int fruitY;

        int parts = 3;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'w';

        Random rnd = new Random();

        snake()
        {
            x[0] = 5;
            y[0] = 5;
            Console.CursorVisible = false;
            fruitX = rnd.Next(2, (Width - 2));
            fruitY = rnd.Next(2, (Height - 2));
        }

    public void WriteBoard()
        {
            Console.Clear();
            for (int i =1; i <= (Width+2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (Width + 2); i++)
            {
                Console.SetCursorPosition(i, (Height+2));
                Console.Write("-");
            }
            for (int i = 1; i <= (Height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Height + 2); i++)
            {
                Console.SetCursorPosition((Width+2), i);
                Console.Write("|");
            }
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        public void WritePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }


        public void Logic()
        {
            if (x[0]==fruitX)
            {
                if (y[0]==fruitY)
                {
                    parts++;
                    //fruitX = rnd.Next(2, (Width-2));
                    //fruitY = rnd.Next(2, (Height-2));   
                }
            }
            for (int i = parts; i > 1; i--)
            {
                x[i - 1] = x[i - 2];
                y[i - 1] = y[i - 2];
            }
            switch (key)
            {
                case 'w':
                    y[0]--;
                    break;
                case 's':
                    y[0]++;
                    break;
                case 'd':
                    x[0]++;
                    break;
                case 'a':
                    x[0]--;
                    break;


            }
            for (int i = 0; i < (parts - 1); i++)
            {
                WritePoint(x[i], y[i]);
                WritePoint(fruitX, fruitY);
            }
            Thread.Sleep(100);
        }
    private static void Main(string[] args)
    {


            snake snake = new snake();
            while (true)
            {
                snake.WriteBoard();
                snake.Input();
                snake.Logic();
            }
            Console.ReadKey();



        }
    }
}