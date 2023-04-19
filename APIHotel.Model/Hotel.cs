using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHotel.Model
{
    public class Hotel
    {
        public int hotelid { get; set; }
        public string? hotelname { get; set; }
        public int categoria { get; set; }
        public decimal precio { get; set; }
        public string? fotos { get; set; }
        //public List<string>? fotos { get; set; }
        public int calificacion { get; set; }
        public string? comentario { get; set; }
    }
}
