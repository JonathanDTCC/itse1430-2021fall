/*
 * Jonathan Daniel
 * ITSE 1430 Fall 2021
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonaDaniel.AdventureGame
{
    /// <summary>Represents an area</summary>
    public class Area
    {
        private string _name;
        private string _description;
        private List<int> _accessibleAreas;
        private Item _item;

        /// <summary>Gets or sets the name.</summary>
        /// <value>Never returns null.</value>
        public string Name
        {
            get => _name ?? "";
            set => _name = value?.Trim();
        }

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get => (_description  ?? "") + ItemText();
            set => _description = value?.Trim();
        }

        private string ItemText () => (Item == null) ? "" : "   !An item is available!";

        /// <summary>Gets or sets the unique identifier.</summary>
        public int Id { get; set; }

        public Item Item
        {
            get => _item;
            set => _item = value;
        }

        /// <summary>Gets or sets the areas accesible from this area.</summary>
        public List<int> AccessibleAreas 
        {
            get => (_accessibleAreas != null) ? CopyAreas(_accessibleAreas) : new List<int> { 0, 0, 0, 0 };
            set => _accessibleAreas = (value != null) ? CopyAreas(value) : null;
        }

        /// <summary>Returns a copy of the accessible areas.</summary>
        private List<int> CopyAreas (List<int> toCopy)
        {
            var copy = new List<int>();
            foreach (var v in toCopy)
                copy.Add(v);
            return copy;
        }
    }
}
