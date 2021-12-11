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
    /// <summary>Represents a world.</summary>
    public class World
    {
        private List<Area> _areas = new List<Area>();
        private Area _start;

        /// <summary>Gets or sets the starting area of the world.</summary>
        public Area StartingArea
        {
            get => _start;
            set => _start = FindArea(value.Id) ?? _start;
        }

        /// <summary>Returns all areas in the world.</summary>
        public IEnumerable<Area> GetAllAreas ()
        {
            foreach (var v in _areas)
            {
                yield return new Area() {
                    Name = v.Name,
                    Description = v.Description,
                    Id = v.Id,
                    AccessibleAreas = v.AccessibleAreas,
                };
            }
        }

        /// <summary>Finds an area by its unique identifier.</summary>
        public Area FindArea( int id )
        {
            return (from area in _areas
                    where area.Id == id
                    select area).FirstOrDefault();
        }

        /// <summary>Adds an area to the world.</summary>
        public Area AddArea( Area area )
        {
            _areas.Add(area);
            return area;
        }
    }
}
