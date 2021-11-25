/*
 * Jonathan Daniel
 * ITSE 1430 Fall 2021
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace JonaDaniel.CharacterCreator
{
    public class Character
    {
        public Character () => _attributes = LoadAttributes();

        #region String Properties
        /// <summary>
        /// Gets or sets Character Name
        /// </summary>
        public string Name
        {
            get => _name ?? "";
            set => _name = value?.Trim();
        }

        /// <summary>
        /// Gets or set Character Profession
        /// </summary>
        public string Profession
        {
            get => _profession ?? "";
            set => _profession = value?.Trim();
        }

        /// <summary>
        /// Gets or set Character Race
        /// </summary>
        public string Race
        {
            get => _race ?? "";
            set => _race = value?.Trim();
        }

        /// <summary>
        /// Gets or set Character Biography
        /// </summary>
        public string Biography
        {
            get => _biography ?? "";
            set => _biography = value?.Trim();
        }

        #endregion

        #region Attribute Properties
        internal class Attribute
        {
            public string Name;
            public int Value;

            //public static implicit operator int ( Attribute value ) => value.Value;
        }

        /// <summary>
        /// Gets or set Strength Attribute
        /// </summary>
        public int Strength
        {
            get => _strength.Value;
            set => _strength.Value = value;
        }

        /// <summary>
        /// Gets or set Intelligence Attribute
        /// </summary>
        public int Intelligence
        {
            get => _intelligence.Value;
            set => _intelligence.Value = value;
        }

        /// <summary>
        /// Gets or set Agility Attribute
        /// </summary>
        public int Agility
        {
            get => _agility.Value;
            set => _agility.Value = value;
        }

        /// <summary>
        /// Gets or set Constitution Attribute
        /// </summary>
        public int Constitution
        {
            get => _constitution.Value;
            set => _constitution.Value = value;
        }

        /// <summary>
        /// Gets or set Charisma Attribute
        /// </summary>
        public int Charisma
        {
            get => _charisma.Value;
            set => _charisma.Value = value;
        }

        private List<Attribute> LoadAttributes () =>
            new()
            {
                _strength,
                _intelligence,
                _agility,
                _constitution,
                _charisma
            };

        #endregion

        #region Fields
        private string _name;

        private string _profession;
        //public static readonly string[] ValidProfessions = new string[] { "Fighter", "Priest", "Wizard", "Rouge", "Ranger" };
        private static readonly ReadOnlyCollection<string> s_validProfessions = new(
            new string[] {
                "Fighter",
                "Priest",
                "Wizard",
                "Rouge",
                "Ranger"
            }
        );
        public static string[] ValidProfessions => s_validProfessions.ToArray();

        private string _race;
        private static readonly ReadOnlyCollection<string> s_validRaces = new(
            new string[] {
                "Human",
                "Elf",
                "Dwarf",
                "Gnome",
                "Hobbit"
            }
        );
        public static string[] ValidRaces => s_validRaces.ToArray();

        private string _biography;

        public const int MinAttribute = 1;
        public const int MaxAttribute = 100;

        private Attribute _strength = new() { Name = "Strength", };
        private Attribute _intelligence = new() { Name = "Intelligence", };
        private Attribute _agility = new() { Name = "Agility", };
        private Attribute _constitution = new() { Name = "Constitution", };
        private Attribute _charisma = new() { Name = "Charisma", };

        private List<Attribute> _attributes = new();
        #endregion
        public override string ToString () => $"Name: {Name}, Profession {Profession}, Race {Race}, Attributes [S:{Strength},I:{Intelligence},A:{Agility},Con:{Constitution},C:{Charisma}]";

        #region Validation
        public string Validate ()
        {
            if (String.IsNullOrEmpty(Name))
                return "Character needs a name";

            string message;
            if (!ValidateEach(out message, Profession, ValidProfessions, "Profession"))
                return message;

            if (!ValidateEach(out message, Race, ValidRaces, "Race"))
                return message;

            //if (!ValidateAttribute(out message, Strength, "Strength"))
            //    return message;
            //if (!ValidateAttribute(out message, Intelligence, "Intelligence"))
            //    return message;
            //if (!ValidateAttribute(out message, Agility, "Agility"))
            //    return message;
            //if (!ValidateAttribute(out message, Constitution, "Constitution"))
            //    return message;
            //if (!ValidateAttribute(out message, Charisma, "Charisma"))
            //    return message;

            if (!ValidateAttributes(out message))
                return message;

            //if (!ValidateAttribute(out message, in _strength))
            //    return message;
            //if (!ValidateAttribute(out message, in _intelligence))
            //    return message;
            //if (!ValidateAttribute(out message, in _agility))
            //    return message;
            //if (!ValidateAttribute(out message, in _constitution))
            //    return message;
            //if (!ValidateAttribute(out message, in _charisma))
            //    return message;

            return null;
        }

        private bool ValidateAttributes ( out string message )
        {
            var invalid = _attributes.FirstOrDefault(a => a.Value < MinAttribute || a.Value > MaxAttribute);
            if (invalid != null)
            {
                message =  $"{invalid.Name} must be an integral value between {MinAttribute} and {MaxAttribute}";
                return false;
            }

            message = null;
            return true;
        }
        private static bool ValidateAttribute ( out string message, in Attribute attribute )
        {
            if (attribute.Value >= MinAttribute && attribute.Value <= MaxAttribute)
            {
                message = null;
                return true;
            }

            message =  $"{attribute.Name} must be an integral value between {MinAttribute} and {MaxAttribute}";
            return false;
        }
        private static bool ValidateAttribute ( out string message, int attribute, string attributeName )
        {
            if (attribute >= MinAttribute && attribute <= MaxAttribute)
            {
                message = null;
                return true;
            }

            message =  $"{attributeName} must be an integral value between {MinAttribute} and {MaxAttribute}";
            return false;
        }

        private static bool ValidateEach ( out string message, string valueToCheck, string[] acceptedValues, string type )
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
