using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace Base
{
    public static class GameControl
    {
        public static Random rnd = new Random();
        static bool gameStarted = false;

        //static Random randomNumber = new Random();

        public static AreaBehaviour[,] areasInUse = new AreaBehaviour[1,2]; //Changed from 100 areas to 4. EDIT: 2

        public static List<Individual> peopleDatabase = new List<Individual>();
        static List<FactionStatus> factionsInPlay = new List<FactionStatus>();
        static byte startingFactions = 1;

        static public bool StartGame() {
            try {
                if (!gameStarted) {

                    CustomClasses.InitializeUniversalStructs();
                    CreateAreas();
                    CreateIndividuals(2);

                    gameStarted = true;

                    Networking.TCPMaster.StartTCPMasterServer();

                    return true;
                }
                
            } catch (Exception exceptionError) {
                Console.WriteLine(exceptionError);
            }

            return false;
        }

        #region Generation Functions
        static void CreateAreas() {
            //int i = (int)AreaNames.Aeledge; Test cast between int & enum. 
            int areaIndex = 0;
            for (int collumn = 0; collumn < areasInUse.GetLength(0); collumn++) {
                for (int row = 0; row < areasInUse.GetLength(1); row++) {
                    areasInUse[collumn, row] = new AreaBehaviour((AreaNames)areaIndex, Faction.NoFaction);
                    areaIndex += 1;
                }
            }
        }

        static void CreateIndividuals(int amount)
        {
            amount *= areasInUse.Length;
            //print("Quantity of Individuals: " + amount);
            //Gets quantity of names as float. 
            int firstNamesLength = System.Enum.GetValues(typeof(firstNames)).Length;

            for (int i = 0; i < amount; i++)
            {
                //Picks a random name index
                int currentName = rnd.Next(0, firstNamesLength);
                //Assigns name based off index & assigns no faction as faction. 
                peopleDatabase.Add(new Individual(0, (firstNames)currentName));
                //print(peopleDatabase[i].GetFirstName());
            }
            EvenlyDistributeIndividualsBetweenAreas();
        }

        static void EvenlyDistributeIndividualsBetweenAreas()
        {
            int overlaps = 0;
            int currentAssignment;
            for (int i = 0; i < peopleDatabase.Count; i++)
            {
                if (i % areasInUse.Length == 0 && i != 0)
                {
                    overlaps += 1;
                }
                currentAssignment = i - (overlaps * GetAmountOfAreasInUse());
                //print (currentAssignment);

                peopleDatabase[i].AssignLocation((AreaNames)currentAssignment);

                for (int x = 0; x < areasInUse.GetLength(0); x++) {
                    for (int y = 0; y < areasInUse.GetLength(1); y++) {
                        
                        if ((int)areasInUse[x, y].GetName() == currentAssignment) {
                            areasInUse[x, y].AddPerson(i);
                        }
                    }
                }
            }
        }

        static int GetAmountOfAreasInUse() {
            int total = 0;

            total += areasInUse.GetLength(0); //Size of first dimension

            total += areasInUse.GetLength(1); //Size of second dimension

            return total;
        }

        public static int GetPeopleDatabaseSize() {
            return peopleDatabase.Count();
        }

        public static Individual GetPersonInDatabase(int index) {
            return peopleDatabase[index];
        }

        #endregion

#region Network Control

#endregion
    }
}
