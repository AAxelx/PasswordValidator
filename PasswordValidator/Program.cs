using System;
using System.IO;

class Program
{
    static void Main()
    {
        var validPasswords = 0;

        using (StreamReader reader = new StreamReader("passwords.txt"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] parts = line.Split(": ");
                var requirement = parts[0];
                var password = parts[1];

                var symbol = requirement[0];
                string[] range = requirement.Substring(2).Split('-');
                var min = int.Parse(range[0]);
                var max = int.Parse(range[1]);

                var count = 0;
                foreach (var c in password)
                {
                    if (c == symbol)
                    {
                        count++;
                    }
                }

                if (count >= min && count <= max)
                {
                    validPasswords++;
                }
            }
        }

        Console.WriteLine($"Number of valid passwords: {validPasswords}");
    }
}