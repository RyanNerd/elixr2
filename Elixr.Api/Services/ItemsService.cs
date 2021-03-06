using System.Linq;
using Elixr2.Api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Elixr2.Api.Services
{
    public class ItemsService : ServiceBase
    {
        public ItemsService(ElixrDbContext dbContext)
        : base(dbContext)
        { }
        public async Task<List<Item>> GetItems(string name = null)
        {
            var itemsQuery = StartQuery<Item>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                itemsQuery = itemsQuery.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }

            itemsQuery = itemsQuery.OrderBy(c => c.Name);
            return await itemsQuery.ToListAsync();
        }
    }
}