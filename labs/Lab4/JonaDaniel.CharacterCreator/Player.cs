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
    /// <summary>Represents a Player.</summary>
    public class Player
    {
        private Character _character;
        private Area _currentPosition;

        /// <summary>Gets or sets the players current character.</summary>
        public Character CurrentCharacter
        {
            get => _character ?? new Character();
            set => _character = value ?? new Character();
        }

        /// <summary>Gets or sets the players current position.</summary>
        public Area CurrentPosition
        {
            get => _currentPosition ?? GameWorld.StartArea;
            set => _currentPosition = value;
        }
    }
}
