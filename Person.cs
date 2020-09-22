using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    class Person
    {
        public int Id {get; set;}
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public List<Livre> Books { get; set; }

        public Person(int id, String firstName, String lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Books = new List<Livre>();
        }

        public override string ToString()
        {
            String s = $"Id : {Id} firstName : {FirstName} lastName : {LastName}\n";
            s += "Liste des livres empruntés \n";
            foreach(Livre book in Books)
            {
                s += book.ToString() + "\n";
            }
            return s;
        }
        public static Person getTestInstance()
        {
            return new Person(1, "Corentin", "Grard");
        }

        public void addBook(Livre b)
        {
            Books.Add(b);
        }
        public void removeBook(Livre b)
        {
            Books.Remove(b);
        }
    }
}
