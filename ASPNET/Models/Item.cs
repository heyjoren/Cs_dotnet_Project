using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Naam { set; get; }
        public float Bedrag { set; get; }
        public string? Beschrijving { set; get; }
        public string Bedrijf { set; get; }
    }
}