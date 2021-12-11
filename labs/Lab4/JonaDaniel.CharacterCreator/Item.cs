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
    /// <summary>Represents an item</summary>
    public class Item
    {
        private string _name;

        /// <summary>Get or set name of item</summary>
        public string Name
        {
            get => _name ?? "";
            set => _name = value?.Trim();
        }

        /// <summary>Get or set value of item in coins</summary>
        public int Value { get; set; } = 0;

        /// <summary>Get or set weight of item in pounds</summary>
        public double Weight { get; set; } = 0;

        public override string ToString () => $"{Name} : ({Weight} - Pounds) [{Value} - Coins)";
    }
}
