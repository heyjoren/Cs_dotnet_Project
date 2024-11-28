using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET.dro
{
    public class itemWriteDto
    {
        public string Naam { set; get; }
        public float Bedrag { set; get; }
        public string Beschrijving { set; get; }
        public string Bedrijf { set; get; }
        public DateTime DatumToegevoegd { set; get; }
    }
}