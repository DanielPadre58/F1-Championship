using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Runtime.CompilerServices;

namespace F1_Championship
{
    internal class FileManager
    {
        private static string GetPath()
        {
            return @"C:\PROJECTS\VSProjects\F1 Championship\Championships\Championship";
        }

        private static string previousPath;
        private static string currentPath;

        private static string GetCurrentChampionshipPath()
        {
            if (UserInteraction.AskToLoad())
            {
                string[] loadableChamps = Directory.GetDirectories(@"C:\PROJECTS\VSProjects\F1 Championship\Championships");
                Console.Clear();

                if(loadableChamps.Length == 0)
                {
                    Console.WriteLine("It seems is not a single championship created, so we need to create one;\nPress any key to continue.");
                    Console.ReadLine();

                    return CreatePath();
                }

                bool Invalid;

                do
                {
                    Console.WriteLine("Here are all the championships that can be loaded (select one by inputing his number on the list): \n");
                    for (int i = 0; i < loadableChamps.Length; i++)
                    {
                        string placeHolder = loadableChamps[i].Substring(loadableChamps[i].Length - 13);
                        Console.WriteLine("\n" + (i + 1) + " - " + placeHolder);
                    }

                    int choice = int.Parse(Console.ReadLine());

                    if(choice >= 1 && choice <= loadableChamps.Length)
                    {
                        return loadableChamps[choice - 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer, try again.");
                        Invalid = true;
                    }

                } while (Invalid);
            }
            else
            {
                return CreatePath();
            }

            return null;
        }
        private static string CreatePath()
        {
            for (int i = 1; i > 0; i++)
            {
                if (!Directory.Exists(GetPath() + i) && UserInteraction.AskToCreate())
                {
                    Directory.CreateDirectory(GetPath() + i);


                    string placeHolder = GetPath() + i;

                    if (placeHolder.Contains("Championship1"))
                    {
                        File.Delete(@"C:\PROJECTS\VSProjects\F1 Championship\Championships\Championship1\TeamsCarAdvantage");
                        File.Copy(@"C:\PROJECTS\VSProjects\F1 Championship\CarAdvantages1.txt", @"C:\PROJECTS\VSProjects\F1 Championship\Championships\Championship1\TeamsCarAdvantage.txt");
                    }
                   
                    return placeHolder;
                }
            }

            return null;
        }
        public static void GetCarAdvantage()
        {
            currentPath = GetCurrentChampionshipPath();
            int num = int.Parse(currentPath.Substring(currentPath.Length - 1));
            num = num == 1 ? 1 : num - 1;

            previousPath = currentPath.Substring(0, currentPath.Length - 1) + num;

            string[] content = File.ReadAllLines(previousPath + @"\TeamsCarAdvantage.txt");
                                 
            foreach (Team team in Championship.teams)
            {
                for (int i = 0; i < content.Length - 1; i++)
                { 
                    if (content[i] == team.name)
                    {
                        i++;
                        team.carAdvantage = double.Parse(content[i]);   
                    }
                }
            }
        }
        public static void WriteStatitics()
        {
            StreamWriter writePositionsD = new StreamWriter(currentPath + @"\DriversLeaderboard.txt");

            foreach(KeyValuePair<Driver, double> driver in Championship.DriversPositions)
            {
                writePositionsD.WriteLine("\n" + driver.Key.name + " - " + driver.Value + " points");
            }

            writePositionsD.Close();

            //-----------------------------------------------------------------------------------------------\\

            StreamWriter writePositionsT = new StreamWriter(currentPath + @"\ConstructorsLeaderboard.txt");

            foreach(KeyValuePair<Team, double> team in Championship.TeamsPositions)
            {
                writePositionsT.WriteLine("\n" + team.Key.name + " - " + team.Value + " points");
            }

            writePositionsT.Close();

            //------------------------------------------------------------------------------------------------\\

            StreamWriter writeCarAdvantage = new StreamWriter(currentPath + @"\TeamsCarAdvantage.txt");

            if (!currentPath.Contains("Championship1"))
            {
                    foreach (Team team in Championship.teams)
                    {
                        writeCarAdvantage.WriteLine(team.name);

                        switch (team.position)
                        {
                            case 1:
                                {
                                    writeCarAdvantage.WriteLine(team.carAdvantage + 0.5);
                                    break;
                                }
                            case 2:
                                {
                                    writeCarAdvantage.WriteLine(team.carAdvantage + 0.4);
                                    break;
                                }
                            case 3:
                                {
                                    writeCarAdvantage.WriteLine(team.carAdvantage + 0.3);
                                    break;
                                }
                            case 4:
                                {
                                    writeCarAdvantage.WriteLine(team.carAdvantage + 0.25);
                                    break;
                                }

                            case 5:
                                {
                                    writeCarAdvantage.WriteLine(team.carAdvantage + 0.2);
                                    break;
                                }
                            case 6:
                                {
                                    writeCarAdvantage.WriteLine(team.carAdvantage + 0.15);
                                    break;
                                }
                            case 7:
                                {
                                    writeCarAdvantage.WriteLine(team.carAdvantage + 0.1);
                                    break;
                                }
                            case 8:
                                {
                                    writeCarAdvantage.WriteLine(team.carAdvantage + 0.075);
                                    break;
                                }
                            case 9:
                                {
                                    writeCarAdvantage.WriteLine(team.carAdvantage + 0.05);
                                    break;
                                }
                            case 10:
                                {
                                    writeCarAdvantage.WriteLine(team.carAdvantage + 0.025);
                                    break;
                                }
                        }                     
                    }
                    writeCarAdvantage.Close();
            }     
        }

        public static void DeletePath() 
        { 
            Directory.Delete(GetCurrentChampionshipPath());
        }

    }
  
}
