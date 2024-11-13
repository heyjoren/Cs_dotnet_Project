using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Model;

namespace WishList.Local_moc_data
{
    public static class MockDataStore 
    {
        public static List<Item> ItemsList { get; } = new List<Item>();

        public static ObservableCollection<Item> ObservableItemsList { set; get; } = new ObservableCollection<Item>();
        //public static List<string> ItemsList { get; } = new List<string>();
    }    
}
