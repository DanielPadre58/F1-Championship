using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace F1_Championship
{
    internal class UserInteraction
    {
        public static bool AskToCreate()
        {
            Console.Clear();

            Console.WriteLine("Do you wish to create a championship");
            Console.WriteLine("Press 1 for yes or 0 for no");
            int choice = -1;

            bool invalid = true;   

            do
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("The choice must be a number between 1 or 0;");
                }

                if (choice == 1)
                {
                    return true;
                }
                else if (choice == 0)
                {
                    Console.WriteLine("The program will now close.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid answer, try again.");
                }

            } while(invalid);

            return false;
        }

        public static bool AskToLoad()
        {
            Console.Clear();

            Console.WriteLine("Do you wish to load a championship");
            Console.WriteLine("Press 1 for yes or 0 for no");
            int choice = -1;

            bool invalid = true;

            do
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("The choice must be a number between 1 or 0;");
                }

                if (choice == 1)
                {
                    return true;
                }
                else if (choice == 0)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid answer, try again.");
                }
                
            } while (invalid);

            return false;
        }

        public static void AskToSave()
        {
            Console.Clear();

            Console.WriteLine("Do you wish to save this championship?");
            Console.WriteLine("Press 1 for yes or 0 for no");
            int choice = -1;

            bool invalid = false;

            do
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("The choice must be a number between 1 or 0;");
                    invalid = true;
                }

                if (choice == 0)
                {
                    FileManager.DeletePath();
                }
                else if(choice == 1)
                {
                    Console.WriteLine("This championship has been saved and ended;\nThanks for using this simulator and bye.");
                    Console.WriteLine("\nPress any key to leave");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid answer, try again.");
                    invalid = true;
                }
            } while (invalid);
        }
    }
}
