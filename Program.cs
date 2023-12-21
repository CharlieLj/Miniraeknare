using System;
using System.Collections.Generic;

class Miniräknare
{
    static void Main()
    {
        // Välkomsmeddelande / Welcome 
        Console.WriteLine("Välkommen till Miniräknaren!");
        // skapar en lista (resultatHistorik) för att spara historiken över tidigare resultat. / Creates a list and saves the history of results
        List<double> resultatHistorik = new List<double>();

        // En while-loop som fortsätter att köra så länge fortsätt är sant. / while-loop runs as long as user wants to continue 
        bool fortsätt = true;
        while (fortsätt)
        {
            // Användaren matar in tal / user types a number
            Console.Write("Ange ett tal: ");
            double tal1;
            while (!double.TryParse(Console.ReadLine(), out tal1))
            {
                Console.WriteLine("Ogiltig inmatning. Försök igen.");
            }

            Console.Write("Ange en matematisk operation (+, -, *, /): ");
            // Användaren får ange en matematisk operation. Svaret sparas som en sträng i variabeln operation. / user types a math operation and the input is saved in a string
            string operation = Console.ReadLine();

            // Här kontrolleras vad användaren valde för val. / User input is controlled and checked if correct
            if (operation == "+" || operation == "-" || operation == "/" || operation == "*")
            {
                Console.Write("Ange ett annat tal än 0: ");

                // variabel tal2 av datatypen double / variable with name tal2 of the type double 
                double tal2;

                // en while-loop som fortsätter att köra så länge villkoret inom parenteserna är sant. / while-loop runs if user makes incorrect input
                while (!double.TryParse(Console.ReadLine(), out tal2) || tal2 == 0) // (tal2 == 0) = Kontrollerar om värdet av tal2 är lika med 0. / checks if input is 0
                {
                    Console.WriteLine("Ogiltig inmatning. Försök igen med ett annat tal än 0.");
                }

                // Ifall användaren skulle dela med 0 visa Ogiltig inmatning / incorrect input shows if user makes incorrect input
                if (operation == "/" && tal2 == 0)
                {
                    Console.WriteLine("Ogiltig inmatning. Du kan inte dela med 0.");
                    continue;
                }

                // Resultatet av operationen räknas med funktionen UtförOperation, och resultatet samt historiken läggs till i listan. / calculate results, and adds the result to the history list
                double resultat = UtförOperation(tal1, tal2, operation);
                resultatHistorik.Add(resultat);

                // Visa resultat / shows results
                Console.WriteLine($"Resultatet är: {resultat}");
            }
            else
            {
                Console.WriteLine("Ogiltig operation. Endast +, -, *, / är tillåtna.");
            }

            // Fråga användaren om den vill visa tidigare resultat. / asks user if they want to see results from before
            Console.Write("Vill du visa tidigare resultat? (ja/nej): ");
            string visaHistorikSvar = Console.ReadLine().ToLower();

            // Visa tidigare resultat / shows results
            if (visaHistorikSvar == "ja")
            {
                Console.WriteLine("Tidigare resultat:");
                foreach (var resultat in resultatHistorik)
                {
                    Console.WriteLine(resultat);
                }
            }

            // Fråga användaren om den vill avsluta eller fortsätta. / asks user if they want to continue 
            Console.Write("Vill du fortsätta? (ja/nej): ");
            string fortsättSvar = Console.ReadLine().ToLower();
            fortsätt = fortsättSvar == "ja";
        }
    }

    static double UtförOperation(double tal1, double tal2, string operation)
    {
        if (operation == "+")
        {
            return tal1 + tal2;
        }
        else if (operation == "-")
        {
            return tal1 - tal2;
        }
        else if (operation == "*")
        {
            return tal1 * tal2;
        }
        else if (operation == "/")
        {
            return tal1 / tal2;
        }
        else
        {
            throw new ArgumentException("Ogiltig operation");
        }

    }
}