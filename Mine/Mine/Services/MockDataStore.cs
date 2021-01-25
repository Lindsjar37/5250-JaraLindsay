using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Shrubbery", Description="We require....A SHRUBBERY.", Value=3 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Herring", Description="Used to cut down the largest tree in the forest.", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Holy Hand Grenade", Description="Thou shalt count to 3 then lob thy grenade at thy fo.", Value=8 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Coconut", Description="Coconuts are tropical!", Value=1 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Rabbit", Description="That is no ordinary Rabbit...", Value=10 }
            };
        }

        public async Task<bool> AddItemAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}