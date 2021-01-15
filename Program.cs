// Użycie przestrzeni nazw System
using System;

// Przestrzeń nazw
namespace NumberGuesser 
{
    // Klasa główna
    class Program 
    {
        // Metoda główna, czyli punkt wejścia programu 
        static void Main(string[] args) 
        {
            // Wyświetl informacje o aplikacji
            GetAppInfo();

            // Zapytaj o imię i zainicjalizuj zmienną typu tesktowego
            string userName = GetUserName();

            // Przywitaj użytkownika
            GreetUser(userName);

            // Wylosuj liczbę z przedziału od 1 do 10
            Random random = new Random();
            // Zainicjalizuj zmienną typu całkowtego
            int correctNumber =  random.Next(1, 11);

            // Zainicjalizuj zmienną typu logicznego
            bool correctAnswer = false;

            // Wyświetl komunikat
            Console.WriteLine("Zgadnij wylosowaną liczbę z przedziału od 1 do 10.");

            // Powtarzaj operacje w pętli dopóki wartość zmiennej correctAnswer jest równa false
            while (!correctAnswer)
            {
                // Pobierz i zainicjalizuj zmienną typu tesktowego
                string input = Console.ReadLine();

                // Zadeklaruj zmienną typu liczbowego
                int guess;

                // Konwertuj typ tesktowy na typ liczbowy
                bool isNumber = int.TryParse(input, out guess);
                
                // Sprawdź czy użytkownik wprowadził liczbę
                if (!isNumber)
                {
                    // Wyświetl komunikat 
                    PrintColorMessage(ConsoleColor.Yellow, "Proszę wprowadzić liczbę.");
                    // Przejdź do kolejnej iteracji pętli
                    continue;
                }

                // Sprawdź czy użytkownik wprowadził liczbę z przediału od 1 do 10
                if (guess < 1 || guess > 10)
                {
                    // Wyświetl komunikat
                    PrintColorMessage(ConsoleColor.Yellow, "Proszę wprowadzić liczbę z przedziału od 1 do 10.");
                    // Przejdź do kolejnej iteracji pętli
                    continue;
                }

                // Sprawdź czy użytkownik wprowadził liczbę mniejszą od wylosowanej liczby
                if (guess < correctNumber)
                {
					// Wyświetl komunikat
                    PrintColorMessage(ConsoleColor.Red, "Błędna odpowiedź. Wylosowana liczba jest większa.");
                }
				// Sprawdź czy użytkownik wprowadził liczbę większą od wylosowanej liczby
                else if (guess > correctNumber)
                {
					// Wyświetl komunikat
                    PrintColorMessage(ConsoleColor.Red, "Błędna odpowiedź. Wylosowana liczba jest mniejsza.");
                }
                else
                {
					 // Przypisz do zmiennej correctAnswer wartość true
                    correctAnswer = true;
					// Wyświetl komunikat
                    PrintColorMessage(ConsoleColor.Green, "Brawo! Prawidłowa odpowiedź!");
                }
            }
        }

        // Wyświetl informacje o aplikacji
        static void GetAppInfo()
        {
            // Zainicjalizuj informacje o aplikacji
            string appName = "Zgadywanie liczby";
            int appVersion = 1;
            string appAuthor = "Patryk Sładek";

            // Przygotuj tekst informacji
            string info = $"[{appName}] Wersja: 0.0.{appVersion}, Autor: {appAuthor}";

            // Wyświetl komunikat w fioletowym kolorze
            PrintColorMessage(ConsoleColor.Magenta, info);

        }

        // Zapytaj o imię i zwróć wartość typu tesktowego
        static string GetUserName()
        {
            // Zapytaj o imię
            Console.WriteLine("Jak masz na imię?");

            // Pobierz odpowiedź użytkownika
            string inputUserName = Console.ReadLine();

            // Zwróć odpowiedź
            return inputUserName;
        }

        // Przywitaj użytkownika
        static void GreetUser(string userName) // Parametrem wejściowym metody jest imię użytkownika 
        {
            // Przygotuj tekst przywitania
            string greet = $"Powodzenia {userName}, odgadnij liczbę...";

            // Wyświetl komunikat w niebieskim kolorze
            PrintColorMessage(ConsoleColor.Blue, greet);

            // Wyświetl pustą linię na konsoli
            Console.WriteLine();
        }

        // Wyświetl komunikat w odpowiednim kolorze
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            // Zmień kolor tekstu konsoli
            Console.ForegroundColor = color;

            // Wyświetl komunikat na konsoli
            Console.WriteLine(message);

            // Zresetuj kolor tekstu konsoli
            Console.ResetColor();
        }
    }
}
