using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apartner.Models;

namespace Apartner
{
    public class MockDataStore : IDataStore<Apartment>
    {
        List<Apartment> apartments;

        public MockDataStore()
        {
            apartments = new List<Apartment>();
            var mockItems = new List<Apartment>
            {
                new Apartment { Address = "Rashi 13",  Price = 3500, RoomsNumber = 2, 
                    Properties = new List<string>{"Coffee Machine", "Cables", "Furnished"}, RoommatesNumber = 4, EntryDate = 1.8,
                    Images = new List<string>{"backgroundApart"}},
                new Apartment { Address = "Dizi 124",  Price = 3100, RoomsNumber = 3,
                    Properties = new List<string>{"Coffee Machine"}, RoommatesNumber = 2, EntryDate = 1.10,
                    Images = new List<string>{"backgroundApart"}},
            };

            foreach (var item in mockItems)
            {
                apartments.Add(item);
            }
        }

        //public async Task<bool> AddItemAsync(Item item)
        //{
        //    items.Add(item);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> UpdateItemAsync(Item item)
        //{
        //    var _item = apartments.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
        //    apartments.Remove(_item);
        //    apartments.Add(item);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> DeleteItemAsync(string id)
        //{
        //    var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
        //    items.Remove(_item);

        //    return await Task.FromResult(true);
        //}

        public async Task<Apartment> GetItemAsync(string id)
        {
            return await Task.FromResult(apartments.FirstOrDefault(s => s.Address == id));
        }

        public async Task<IEnumerable<Apartment>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(apartments);
        }

    }
}
