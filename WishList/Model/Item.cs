using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WishList.Model
{
    public class Item: INotifyPropertyChanged
    {
        private static int currentId = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("naam")]
        public string Naam { set; get; }

        [JsonPropertyName("bedrag")]
        public float Bedrag { set; get; }

        [JsonPropertyName("beschrijving")]
        public string? Beschrijving { set; get; }

        [JsonPropertyName("bedrijf")]
        public string Bedrijf { set; get; }

        [JsonPropertyName("datumToegevoegd")]
        public DateTime DatumToegevoegd { set; get; }

        public Item()
        {
            Id = currentId;
            currentId++;
            Naam = "";
            Bedrag = 0;
            Beschrijving = "";
            Bedrijf = "";
            DatumToegevoegd = DateTime.Now;
        }

        public Item(string _Naam, float _Bedrag, string _Beschrijving, string _Bedrijf)
        {
            Id = currentId;
            currentId++;
            Naam = _Naam;
            Bedrag = _Bedrag;
            Beschrijving = _Beschrijving;
            Bedrijf = _Bedrijf;
            DatumToegevoegd = DateTime.Now;
        }

        public Item(string _Naam, float _Bedrag, string _Beschrijving, string _Bedrijf, DateTime _DatumToegevoegd)
        {
            Id = currentId;
            currentId++;
            Naam = _Naam;
            Bedrag = _Bedrag;
            Beschrijving = _Beschrijving;
            Bedrijf = _Bedrijf;
            DatumToegevoegd = _DatumToegevoegd;
        }
        public Item(string _Naam, float _Bedrag, string _Bedrijf, DateTime _DatumToegevoegd)
        {
            Id = currentId;
            currentId++;
            Naam = _Naam;
            Bedrag = _Bedrag;
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
