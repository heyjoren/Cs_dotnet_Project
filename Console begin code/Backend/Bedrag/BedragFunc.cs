using System;
using System.Diagnostics;
using Backend.Bedrag;

namespace Backend.Bedrag.function
{
    public static class BedragFunction
    {
        public static void readAllBedragen(List<Bedrag> bedragen)
        {
            Console.WriteLine("Show bedragen:");
            foreach(var bedrag in bedragen.Select((value, index) => new {index, value}))
            {
                Console.WriteLine(bedrag.index + ". " + bedrag.value);
            }
        }

        public static float getTotaalBedrag(List<Bedrag> bedragen)
        {
            float totaal = 0;
            foreach(var bedrag in bedragen)
            {
                if(bedrag.teken == Teken.plus)
                totaal += bedrag.bedrag;
                else if(bedrag.teken == Teken.aftrekken)
                totaal -= bedrag.bedrag;
            }
            totaal = (float)Math.Round(totaal, 2);
            return totaal;
        }

        public static List<Bedrag> DelBedrag(List<Bedrag> bedragen, int selectedIndex)
        {
            bedragen.RemoveAt(selectedIndex);
            return bedragen;
        }
    }
}