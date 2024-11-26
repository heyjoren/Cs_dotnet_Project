using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET.Models;

namespace ASPNET.Repositories
{
    public interface IRepo
    {
        IEnumerable<Item> GetAllItems();

        Item GetItemById(int id);

        void AddItem(Item i);

        void SaveChanges();

        void UpdateItem(Item i);

        void DeleteItem(Item i);
    }
}