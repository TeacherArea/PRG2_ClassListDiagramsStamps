using System;
using System.Globalization;
using System.Threading;

namespace PRG2_ClassListDiagramsStamps
{
    internal class Program
    {
        //TODO Skapa en möjlighet att ha flera listor i detta system, så att man kan lägga till sådana med egna namn, och ta bort dem.
        //TODO Spara listorna permanent, antingen i filer eller databas i systemet.

        static StampCollection stampList = new StampCollection();
        static void Main(string[] args)
        {
            Console.Write("Vill du skapa ett frimärke och lägga till i en lista [y/n]? ");
            string? createOrNot = Console.ReadLine();

            if (createOrNot == "y")
            {
                Console.WriteLine("Skapa ett frimärke (ett objekt) genom att skriva in namn, beskrivning och årtal.");
                CreateStampsAndPutToList();
            }
            else
            {
                Console.WriteLine("Välkommen tillbaka.");
            }
        }

        static void CreateStampsAndPutToList()
        {
            string? userInput_Name;         
            while (true)
            {
                Console.Write("Namn: ");
                userInput_Name = Console.ReadLine();

                bool run = true;
                while (run)
                {
                    if (string.IsNullOrEmpty(userInput_Name))
                    {
                        Console.WriteLine("Vänligen skriv in ett lämpligt namn på frimärket. ");
                        userInput_Name = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write("Beskrivning: ");
                string? userInput_Desciption = Console.ReadLine();

                Console.Write("Årtal: ");
                string? userInput_Year = Console.ReadLine();

                int correct_Year = TestOfUserInputYear(userInput_Year);

                Stamps stamp = new Stamps(userInput_Name, userInput_Desciption, correct_Year);
                Console.WriteLine("Frimärket \"" + stamp.Name + "\" från " + stamp.Year + " tillagt.");
                stampList.AddStamp(stamp);

                Console.WriteLine("Lägg till ett nytt frimärke? [y/n]?");
                string? addMore = Console.ReadLine();

                if (addMore == "y")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Till din lista lades till: ");
                    foreach (Stamps stamps in stampList.GetStamps())
                    {
                        Console.WriteLine(stamps.Name + " från året " + stamps.Year + ", med beskrivningen \"" + stamps.Description + "\"");
                    }

                    Console.WriteLine("Tack för att du använder dig av våra tjänster. Välkommen tillbaka.");
                    break;
                }
            }
        }

        /// <summary>
        /// Take a string, converts it to int and check control the range of the possible years
        /// </summary>
        /// <param name="userInput_Year"></param>
        /// <returns>an int with accurate year that a stamp may have been printed</returns>
        static int TestOfUserInputYear(string? userInput_Year)
        {
            int year;
            int now = DateTime.Now.Year;

            while (true)
            {
                bool run = int.TryParse(userInput_Year, out year);
                if (!run)
                {
                    Console.WriteLine("Vänligen skriv in ett år (till exempel 1923) när frimärket tillverkades.");
                    userInput_Year = Console.ReadLine();
                }
                else if (year > now || year < 1839)
                {
                    Console.WriteLine("Frimärken har funnits sedan 1840. Året är nu " + now + " Prova igen: ");
                    userInput_Year = Console.ReadLine();
                }

                else
                {
                    break;
                }
            }
            return year;
        }
    }
}