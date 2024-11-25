using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET.Models;

namespace ASPNET.Repositories
{
    public class Mock
    {
        List<Item> itemsList = new List<Item>();

        public Mock()
        {
            itemsList.Add(new Item{Id= 1, Naam = "test1", Bedrag =1, Bedrijf = "test1"});
            itemsList.Add(new Item{Id= 2, Naam = "test2", Bedrag =2, Bedrijf = "test2"});
            itemsList.Add(new Item{Id= 3, Naam = "test3", Bedrag =3, Bedrijf = "test3"});
        }

        public IEnumerable<Item> GetAllItems()
        {
            return itemsList;
        }

        public Item GetItemById(int id)
        {
            Item _item = itemsList.FirstOrDefault<Item>(test => test.Id == id);
            return _item;
        }
        
    }
}