using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaliczenie
{

    class Person
    {
        public String Name { get; set; }
        public String SurName { get; set; }

        public int LibraryId { get; set; }

        public List<Book> Books = new List<Book>();
        public List<Fine> Fines = new List<Fine>();

        public Person() { }
        public Person(String name,String surname, int id) {
            Name = name;
            SurName = surname;
            LibraryId = id;
        }

    }
}
