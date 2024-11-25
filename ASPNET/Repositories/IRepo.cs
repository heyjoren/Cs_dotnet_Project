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
    }
}