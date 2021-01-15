using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();

            string userName = GetUserName();

            GreetUser(userName);

            Random random = new Random();
            int correctNumber =  random.Next(1, 11); 

            bool correctAnswer = false;

            Console.WriteLine("Zgadnij wylosowaną liczbę z przedziału od 1 do 10.");

            while (!correctAnswer)
            {
                string input = Console.ReadLine();

                int guess;

                bool isNumber = int.TryParse(input, out guess);
                if (!isNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Proszę wprowadzić liczbę.");
                    continue;
                }

                if (guess < 1 || guess > 10)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Proszę wprowadzić liczbę z przedziału od 1 do 10.");
                    continue;
                }

                if (guess < correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Błędna odpowiedź. Wylosowana liczba jest większa.");
                }
                else if (guess > correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Błędna odpowiedź. Wylosowana liczba jest mniejsza.");
                }
                else
                {
                    correctAnswer = true;
                    PrintColorMessage(ConsoleColor.Green, "Brawo! Prawidłowa odpowiedź!");
                }
            }
        }

        static void GetAppInfo()
        {
            string appName = "Zgadywanie liczby";
            int appVersion = 1;
            string appAuthor = "Patryk Sładek";

            string info = $"[{appName}] Wersja: 0.0.{appVersion}, Autor: {appAuthor}";

            PrintColorMessage(ConsoleColor.Magenta, info);

        }

        static string GetUserName()
        {
            Console.WriteLine("Jak masz na imię?");

            string inputUserName = Console.ReadLine();

            return inputUserName;
        }

        static void GreetUser(string userName)
        {
            string greet = $"Powodzenia {userName}, odgadnij liczbę...";

            PrintColorMessage(ConsoleColor.Blue, greet);

            Console.WriteLine();
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
