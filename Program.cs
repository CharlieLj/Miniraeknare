using System;
using System.Collections.Generic;

class Miniräknare
{
    static void Main()
    {
        Console.WriteLine("Välkommen till Miniräknaren!");
        // skapar en lista (resultatHistorik) för att spara historiken över tidigare resultat.
        List<double> resultatHistorik = new List<double>();

        // En while-loop som fortsätter att köra så länge fortsätt är sant. fortsätt används för att styra om programmet ska fortsätta att köra eller avslutas.
        bool fortsätt = true;
        while (fortsätt)
        {
            Console.Write("Ange ett tal: ");
            double tal1;
            while (!double.TryParse(Console.ReadLine(), out tal1))
            {
                Console.WriteLine("Ogiltig inmatning. Försök igen.");
            }

            Console.Write("Ange en matematisk operation (+, -, *, /): ");
            // Användaren får ange en matematisk operation. Svaret sparas som en sträng i variabeln operation.
            string operation = Console.ReadLine();

            // Här kontrolleras vad användaren valde för val.
            if (operation == "+" || operation == "-" || operation == "/" || operation == "*")
            {
                Console.Write("Ange ett annat tal än 0: ");

                // en variabel tal2 av datatypen double
                double tal2;

                // en while-loop som fortsätter att köra så länge villkoret inom parenteserna är sant. 
                while (!double.TryParse(Console.ReadLine(), out tal2) || tal2 == 0) // (tal2 == 0) = Kontrollerar om värdet av tal2 är lika med 0.
                {
                    Console.WriteLine("Ogiltig inmatning. Försök igen med ett annat tal än 0.");
                }

                if (operation == "/" && tal2 == 0)
                {
                    Console.WriteLine("Ogiltig inmatning. Du kan inte dela med 0.");
                    continue;
                }

                // Resultatet av operationen räknas med funktionen UtförOperation, och resultatet samt historiken läggs till i listan.
                double resultat = UtförOperation(tal1, tal2, operation);
                resultatHistorik.Add(resultat);

                Console.WriteLine($"Resultatet är: {resultat}");
            }
            else
            {
                Console.WriteLine("Ogiltig operation. Endast +, -, *, / är tillåtna.");
            }

            Console.Write("Vill du visa tidigare resultat? (ja/nej): ");
            string visaHistorikSvar = Console.ReadLine().ToLower();

            if (visaHistorikSvar == "ja")
            {
                Console.WriteLine("Tidigare resultat:");
                foreach (var resultat in resultatHistorik)
                {
                    Console.WriteLine(resultat);
                }
            }

            Console.Write("Vill du fortsätta? (ja/nej): ");
            string fortsättSvar = Console.ReadLine().ToLower();
            fortsätt = fortsättSvar == "ja";
        }
    }
}