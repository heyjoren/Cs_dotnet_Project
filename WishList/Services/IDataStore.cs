using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Model;

namespace WishList.Services
{
    internal interface IDataStore
    {
        Task<List<Item>> GetAllItems();
    }
}
