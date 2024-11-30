using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET.Contexts;
using ASPNET.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ASPNET.Repositories
{
    public class MySQLRepo : IRepo
    {
        private readonly ItemContext context;

        public MySQLRepo(ItemContext _context)
        {
            context = _context;
        }

        public IEnumerable<Item>GetAllItems()
        {
            return context.Items;
        }

        public Item GetItemById(int id)
        {
            return context.Items.FirstOrDefault<Item>(item => item.Id == id);
        }

        public void AddItem(Item i)
        {
            context.Items.Add(i);
        }

        public void SaveChanges ()
        {
            context.SaveChanges();
        }

        public void UpdateItem(Item i)
        { 

        }

        public void DeleteItem(Item i)
        {
            context.Items.Remove(i);
        }
        
    }
}