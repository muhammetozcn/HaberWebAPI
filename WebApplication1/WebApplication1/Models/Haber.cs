using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Haber
    {
        public int haberID;
        public string haberTuru { get; set; }
        private DateTime _yayinTarih;
        public DateTime yayinTarih
        {
            get
            {
                return _yayinTarih;
            }
            set
            {
                var zaman = value.ToString().Replace('T', ' ');
                _yayinTarih = Convert.ToDateTime(zaman);
            }
        }



        public string haberResim { get; set; }
        public string haberBaslik { get; set; }
        public string haberIcerik { get; set; }
        public int haberLike { get; set; }
        public int haberDislike { get; set; }
        public int haberView { get; set; }
    }
}