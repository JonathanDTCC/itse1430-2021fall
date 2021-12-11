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
            AccessibleAreas = { 5, 7, 9 }
        };
        public GameWorld ()
        {
            _areas.Add(new Area {
                Name = "Kitchen",
                Description = "A kitchen for making food",
                Id = 1,
                AccessibleAreas = { 2, 4 }
            });

            _areas.Add(new Area {
                Name = "Stairs",
                Description = "Stairs leading to a higher floor",
                Id = 2,
                AccessibleAreas = { 1, 3, 5 }
            });

            _areas.Add(new Area {
                Name = "Closet",
                Description = "A closet with clothes",
                Id = 3,
                AccessibleAreas = { 2, 6 }
            });

            _areas.Add(new Area {
                Name = "Dining Room",
                Description = "Dining room for eating food",
                Id = 4,
                AccessibleAreas = { 1, 5, 7 }
            });

            _areas.Add(new Area {
                Name = "Hallway",
                Description = "Hallway leading to other rooms",
                Id = 5,
                AccessibleAreas = { 2, 4, 6, 8 }
            });

            _areas.Add(new Area {
                Name = "Bathroom",
                Description = "Bathroom",
                Id = 6,
                AccessibleAreas = { 3, 5, 9 }
            });

            _areas.Add(new Area {
                Name = "Hallway",
                Description = "Hallway with window to see outside",
                Id = 7,
                AccessibleAreas = { 4, 8 }
            });

            _areas.Add(new Area {
                Name = "Entrance",
                Description = "Entrance to the house",
                Id = 8,
                AccessibleAreas = { 5, 7, 9 }
            });

            _areas.Add(new Area {
                Name = "Living Room",
                Description = "Living room for sitting",
                Id = 9,
                AccessibleAreas = { 6, 8 }
            });
        }
    }
}
