/*
 * Jonathan Daniel
 * ITSE 1430 Fall 2021
 */
using System;

namespace JonaDaniel.CharacterCreator
{
    public class Character
    {
        public Character ()
        { }
        public Character (string name, string profession, string race) : this()
        {
            Name = name;
            Profession = profession;
            Race = race;
        }

        #region String Properties
        /// <summary>
        /// Gets or sets Character Name
        /// </summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }
        /// <summary>
        /// Gets or set Character Profession
        /// </summary>
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value?.Trim(); }
        }
        /// <summary>
        /// Gets or set Character Race
        /// </summary>
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value?.Trim(); }
        }
        /// <summary>
        /// Gets or set Character Biography
        /// </summary>
        public string Biography
        {
            get { return _biography ?? ""; }
            set { _biography = value?.Trim(); }
        }
        #endregion
        #region Attribute Properties
        /// <summary>
        /// Gets or set Strength Attribute
        /// </summary>
        public int Strength { get; set; }
        /// <summary>
        /// Gets or set Intelligence Attribute
        /// </summary>
        public int Intelligence { get; set; }
        /// <summary>
        /// Gets or set Agility Attribute
        /// </summary>
        public int Agility { get; set; }
        /// <summary>
        /// Gets or set Constitution Attribute
        /// </summary>
        public int Constitution { get; set; }
        /// <summary>
        /// Gets or set Charisma Attribute
        /// </summary>
        public int Charisma { get; set; }
        #endregion

        #region Fields
        private string _name;

        private string _profession;
        public static readonly string[] ValidProfessions = new string[] { "Fighter", "Priest", "Wizard", "Rouge", "Ranger" };

        private string _race;
        public static readonly string[] ValidRaces = new string[] { "Human", "Elf", "Dwarf", "Gnome", "Hobbit" };

        private string _biography;

        public const int MinAttribute = 1;
        public const int MaxAttribute = 100;
        //private int _strength;
        //private int _intelligence;
        //private int _agility;
        //private int _constitution;
        //private int _charisma;
        #endregion
        public override string ToString ()
        {
            return $"Name: {Name}, Profession {Profession}, Race {Race}, Attribute [{Strength},{Intelligence},{Agility},{Constitution},{Charisma}]";
        }

        #region Validation
        public string Validate ()
        {
            if (String.IsNullOrEmpty(Name))
                return "Character needs a name";

            #region commented
            //if (String.IsNullOrEmpty(Profession))
            //    return "Character needs a Profession";
            //foreach (var v in ValidProfessions)
            //{
            //    if (String.Equals(v, Profession))
            //        break;
            //    return $"{Profession} Isn't a valid profession for the character";
            //}


            //if (String.IsNullOrEmpty(Race))
            //    return "Character needs a Race";
            //foreach (var v in ValidRaces)
            //{
            //    if (String.Equals(v, Race))
            //        break;
            //    return $"{Race} Isn't a valid race for the character";
            //}
            #endregion

            string message;
            if (!ValidateEach(out message, Profession, ValidProfessions, "Profession"))
                return message;

            if (!ValidateEach(out message, Race, ValidRaces, "Race"))
                return message;

            if (Strength < MinAttribute || Strength > MaxAttribute)
                return "Strength must be an integral value between " + MinAttribute + " and " + MaxAttribute;
            if (Intelligence < MinAttribute || Intelligence > MaxAttribute)
                return "Intelligence must be an integral value between " + MinAttribute + " and " + MaxAttribute;
            if (Agility < MinAttribute || Agility > MaxAttribute)
                return "Agility must be an integral value between " + MinAttribute + " and " + MaxAttribute;
            if (Constitution < MinAttribute || Constitution > MaxAttribute)
                return "Constitution must be an integral value between " + MinAttribute + " and " + MaxAttribute;
            if (Charisma < MinAttribute || Charisma > MaxAttribute)
                return "Charisma must be an integral value between " + MinAttribute + " and " + MaxAttribute;

            return null;
        }

        private static bool ValidateEach( out string message, string valueToCheck, string[] acceptedValues, string type )
        {
            if (String.IsNullOrEmpty(valueToCheck))
            {
                message = $"Character needs a {type}";
                return false;
            }
            foreach (var v in acceptedValues)
            {
                if (String.Equals(v, valueToCheck))
                {
                    message = null;
                    return true;
                }
            }
            message = $"{valueToCheck} Isn't a valid {type} for the character";
            return false;
        }
        #endregion
    }
}
