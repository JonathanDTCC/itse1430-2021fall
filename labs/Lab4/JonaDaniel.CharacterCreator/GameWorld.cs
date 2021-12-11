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
    public class GameWorld : World
    {
        private List<Area> _areas = new List<Area>();

        public static Area StartArea = new Area {
            Name = "Entrance",
            Description = "Entrance to the house",
            Id = 8,
            AccessibleAreas = new List<int>() { 5, 9, 0, 7 }
        };

        /// <summary>Finds an area by its unique identifier.</summary>
        public new Area FindArea ( int id )
        {
            return (from area in _areas
                    where area.Id == id
                    select area).FirstOrDefault();
        }
        public GameWorld ()
        {
            _areas.Add(new Area {
                Name = "Kitchen",
                Description = "A kitchen for making food",
                Id = 1,
                AccessibleAreas = new List<int>() { 0, 2, 4, 0 },
                Item = new Item() { Name = "Banana", Weight = 0.3, Value = 4 }
            });

            _areas.Add(new Area {
                Name = "Stairs",
                Description = "Stairs leading to a higher floor",
                Id = 2,
                AccessibleAreas = new List<int>() { 0, 3, 5, 1 }
            });

            _areas.Add(new Area {
                Name = "Closet",
                Description = "A closet with clothes",
                Id = 3,
                AccessibleAreas = new List<int>() { 0, 0, 6, 2 }
            });

            _areas.Add(new Area {
                Name = "Dining Room",
                Description = "Dining room for eating food",
                Id = 4,
                AccessibleAreas = new List<int>() { 1, 5, 7, 0 }
            });

            _areas.Add(new Area {
                Name = "Hallway",
                Description = "Hallway leading to other rooms",
                Id = 5,
                AccessibleAreas = new List<int>() { 2, 6, 4, 8 },
                Item = new Item() { Name = "Shoes", Weight = 2.3, Value = 23 }
            });

            _areas.Add(new Area {
                Name = "Bathroom",
                Description = "Bathroom",
                Id = 6,
                AccessibleAreas = new List<int>() { 3, 0, 9, 5 }
            });

            _areas.Add(new Area {
                Name = "Hallway",
                Description = "Hallway with window to see outside",
                Id = 7,
                AccessibleAreas = new List<int>() { 4, 8, 0, 0 },
                Item = new Item() { Name = "Painting", Weight = 16.2, Value = 128 }
            });

            _areas.Add(new Area {
                Name = "Entrance",
                Description = "Entrance to the house",
                Id = 8,
                AccessibleAreas = new List<int>() { 5, 9, 0, 7 }
            });

            _areas.Add(new Area {
                Name = "Living Room",
                Description = "Living room for sitting",
                Id = 9,
                AccessibleAreas = new List<int>() { 6, 0, 0, 8 }
            });

            StartingArea = StartArea;
        }
    }
}
