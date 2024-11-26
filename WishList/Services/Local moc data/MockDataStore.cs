using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Model;
using System.Diagnostics;

namespace WishList.Local_moc_data
{
    public static class MockDataStore 
    {
        public static List<Item> ItemsList { get; } = new List<Item>();

        public static ObservableCollection<Item> ObservableItems { set; get; } = new ObservableCollection<Item>();
        //public static List<string> ItemsList { get; } = new List<string>();

        static MockDataStore()
        {
            //Test
            Item testItem = new Item();
            testItem.Naam = "test";
            testItem.Bedrag = 5;
            testItem.Bedrijf = "test";

            Debug.WriteLine(testItem);
            ObservableItems.Add(testItem);

            Item testItem2 = new Item();
            testItem2.Naam = "test2";
            testItem2.Bedrag = 10;
            testItem2.Bedrijf = "test2";
            testItem2.Beschrijving = "kort";

            Debug.WriteLine(testItem2);
            ObservableItems.Add(testItem2);


            Item testItem3 = new Item();
            testItem3.Naam = "test3";
            testItem3.Bedrag = 20;
            testItem3.Bedrijf = "test3";
            testItem3.Beschrijving = "een veel te lange beschrijving. of toch niet";

            Debug.WriteLine(testItem3);
            ObservableItems.Add(testItem3);


            Item testItem4 = new Item();
            testItem4.Naam = "test4";
            testItem4.Bedrag = 40;
            testItem4.Bedrijf = "test4";
            testItem4.Beschrijving = @"ChatGPT is een kunstmatige intelligentie (AI) ontwikkeld door OpenAI, gebaseerd op de GPT-architectuur (Generative Pre-trained Transformer). 
            Het is een geavanceerd taalmodel dat in staat is om mensachtige tekst te genereren, vragen te beantwoorden,
            en interacties te voeren die lijken op gesprekken tussen mensen. ChatGPT is getraind op enorme hoeveelheden tekstdata, 
            wat het in staat stelt om een breed scala aan onderwerpen te begrijpen en te bespreken, van eenvoudige vragen tot complexe, diepgaande gesprekken.

            Het model werkt door het analyseren van de input die het ontvangt, deze te verwerken op basis van context en patronen die het tijdens de training heeft geleerd, 
            en vervolgens een gepaste tekstuele output te genereren. Het model is niet perfect en kan soms onnauwkeurige of onlogische antwoorden geven, 
            vooral wanneer het wordt gevraagd om te speculeren over zaken die buiten zijn kennisgebied vallen. 
            Het is echter steeds beter geworden in het leveren van coherente en relevante informatie door verbeteringen in zijn onderliggende algoritmen en trainingsmethoden.";

            Debug.WriteLine(testItem4);
            ObservableItems.Add(testItem4);
            //TEST tot hier
        }

    }
}
