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
    public class Inventory
    {
        private List<Item> _items = new List<Item>();
        private double _totalWeight;

        public double TotalWeight => _totalWeight;

        public Item AddItem ( Item item )
        {
            var addItem = new Item {
                Name = item.Name,
                Value = item.Value,
                Weight = item.Weight,
            };
            _items.Add(addItem);

            _totalWeight += addItem.Weight;

            return item;
        }

        public IEnumerable<Item> GetAllItems ()
        {
            foreach (var v in _items)
            {
                yield return new Item() {
                    Name = v.Name,
                    Value = v.Value,
                    Weight = v.Weight
                };
            }
        }
    }
}
