using System;

namespace Backend.Item
{
    public class Item
    {
        private static int currentId = 0;
        public int Id { get; private set; }
        public string naam { set; get;}
        public float bedrag { set; get;}
        public string beschrijving { set; get;}
        public string bedrijf {set; get;}
        public DateTime datumToegevoegd {set; get;}

        public Item(string _naam, float _bedrag, string _beschrijving, string _bedrijf, DateTime _datumToegevoegd)
        {
            Id = currentId;
            currentId++;

            naam =_naam;
            bedrag = _bedrag;
            beschrijving =_beschrijving;
            bedrijf =_bedrijf;
            datumToegevoegd = _datumToegevoegd;
        }


        public Item()
        {
            Id = currentId;
            currentId++;

            string _bedragInput, _datumToegevoegdInput;

            do
            {
                Console.WriteLine("geef een naam in: ");
                naam = Console.ReadLine();                  
            }while(naam == "");

            do
            {
                Console.WriteLine("geef een bedrag in: ");
                _bedragInput = Console.ReadLine();
                try
                {
                    try
                    {
                        string normalizedInput = _bedragInput.Replace(".", ",");
                        bedrag = float.Parse(normalizedInput);
                    }
                    catch
                    {
                        string normalizedInput = _bedragInput.Replace(",", ".");
                        bedrag = float.Parse(normalizedInput);
                    }
                    
                }
                catch
                {
                    _bedragInput = "";
                }
            }while(_bedragInput == "");

            do
            {
                Console.WriteLine("geef een bedrijf in: ");
                bedrijf = Console.ReadLine();                  
            }while(bedrijf == "");

            do
            {
                Console.WriteLine("geef een beschrijving in: ");
                beschrijving = Console.ReadLine();                  
            }while(beschrijving == "");


            do
            {
                Console.WriteLine("geef een datum in: ");
                _datumToegevoegdInput = Console.ReadLine();
                try
                {
                    datumToegevoegd = DateTime.Parse(_datumToegevoegdInput);
                }
                catch
                {
                    _datumToegevoegdInput = "";
                }
            }while( _datumToegevoegdInput == "");

        }

        public override  String ToString(){
            // return JsonSerializer.Serialize(this);
            return $"Naam: {naam}, bedrag: €{bedrag}, bedrijf: {bedrijf}, beschrijving: {beschrijving}, Datum: {datumToegevoegd:dd/MM/yyyy}";
        }
        
    }

}