using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList.Model
{
    public class Item: INotifyPropertyChanged
    {
        private static int currentId = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; private set; }
        public string Naam { set; get; }
        public float Bedrag { set; get; }
        public string Beschrijving { set; get; }
        public string Bedrijf { set; get; }
        public DateTime DatumToegevoegd { set; get; }

        public Item()
        {
            currentId++;
            Id = currentId;
            Naam = "";
            Bedrag = 0;
            Beschrijving = "";
            Bedrijf = "";
            DatumToegevoegd = DateTime.Now;
        }

        public Item(string _Naam, float _Bedrag, string _Beschrijving, string _Bedrijf)
        {
            currentId++;
            Id = currentId;
            Naam = _Naam;
            Bedrag = _Bedrag;
            Beschrijving = _Beschrijving;
            Bedrijf = _Bedrijf;
            DatumToegevoegd = DateTime.Now;
        }

        public Item(string _Naam, float _Bedrag, string _Beschrijving, string _Bedrijf, DateTime _DatumToegevoegd)
        {
            currentId++;
            Id = currentId;
            Naam = _Naam;
            Bedrag = _Bedrag;
            Beschrijving = _Beschrijving;
            Bedrijf = _Bedrijf;
            DatumToegevoegd = _DatumToegevoegd;
        }

        public Item(int _Id, string _Naam, float _Bedrag, string _Beschrijving, string _Bedrijf, DateTime _DatumToegevoegd)
        {
            Id = _Id;
            currentId = _Id;
            Naam = _Naam;
            Bedrag = _Bedrag;
            Beschrijving = _Beschrijving;
            Bedrijf = _Bedrijf;
            DatumToegevoegd = _DatumToegevoegd;
        }

        public override String ToString()
        {
            // return JsonSerializer.Serialize(this);
            return $"Id: {Id}, Naam: {Naam}, Bedrag: €{Bedrag}, Bedrijf: {Bedrijf}, Beschrijving: {Beschrijving}, Datum: {DatumToegevoegd:dd/MM/yyyy}";
        }
    }
}
