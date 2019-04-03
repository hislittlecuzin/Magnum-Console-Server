using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// String to Enum
//Enum.TryParse("EnumIndexNameInStringFormat", out EnumCollectionTitle VariableYouWantToAssignValueTo);
//Example:
//Enum.TryParse("NoFaction", out Faction localVariable);

namespace Console_Server_V1
{
    class ConsoleCommands
    {
        enum SubjectTypes : byte {
            DatabaseLevel,
            AreaLevel,
            IndividualLevel,
            FactionLevel
        }
        static string currentSubject = null;
        static int modeChoice = -1;

        static bool resetAllChoices = false;

        public static void ConsoleLoop() {



            int numChoice = -1;

            //While start:
            while (Program.loopConsole)
            {

                if (resetAllChoices) {
                    currentSubject = null;
                    resetAllChoices = true;
                }

                switch (modeChoice)
                {
                    case 1:
                        ViewDataBases();
                        break;
                    case 2:
                        Console.WriteLine("Not implimented.");
                        break;
                    default:
                        Console.WriteLine("No choice selected");
                        break;
                }

                if (currentSubject != null)
                    Console.WriteLine("Current subject is: " + currentSubject);
                else
                    Console.WriteLine("No current subject");
                Console.WriteLine("Select mode:\n" +
                    "'1' View\n" +
                    "'2' edit?\n");
                modeChoice = ChoiceInput();

            }


        }

        /*
         * 
         * 

         */

        static void ViewDataBases() {

            int viewChoice;

            if (currentSubject != null)
            {
                Console.WriteLine(currentSubject + ":\n" +
                    "'1' View Area depiction\n" +
                    "'2' View Individuals memories\n" +
                    "'420' to reset all choices");
                viewChoice = ChoiceInput();
                switch (viewChoice)
                {
                    case 1:
                        Console.WriteLine("Select Area\n\n\n\n");
                        GetAreas();
                        Console.WriteLine("X location");
                        int xLocate = ChoiceInput();
                        Console.WriteLine("Y location");
                        int yLocate = ChoiceInput();

                        PrintArea(ref Base.GameControl.areasInUse[xLocate, yLocate]);
                        break;
                    case 2:
                        Base.GameControl.peopleDatabase[0].GetMemories();
                        break;
                    case 420:
                        viewChoice = -1;
                        break;
                    default:
                        Console.WriteLine("Invalid syntax.");
                        break;
                }
            }

            Console.WriteLine("View... \n" +
                "'0' to change mode. \n" +
                "'1' areasInUse\n" +
                "'2' peopleDatabase\n" +
                "'3' factionsInPlay\n" +
                "'69' to close the program.\n" +
                "'420' to reset all choices.\n");

            
            viewChoice = ChoiceInput();
            
            

            switch (viewChoice) {
                case 0:
                    modeChoice = -1;
                    break;
                case 1:
                    currentSubject = "areasInUse";
                    GetAreas();
                    break;
                case 2:
                    currentSubject = "peopleDatabase";
                    GetPeople();
                    break;
                case 3:
                    currentSubject = "factionsInPlay";
                    Console.WriteLine("Not implimented.");
                    break;
                case 69:
                    CloseProgram();
                    break;
                case 420:
                    resetAllChoices = true;
                    break;
                default:
                    Console.WriteLine("Syntax error");
                    break;
            }
            
        }

        static int ChoiceInput()
        {
            string input = Console.ReadLine();
            int numChoice;
            try
            {
                numChoice = Convert.ToInt32(input);
                return numChoice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine();
                return -1;
            }
        }

        #region Gets

        static void GetAreas() {
            int index = 0;
            for (int collumn = 0; collumn < Base.GameControl.areasInUse.GetLength(0); collumn++) {
                for (int row = 0; row < Base.GameControl.areasInUse.GetLength(1); row++) {
                    Console.WriteLine("X " + collumn + "Y " + row + " " + Base.GameControl.areasInUse[collumn, row].GetName().ToString());
                    index++;
                }
            }
        }

        static void GetPeople() {
            for (int i = 0; i < Base.GameControl.GetPeopleDatabaseSize(); i++) {
                Console.WriteLine(Base.GameControl.GetPersonInDatabase(i).GetFirstName().ToString());
                Console.WriteLine(Base.GameControl.GetPersonInDatabase(i).GetSociality().ToString());
            }
        }
        #endregion

        static void PrintArea(ref Base.AreaBehaviour areaExamined) {
            int width = areaExamined.GetLocationWidth();
            int height = areaExamined.GetLocationHeight();

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    Base.LocationTile lT = areaExamined.GetLocationTile(x, y);
                    Console.Write(lT.GetGround().ToString() + lT.GetStructure().ToString() + lT.GetStructureAttribute().ToString() + lT.GetIndividualInTile().ToString() + ";");
                }
                Console.Write("\n"); //New line
            }

        }

        static void CloseProgram() {
            Program.loopConsole = false;
        }
    }
}
