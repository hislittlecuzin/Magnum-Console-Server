using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    #region Enumerations
        #region Individual Data
            public enum firstNames
            {
                Rochelle,
                Cathryn,
                Herb,
                Korey,
                Neta,
                Corinne,
                Layne,
                Shavonda,
                Andra,
                Janeen,
                Jillian,
                Christene,
                Nelson,
                Rhona,
                Wava,
                Celsa,
                Chara,
                Alene,
                Delia,
                Lezlie
            }

    public enum JobLevel : byte {
        Unemployed, //For children, poor people, people not assigned/taking work yet.
        Student,    //Training for a job or learning. Not working. 
        Apprentice, //Trainee, working at low level. Like an associate. 
        Journeyman, //Average skill
        Expert,     //Highest skilled. Rare to get. Requires lots and lots of experience
        Manager,    //Puts him in charge of others
        Boss        //Leader of company
    }

    public enum Jobs : byte {
        Unemployed,
        Student,
        Farmer,
        Shopkeeper, //Extroverted
        Soldier,
        Politician, //Extroverted
        Hunter,     //Introverted
        Engineer
    }

    public enum JobSpecialization : byte{
        Null,
        /// <summary>
        /// For Farmers
        /// </summary>
        Animals,
        /// <summary>
        /// For Farmers
        /// </summary>
        Crops,
        /// <summary>
        /// For Soldiers
        /// </summary>
        Infantry,
        /// <summary>
        /// For Soldiers
        /// </summary>
        Sniper,
        /// <summary>
        /// For Soldiers
        /// </summary>
        Explosives,
        /// <summary>
        /// For Soldiers
        /// </summary>
        Jeeps,
        /// <summary>
        /// For Soldiers
        /// </summary>
        APC,
        /// <summary>
        /// For Soldiers
        /// </summary>
        Tanks,
        /// <summary>
        /// For Soldiers
        /// </summary>
        Communications,
        /// <summary>
        /// For Engineers
        /// </summary>
        Weapons,
        /// <summary>
        /// For Engineers
        /// </summary>
        Buildings,
        /// <summary>
        /// For Engineers
        /// </summary>
        Electronics
    }

    public enum SecondarySkills : byte {
        Null,
        Medicine,
        Stealing,
        Shooting,
        Mechanics,
        Electronics,
        AnimalCare,
        Militia,
        Art
    }


            #region Physical Data

                public enum FleshCondition : byte {
                    pristine, bleeding, heavyBleeding
                }
                public enum BoneCondition : byte {
                    pristine, healed, casted, broken
                }

                public enum FootSpeed : byte {
                    full, casted, limping, stretcher, immobilized
                }
                public enum StandardValues : byte {
                    normalMove = 1, fastMove = 2, 
                }

    #endregion

    #region Mental Data

    /// <summary>
    /// Dealing/interaction with others
    /// </summary>
    public enum ObjectiveDeduction : byte
    {
        /// <summary>
        /// Thought-Oriented
        /// Depth & specialization
        /// Likes Substantail Interaction
        /// Gain energy from being alone
        /// Learns in private study
        /// </summary>
        Introversion,
        /// <summary>
        /// Action-Oriented
        /// "Jack of all trades, specialist in nothing"
        /// Likes Frequent Interaction
        /// Gain energy from being with people
        /// Learns from collaberation
        /// </summary>
        Extraversion
    }

    /// <summary>
    /// focal point of attentions
    /// </summary>
    public enum SubjectiveDeduction : byte {
        /// <summary>
        /// Can learn through theory & abstract concepts
        /// Prefers meaning & associations. 
        /// Insight is valued higher than careful observation.
        /// Pattern recognition occurs naturally
        /// </summary>
        Intuition,
        /// <summary>
        /// Can only learn through concrete facts. 
        /// Distrust of "hunches."
        /// </summary>
        Sensing
    }
    /// <summary>
    /// Decision preferences
    /// </summary>
    public enum SubjectiveInductive : byte {
        /// <summary>
        /// Make decisions from what's the most logical. 
        /// Make detached decisions from what's logical. 
        /// Have trouble interacting with people who are inconsistant/illogical
        /// Give direct feedback & concerned with truth. 
        /// </summary>
        Thinking,
        /// <summary>
        /// Make decisions from Empathy. 
        /// What is best based on making people happy.
        /// </summary>
        Feeling
        
    }

    /// <summary>
    /// How one regards complexity
    /// </summary>
    public enum ObjectiveInduction : byte {
        /// <summary>
        /// Structured & organised
        /// try to make accomodation between new information & pre-structured world.
        /// Changes only occur after discretion. 
        /// Show others their Judging (SubjectiveInductive) thought process (Feeling/Thinking)
        /// </summary>
        Judging,
        /// <summary>
        /// Unstructured & keeping options open. 
        /// Change easily & don't keep a structured world.
        /// Show others their Percieving (SubjectiveDeduction) thought process (Intuition/Sensing)
        /// </summary>
        Perception

    }

    #endregion
    #endregion

    #region Vocabulary

        #region Adjectives

            public enum Size : byte {
                small,
                average,
                big
            }

            public enum Speed : byte {
                slow,
                average,
                fast
            }

            public enum Colour : byte {
                light,
                muted,
                dark
            }

            public enum Karma : byte {
                bad,
                aquainted,
                good
            }

    #endregion
    #endregion

    #region Universal Data
    public enum Guns : byte {
                assaultRifle, sniperRifle, machineGun
            }

            #region Area/Location Data

                    public enum AreaNames {
                        Whiteshore,
                        Wellshadow,
                        Coldhedge,
                        Whitepond,
                        Faybeech,
                        Silverdeer,
                        Greyhall,
                        Shadowsnow,
                        Sagewick,
                        Lorland,
                        Vertwater,
                        Welldale,
                        Butteracre,
                        Lochbridge,
                        Beachhollow,
                        Coldbridge,
                        Starryedge,
                        Wellbush,
                        Silverfield,
                        Brightwyn,
                        Greenedge,
                        Ironburn,
                        Seawynne,
                        Linwall,
                        Westhaven,
                        Westmere,
                        Lochsnow,
                        Swyndale,
                        Fallmead,
                        Glassice,
                        Byton,
                        Courtshore,
                        Westsnow,
                        Maplefield,
                        Applemarsh,
                        Valston,
                        Flowerlea,
                        Highston,
                        Meadowcliff,
                        Merriwald,
                        Mallowvale,
                        Shadowdell,
                        Meadowgate,
                        Drachall,
                        Fayvale,
                        Goldwick,
                        Corfield,
                        Raynesse,
                        Lorham,
                        Janton,
                        Winterford,
                        Strongbell,
                        Shadedell,
                        Ironcliff,
                        Highville,
                        Stonefox,
                        Whitebridge,
                        Bluebell,
                        Marbleton,
                        Cliffbarrow,
                        Faywald,
                        Southbarrow,
                        Rosefog,
                        Byiron,
                        Blueview,
                        Fairmage,
                        Lochfair,
                        Esterwell,
                        Violetedge,
                        Wayland,
                        Violethall,
                        Loredge,
                        Summerwitch,
                        Normoor,
                        Dracview,
                        Freyhedge,
                        Prylea,
                        Shadowwinter,
                        Aeledge,
                        Butterflower,
                        Southlea,
                        Marblemeadow,
                        Marblemill,
                        Westhill,
                        Deepmist,
                        Stonevale,
                        Watermeadow,
                        Summerhollow,
                        Highlake,
                        Northlyn,
                        Fallwall,
                        Whitemeadow,
                        Fairsummer,
                        Valbush,
                        Morbank,
                        Wheatmeadow,
                        Faircoast,
                        Silvermerrow,
                        Butterbank,
                        Courtmoor,
                        Wheathedge,
                        Crystalwall,
                        Westhall,
                        Butterhollow,
                        Starryhurst,
                        Starrycrystal,
                        Fogtown,
                        Goldshadow,
                        Mistford,
                        Merribourne,
                        Dracfort,
                        Meadowdell,
                        Beldale,
                        Mallowham,
                        Moorwynne,
                        Newham,
                        Byhollow,
                        Bellyn,
                        Foxbush,
                        Whitehaven,
                        Sealand,
                        Dorwynne,
                        Lochcastle,
                        Wheatholt,
                        Newwynne,
                        Clearlake,
                        Fallgold,
                        Pinehedge,
                        Morlake,
                        Clearsummer,
                        Coldriver,
                        Springlight,
                        Magefield,
                        Normount,
                        Beachmoor,
                        Winterhedge,
                        Silverbourne,
                        Butternesse,
                        Havencoast,
                        Valbridge,
                        Osthedge,
                        Deerbeach,
                        Morland,
                        Brightview,
                        Highdale,
                        Valnesse,
                        Landwick,
                        Eriwynne,
            }

                    public enum GroundTile : byte {
                        dirt,
                        stone,
                        pavement,
                        grass,
                        mud
                    }

                    public enum StructureTile : byte
                    {
                        nothing,
                        house, // Civilian type of structure
                        fortification, // Military type of structure
                        brush, //To let trees & bushes be placed
                        fertile, //For farming - Put on dirt

                    }

                    public enum StructureTileAttribute : byte {
                        nothing,
                        window, // Goes on manmade structure
                        wall, // Goes on manmade structure
                        door, // Goes on manmade structure
                        tree, // Goes on Brush
                        bush, // Goes on Brush
                        crops, // Goes on fertile type dirt
                    }

                    //Maybe in the future add an ability to colour/put decorations on scenery. 
                    public enum StructureTileAccent : byte {
                        nothing,
                        red,
                        green,
                        blue
                    }

            #endregion

            public enum Faction {
                NoFaction,
                Ravens,
                Falcons,
                BloodMongers,
                Hyennas,
                Scorpions,
                CultOfVengeance,
                AngelsOfDeath

            }

        #endregion

        #region modifiers
            public enum HelpsSeeEnemy : byte {
                enemyMoving, enemyInMilitaryBase
            }
            public enum HarderToSeeEnemy : byte {
                enemyIsWearingCamoflage = 1, enemyIsInScenery = 1, youAreSupressed = 1, enemyIsSneaking = 1
            }
            public enum UniversalMinusOne : byte { //Affects all rolls but saves
                nightTime,
            }
    #endregion
    #endregion

    #region struct

    #region Individual
    public struct Occupation {
        Jobs currentJob;
        JobLevel jobSkill;
        JobSpecialization specialization;

        void InitializeJob() {
            currentJob = Jobs.Unemployed;
            jobSkill = JobLevel.Unemployed;
            specialization = JobSpecialization.Null;
        }

        void NewJob (Jobs newJob) {
            currentJob = newJob;
        }

        void Promotion() {

        }

        void NewSpecialization(JobSpecialization newSpecialization) {
            specialization = newSpecialization;
        }

    }

    public struct BodyPart {
            private FleshCondition flesh;
            private BoneCondition bone;

            public void InitializeBodyPart () {
                flesh = FleshCondition.pristine;
                bone = BoneCondition.pristine;
            }

            #region Get Set
                #region get
                public FleshCondition GetFleshCondition() {
                    return flesh;
                }
                public BoneCondition GetBoneCondition() {
                    return bone;
                }
                #endregion

                #region set
                public void SetFleshCondition(FleshCondition newCondition) {
                    flesh = newCondition;
                }
                public void SetBoneCondition(BoneCondition newCondition)
                {
                    bone = newCondition;
                }
                #endregion
            #endregion
        }
    #endregion

    public struct Gun { //Access gun type through byte assignment. IE character has "byte weapon = Guns.assaultRifle" When shooting, access main class and ask for values of Guns.assaultRifle
        private string name;
        private byte rateOfFire; //if ROF is > 1, supress enemy is a fire method one can do. Do equation based on ROF. 
        private byte range;
        private bool shortRange;
        private bool bulky;
        public void InitializeGun(Guns gun) {
            name = gun.ToString();
            switch (gun) {
                case Guns.assaultRifle:
                    rateOfFire = 2;
                    range = 2;
                    shortRange = true;
                    bulky = false;
                    break;
                case Guns.sniperRifle:
                    rateOfFire = 1;
                    range = 4;
                    shortRange = false;
                    bulky = true;
                    break;
                case Guns.machineGun:
                    rateOfFire = 4;
                    range = 2;
                    shortRange = true;
                    bulky = true;
                    break;
            }
        }
    }

    public struct LocationTile {
        private GroundTile ground;
        private StructureTile structure;
        private StructureTileAttribute structureAttribute;
        private short individualInTile; //Index from an array. must have error checking & update the variable as needed. 

        public void InitializeLocationTile(GroundTile groundType, StructureTile structureType, StructureTileAttribute structureTypeAttribute) {
            ground = groundType;
            structure = structureType;
            structureAttribute = structureTypeAttribute;
            individualInTile = -1;
        }

        #region Get

            public GroundTile GetGround () {
                return ground;
            }

            public StructureTile GetStructure () {
                return structure;
            }

            public StructureTileAttribute GetStructureAttribute () {
                return structureAttribute;
            }

            public short GetIndividualInTile() {
                return individualInTile;
            }

        #endregion

        #region Set

            public void SetGround (GroundTile newGround) {
                ground = newGround;
            }

            public void SetStructure (StructureTile newStructure) {
                structure = newStructure;
            }

            public void SetStructureAttribute (StructureTileAttribute newAttribute) {
                structureAttribute = newAttribute;
            }

            public void SetIndividualInTile (short newIndividual) {
                individualInTile = newIndividual;
            }

        #endregion
    }
    #region Memory Classes

        public class MemoryBase {
            Size size;
            Speed speed;
            Colour colour;
            Karma karma;

            public MemoryBase() {
                size = Size.average;
                speed = Speed.average;
                colour = Colour.muted;
                karma = Karma.aquainted;
            }

        }

        public class MemoryPerson : MemoryBase {
            Individual person;

            public MemoryPerson(Individual newPerson) {
                person = newPerson;
            }

        }

        public class MemoryArea : MemoryBase
        {
            AreaBehaviour area;

            public MemoryArea(AreaBehaviour newArea)
            {
                area = newArea;
            }

        }

        public class MemoryFaction : MemoryBase {
            Faction faction;

            public MemoryFaction(Faction newFaction) {
                faction = newFaction;
            }

        }

    #endregion


#endregion


    static class CustomClasses
    {
        
        static public void InitializeUniversalStructs() {
            try
            {
                Gun[] guns = new Gun[3];
                foreach (Guns gunTypes in Enum.GetValues(typeof(Guns))) {
                    byte converter = (byte)gunTypes;
                    guns[converter].InitializeGun(gunTypes);
                }
                

            }
            catch {
                Console.WriteLine("Universal data could not be initialized.");
                Console.ReadLine();
            }
        }

        static public void DiceRolls() {

        }

    }
}
