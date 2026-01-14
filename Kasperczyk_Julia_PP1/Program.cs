List<int> guesses = new List<int>();
int lives = 10;
int minNumber = 1;
int maxNumber = 50;
int secretNumber = Random.Shared.Next(minNumber, maxNumber + 1);

Console.WriteLine("-----------ZGADNIJ LICZBĘ----------");

Console.WriteLine("Podaj nazwę użytkownika:");
string PlayerName = Console.ReadLine()!;
if (string.IsNullOrWhiteSpace(PlayerName))
{
    Console.WriteLine("Nie podałeś żadnej nazwy więc będę cię nazywał Tomek");
    PlayerName = "Tomek";
}

Console.WriteLine($"\nWitaj {PlayerName}!");
Console.WriteLine($"Zgadnij liczbę pomiędzy {minNumber} a {maxNumber}");
Console.WriteLine($"Masz na to {lives} prób.\n");

while(lives > 0)
{
    Console.Write("Podaj Liczbę: ");
    string input = Console.ReadLine()!;
    
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Podanie pustej wartości nie jest możliwe.\n");
        continue;
    }

    bool isNumber = int.TryParse(input, out int guess);
    
    if (!isNumber)
    {
        Console.WriteLine("To nie jest liczba.\n");
        continue;
    }

    guesses.Add(guess);

    if (guess == secretNumber)
    {
        Console.WriteLine($"Wygrałeś {PlayerName}!");
        break;
    }
    else if (guess > secretNumber)
    {
        Console.WriteLine("Liczba jest za wysoka!");
        lives--;
    }
    else
    {
        Console.WriteLine("Liczba jest za niska!");
        lives--;
    }

    Console.WriteLine($"Pozostało ci: {lives} żyć\n");
}

if (lives == 0)
{
    Console.WriteLine($"Koniec Gry!! Wylosowana liczba to: {secretNumber}");
}

Console.WriteLine("\nTwoje próby:");
foreach (int g in guesses)
{
    Console.Write(g + " ");
}
Console.WriteLine();
