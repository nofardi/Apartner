using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apartner.Models;

namespace Apartner
{
    public class MockDataStore : IDataStore<string>
    {
        List<string> apartments;

        public MockDataStore()
        {
            apartments = new List<string>();
            var mockItems = new List<string>
            {
                @"{'Address': 'Rashi 13', 'Price': '3500', 'RoommatesNumber': '2', 'EntryDate': '1.8', 'Properties': ['Coffee Machine','Cables','Furnished'], 'Images': ['backgroundApart', 'apart2', 'apart3']}", 
                @"{'Address': 'Dizi 123', 'Price': '3100', 'RoommatesNumber': '3', 'EntryDate': '1.9', 'Properties': ['Cables'], 'Images': ['backgroundApart', 'apart3', 'apart4']}",  
                    
            };

            foreach (var item in mockItems)
            {
                apartments.Add(item);
            }
        }

        public async Task<bool> LikedApartmentAsync(string item)
        {

            return await Task.FromResult(true);
        }

        public async Task<bool> DislikedApartmentAsync(string item)
        {

            return await Task.FromResult(true);
        }
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

        public async Task<string> GetItemAsync(string id)
        {
            return await Task.FromResult(apartments.FirstOrDefault(s => s.Contains("Address")));
        }

        public async Task<IEnumerable<string>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(apartments);
        }

    }
}
