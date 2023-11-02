using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Championship
{
    internal class Championship
    {
        static Team Mercedes = new Team("Mercedes")
        {
            driver1 = new Driver("Hamilton")
            {
                talent = 4
            },
            driver2 = new Driver("Russel")
            {
                talent = 4.2
            }
        };
        
        static Team RedBull = new Team("RedBull")
        {
            driver1 = new Driver("Verstappen")
            {
                talent = 4.5
            },
            driver2 = new Driver("Perez") 
            { 
                talent = 3.8
            }
        };
        static Team McLaren = new Team("McLaren")
        {
            driver1 = new Driver("Norris")
            {
                talent = 4
            },
            driver2 = new Driver("Piastri")
            {
                talent = 4
            }
        };
        static Team Ferrari = new Team("Ferrari")
        {
            driver1 = new Driver("Leclerc")
            {
                talent = 3.9
            },
            driver2 = new Driver("Sainz")
            {
                talent = 3.7
            }
        };
        static Team AlphaTauri = new Team("Alpha Tauri")
        {
            driver1 = new Driver("Tsunoda")
            {
                talent = 3.1
            },
            driver2 = new Driver("Lawson")
            {
                talent = 2.9
            }
        };
        static Team AlphaRomeo = new Team("Alpha Romeo")
        {
            driver1 = new Driver("Bottas")
            {
                talent = 3.8
            },
            driver2 = new Driver("Ricciardo")
            {
                talent = 3.6
            }        
        };
        static Team Alpine = new Team("Alpine")
        {
            driver1 = new Driver("Ocon")
            {
                talent = 3.3
            },
            driver2 = new Driver("Gasly")
            {
                talent = 3.1
            }          
        };
        static Team Haas = new Team("Haas")
        {
            driver1 = new Driver("Magnussen")
            {
                talent = 4
            },
            driver2 = new Driver("Hulkenberg")
            {
                talent = 3.3
            }              
        };
        static Team Williams = new Team("Williams")
        {
            driver1 = new Driver("Albon")
            {
                talent = 3.4
            },
            driver2 = new Driver("Sargeant")
            {
                talent = 2.8
            }
        };
        static Team AstonMartin = new Team("Aston Martin")
        {
            driver1 = new Driver("Stroll")
            {
                talent = 3.5
            },
            driver2 = new Driver("Alonso")
            {
                talent = 3.9
            }
        };

        public static List<Team> AddToList()
        {
            List<Team> placeHolder = new List<Team>();

            placeHolder.Add(RedBull);
            placeHolder.Add(Mercedes);
            placeHolder.Add(McLaren);
            placeHolder.Add(Ferrari);
            placeHolder.Add(Alpine);
            placeHolder.Add(Haas);
            placeHolder.Add(AlphaRomeo);
            placeHolder.Add(AlphaTauri);
            placeHolder.Add(Williams);
            placeHolder.Add(AstonMartin);

            return placeHolder;
        }

        public static List<Team> teams = AddToList();

        public static void WriteTeams()
        {
            Console.Clear();

            Console.WriteLine("The teams participating in the championship and their drivers are:");

            for (int i =0; i < teams.Count; i++)
            {
                Console.WriteLine("\n" + teams[i].name + " - Drivers: " + teams[i].driver1.name + " and " + teams[i].driver2.name + '.');
            }

            Console.WriteLine("\n\nPress any key to continue:");
            Console.ReadLine();
        }

        public static Dictionary<Driver, double> DriversPositions = new Dictionary<Driver, double>();
        public static Dictionary<Team, double> TeamsPositions = new Dictionary<Team, double>();

        public static void SimulateChampionship()
        {
            FileManager.GetCarAdvantage();

            WriteTeams();

            Random chance = new Random();

            foreach (Team team in teams)
            {
                DriversPositions.Add(team.driver1, 0);
                DriversPositions.Add(team.driver2, 0);
            }

            for (int i = 1; i <= 23; i++)
            {
                foreach(Team team in teams)
                {
                    team.driver1.currentChance = chance.Next(1, 7) * team.driver1.talent * team.carAdvantage;

                    do
                    {
                        team.driver2.currentChance = chance.Next(1, 7) * team.driver2.talent * team.carAdvantage;

                    } while (team.driver1.currentChance == team.driver2.currentChance);

                    DriversPositions[team.driver1] = team.driver1.currentChance;
                    DriversPositions[team.driver2] = team.driver2.currentChance;
                }

                

                for (int j = 0; j < DriversPositions.Count - 10; j++)
                {
                    DriversPositions = DriversPositions.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                    KeyValuePair<Driver, double> getPosition = DriversPositions.ElementAt(j);

                    switch (j + 1)
                    {
                        case 1:
                            getPosition.Key.points += 25;
                            break;
                        case 2:
                            getPosition.Key.points += 18;
                            break;
                        case 3:
                            getPosition.Key.points += 15;
                            break;
                        case 4:
                            getPosition.Key.points += 12;
                            break;
                        case 5:
                            getPosition.Key.points += 10;
                            break;
                        case 6:
                            getPosition.Key.points += 8;
                            break;
                        case 7:
                            getPosition.Key.points += 6;
                            break;
                        case 8:
                            getPosition.Key.points += 4;
                            break;
                        case 9:
                            getPosition.Key.points += 2;
                            break;
                        case 10:
                            getPosition.Key.points += 1;
                            break;
                    }
                }
            }

            DriversPositions.Clear();

            foreach(Team team in teams)
            {
                DriversPositions.Add(team.driver1, team.driver1.points);
                DriversPositions.Add(team.driver2, team.driver2.points);

                team.points = team.driver1.points + team.driver2.points;
                TeamsPositions.Add(team, team.points);

                DriversPositions = DriversPositions.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                TeamsPositions = TeamsPositions.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }

            Console.Clear();
            Console.WriteLine("The results of the championship are:");

            for (int k = 0; k < DriversPositions.Count; k++)
            {
                if(k < 10)
                {
                    KeyValuePair<Team, double> getTeamPosition = TeamsPositions.ElementAt(k);

                    getTeamPosition.Key.position = k + 1;
                }

                KeyValuePair <Driver, double> printDriver = DriversPositions.ElementAt(k);

                
                Console.WriteLine("\n" + (k + 1) + "-" + printDriver.Key.name + " - " + printDriver.Value + " points");              
            }

            Console.WriteLine("\nPress any key to continue:");
            Console.ReadLine();

            FileManager.WriteStatitics();

            UserInteraction.AskToSave();
        }
    }
}
