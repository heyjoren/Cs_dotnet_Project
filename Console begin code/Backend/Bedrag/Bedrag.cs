using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Backend.Bedrag
{
    public enum Teken{
        toevoegen = 1,
        aftrekken = 2,   
        plus = 1,
        min = 2  
    }

    public class Bedrag
    {
        private static int currentId = 0;
        public int Id { get; private set; }
        public float bedrag {get; set;}
        public DateTime datumToegevoegd {get; set;}
        public Teken teken {set; get;}

        public Bedrag(float _bedrag, DateTime _datumToegevoegd, Teken _teken)
        {
            Id = currentId;
            currentId++;

            bedrag = _bedrag;
            datumToegevoegd = _datumToegevoegd;
            teken = _teken;
        }

        public Bedrag()
        {
            Id = currentId;
            currentId++;

            string _bedragInput, _datumToegevoegdInput, _tekenInput;

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

            do
            {
                Console.WriteLine("geef een teken in (toevoegen, plus of aftrekken, min): ");
                _tekenInput = Console.ReadLine();
                try
                {
                    teken = (Teken)Enum.Parse(typeof(Teken), _tekenInput, true);
                }
                catch
                {
                    _tekenInput = "";
                }
            }while(_tekenInput == "");
        }

        public override  String ToString(){
            // return JsonSerializer.Serialize(this);
            return $"Bedrag: {bedrag}, Datum: {datumToegevoegd:dd/MM/yyyy}, Teken: {teken}";
        }
    }
}