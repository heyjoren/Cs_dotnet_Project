using System;
using System.Diagnostics;
using Backend;
using Backend.Bedrag;
using Backend.Item;


namespace Backend
{
    public class WishList
    {
        public List<Bedrag.Bedrag> Bedragen { get; set; } = new();
        public List<Item.Item> items { get; set; } = new();

        public WishList()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.AutoFlush = true;
        }

        public void readAllItems()
        {
             Console.WriteLine("Show items:");
            foreach(var item in items.Select((value, index) => new {index, value}))
            {
                Console.WriteLine(item.index + ". " + item.value);
            }
        }

        public void DelItems(int selectedIndex)
        {
            items.RemoveAt(selectedIndex);
        }

        public void koopItem(int selectedIndex)
        {
            Item.Item item = items.ElementAt(selectedIndex);

            DelItems(selectedIndex);

            Bedragen.Add(new Bedrag.Bedrag(item.bedrag, DateTime.Now, Teken.min));
            
        }
    }
}
