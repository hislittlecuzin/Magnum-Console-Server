using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class AreaBehaviour
    {
        AreaNames areaName; //This is the string name that the player will see the area identified as. \n\n Areas MUST be named exactly the same as the scene they correspond with. 
        List<int> population = new List<int>(); //Stores individuals from the main people list by int reference. 

        LocationTile[,] locationTiles = new LocationTile[10,10];
        
        Faction controllingFaction = Faction.NoFaction;

        bool clientComputed;

        /// <summary>
        /// Is the area dangerous because of armed conflict?
        /// War between 2 factions?
        /// Gang rivalry common?
        /// Government suppressing resistance?
        /// </summary>
        bool warZone;


        public void AddPerson(int newPerson) {
            population.Add(newPerson);
        }

        

        public AreaBehaviour(AreaNames name, Faction factionInControl) {
            areaName = name;
            controllingFaction = factionInControl;
            LoadArea();
        }



        #region Loading

        void LoadArea() {
            char currentCharacter;
            int[] coordinates = new int[] { 0, 0 };
            byte spot = 0;
            try
            {
                StreamReader sr = new StreamReader("F:/Documents/MAPS/" + areaName.ToString() + ".txt");

                bool running = true;
                while (running)
                {
                    if (!sr.EndOfStream)
                    {
                        try
                        {
                            currentCharacter = (char)sr.Read();
                            InterpretCharacter(currentCharacter, ref coordinates, ref spot);
                        }
                        catch
                        {
                            
                        }
                    }
                    else {
                        running = false;
                    }
                }

            } catch {
                Console.WriteLine("Missing map file for: " + areaName.ToString());
                
            }
            
        }
        void InterpretCharacter(char currentCharacter, ref int[] coordinates, ref byte spot) {

            //This line shows the current character. For debugging. 
            //Console.WriteLine(currentCharacter);

            if (currentCharacter == '\r')
                return;
            else if (currentCharacter == '\n')
            {
                coordinates[0] = 0;
                coordinates[1]++;
                return;
            }
            else if (currentCharacter == ';')
            {
                spot = 0;
                coordinates[0]++;
            }
            else {
                switch (spot) {
                    case 0:
                        locationTiles[coordinates[0], coordinates[1]].SetGround((GroundTile)(currentCharacter - 48));
                        break;
                    case 1:
                        locationTiles[coordinates[0], coordinates[1]].SetStructure((StructureTile)(currentCharacter - 48));
                        break;
                    case 2:
                        locationTiles[coordinates[0], coordinates[1]].SetStructureAttribute((StructureTileAttribute)(currentCharacter - 48));
                        break;
                }
                spot++;
            }
            
        }

#endregion
        #region GetSet
            public void ChangeControllingFaction(Faction newControllingFaction) {
                controllingFaction = newControllingFaction;
            }

            public bool GetClientComputed() {
                return clientComputed;
            }

            public int GetTotalIndividual() {
                return population.Count();
            }

            public int GetIndividual(int index) {
                return population[index];
            }

            public AreaNames GetName() {
                return areaName;
            }

            public void SetClientComputed(bool newState) {
                clientComputed = newState;
            }

            public int GetLocationHeight()
            {
                return locationTiles.GetLength(1);
            }

            public LocationTile GetLocationTile(int x, int y) {
                return locationTiles[x, y];
            }

            public int GetLocationWidth() {
                return locationTiles.GetLength(0);
            }

            
            #endregion
        }
}
