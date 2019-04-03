using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * What characterised an individual? 
+ * 1. 4 base personality traits (INTJ or Mayar Briggs) - 4 variables
 * 2. Professional occupation (student, soldier, farmer) - 1 variable
 * 3. Wellness (I'm well! I hate my job. I'm starving) 
 *      - Function that evaluates personality correlation with job, physical wellness
 *          economic status, & political views with political events. 
 * 4. Where are you living? (Current area they are in. Later update to house location) 
 *      - 1 variable
 * 5. Where do you come from? (Original starting area) - 1 variable
 * 6. Needs - Function that looks at wellness & determines what's lacking. 
 * 7. Political View (I hate the Bloodmonger Faction, The government should control 
 *      more, The government should control less, I like my Faction) - Function based
 *      on needs, personality & state of Faction & Factions interacting with Current
 *      Faction. 
*/

namespace Base
{

    public class Individual
    {
        #region wellness
        private bool stunned;
        private bool suppressed;

        BodyPart head, body, leftArm, leftLeg, rightArm, rightLeg;
        #endregion

        #region Feeling
        byte hunger;
        byte thirst;

        bool hungry;
        bool thirsty;
        #endregion

        #region personality
        ObjectiveDeduction socialNature;            //Introversion/Extroversion
        SubjectiveDeduction observationalNature;    //Intuition/Sensing
        SubjectiveInductive decisionalNature;       //Thinking/Feeling
        ObjectiveInduction socialPresentation;      //Judging/Perception
        #endregion

        #region Memory
        Dictionary<string, MemoryBase> memories = new Dictionary<string, MemoryBase>();
        #endregion

        AreaNames startingArea;
        firstNames name;

        Jobs professionalOccupation; //Student, farmer, soldier ETC
        Jobs aspiringCareer;

        Faction currentFaction;
        AreaNames currentArea;

        //Constructor
        public Individual(Faction assignedFaction, firstNames assignedName) {
            stunned = false;
            suppressed = false;

            InitializeBodyParts();
            InitializePersonality();

            //Variable values. IE these are Enumeration values. 
            currentFaction = assignedFaction;
            name = assignedName;
            TestAddMemory();
        }

        #region sets
        public void AssignFaction(Faction newFaction) {
            currentFaction = newFaction;
        }

        public void AssignLocation(AreaNames newLocation) {
            currentArea = newLocation;
            startingArea = newLocation; //Remove later. 
            Console.WriteLine(currentArea);
        }
        #endregion

        #region Gets

            #region GetStats
            public Faction GetCurrentFaction() {
                return currentFaction;
            }

            public firstNames GetFirstName() {
                return name;
            }
        
            public FootSpeed GetSpeed() {
                if (leftLeg.GetBoneCondition() == BoneCondition.broken && rightLeg.GetBoneCondition() == BoneCondition.broken)
                {
                    return FootSpeed.immobilized;
                }
                else if (leftLeg.GetBoneCondition() == BoneCondition.broken && rightLeg.GetBoneCondition() == BoneCondition.broken)
                {
                    return FootSpeed.limping;
                }
                else {
                    return FootSpeed.full;
                }
            }

            public ObjectiveDeduction GetSociality() {
                return socialNature;
            }
        #endregion

            #region GetMemories
                public void GetMemories() {
                    foreach (KeyValuePair<string, MemoryBase> mem in memories) {
                        Console.WriteLine(mem.Key.ToString());
                        Console.WriteLine(mem.Value.ToString());
                    }
                }
            #endregion

        #endregion

        public void TestAddMemory() {
            MemoryBase newBaseMem = new MemoryBase();
            MemoryPerson newPerson = new MemoryPerson(this);
            /*memories.Add(newBaseMem);
            memories.Add(newPerson);*/
        }

        public bool Germane() {
            if (stunned) {
                return false;
            }
            return true;
        }

        #region Initializes
        private void InitializeBodyParts() {
            head.InitializeBodyPart();
            body.InitializeBodyPart();
            leftArm.InitializeBodyPart();
            leftLeg.InitializeBodyPart();
            rightArm.InitializeBodyPart();
            rightLeg.InitializeBodyPart();
        }
        //new AreaBehaviour((AreaNames)areaIndex
        private void InitializePersonality() {
            socialNature = (ObjectiveDeduction)RandomNumber(sizeof(ObjectiveDeduction) + 1);
            observationalNature = (SubjectiveDeduction)RandomNumber(sizeof(SubjectiveDeduction) + 1);
            decisionalNature = (SubjectiveInductive)RandomNumber(sizeof(SubjectiveInductive) + 1);
            socialPresentation = (ObjectiveInduction)RandomNumber(sizeof(ObjectiveInduction) + 1);
        }

        private int RandomNumber(int between) {
            return (int)GameControl.rnd.Next(between);
        }
        #endregion
    }
}
