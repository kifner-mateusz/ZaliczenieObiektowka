using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaliczenie
{
    class Book
    {
        public String Title { get; set; }
        public int TotalPages { get; set; }
        public int Id { get; set; }
        public DateTime DataWydania { get; set; }


        public Book() { }


        public Book(string title, int total_pages, int id, int dzien,int miesiac,int rok) {
            Title = title;
            TotalPages = total_pages;
            Id = id;
            DataWydania = new DateTime(rok,miesiac,dzien,0,0,0);
        }

        public Book(string title,int total_pages, int id,DateTime data_wydania) {
            Title = title;
            TotalPages = total_pages;
            Id = id;
            DataWydania = data_wydania;
        }
    }
}
