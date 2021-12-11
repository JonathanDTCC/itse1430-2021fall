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
        private List<int> _accessibleAreas = new();

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
            get => _description ?? "";
            set => _description = value?.Trim();
        }

        /// <summary>Gets or sets the unique identifier.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the areas accesible from this area.</summary>
        public List<int> AccessibleAreas 
        {
            get => CopyAreas();
            set => _accessibleAreas = value;
        }

        /// <summary>Returns a copy of the accessible areas.</summary>
        private List<int> CopyAreas ()
        {
            var copy = new List<int>();
            foreach (var v in _accessibleAreas)
                copy.Add(v);
            return copy;
        }
    }
}
