using System;

namespace Практическая_2
{
    class Program
    {
        public static int Rand()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 10);
            int i = value % 2;
            return i;
        }

        public static int makebet()
        {
            try
            {
                Console.WriteLine("Сделайте вашу ставку: ");
                int bet = Int32.Parse(Console.ReadLine());
                return bet;
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception was thrown: {0}", e.Message);
                return -1;
            }
        }

        public static int Exit(int balance)
        {
            Console.WriteLine("Хотите продолжить игру? Да(0) / Нет(1)");
            int e = Int32.Parse(Console.ReadLine());
            if (e == 0)
                return balance;
            else
            {
                Console.WriteLine("Ваш баланс равен {0}", balance);
                return -1;
            }
        }

        public static bool choice()
        {
            Console.WriteLine("Сделайте выбор: четное(0) или нечетное(1)");
            int i = Int32.Parse(Console.ReadLine());
            while (i != 0 && i != 1)
            {
                Console.WriteLine("Можно выбрать только 0 или 1. Попробуйте еще раз.");
                i = Int32.Parse(Console.ReadLine());
            }
            int rnd = Rand();
            if (rnd == i)
                return true;
            else
                return false;
        }

        public static void plusbet(ref int balance, int bet)
        {
            Console.WriteLine("Ваша ставка сыграла!");
            balance += bet;
            Console.WriteLine("Ваш баланс равен {0}", balance);
        }

        public static void minusbet(ref int balance, int bet)
        {
            Console.WriteLine("Ваша ставка не сыграла!");
            balance -= bet;
            Console.WriteLine("Ваш баланс равен {0}", balance);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите стартовый баланс: ");
            int balance = Int32.Parse(Console.ReadLine());
            while (balance <= 0)
            {
                Console.WriteLine("Введеное значение недопустимо! Попробуйте еще раз.");
                balance = Int32.Parse(Console.ReadLine());
            }
            while (balance > 0)
            {
                int bet = makebet();
                while (bet > balance || bet <= 0)
                {
                    Console.WriteLine("Введенная ставка некорректна. Попробуйте еще раз.");
                    bet = makebet();
                }
                bool ch = choice();
                if (ch == true)
                    plusbet(ref balance, bet);
                else
                    minusbet(ref balance, bet);
                   
                balance = Exit(balance);
            }
            Console.WriteLine("Игра окончена");
        }
    }
}
