using System;
using System.Collections.Generic;
using System.Linq;

namespace TP1
{
    class Library
    {
        public List<Person> SubscribedPersons { get;}
        public List<Livre> Books { get; }

        public Library()
        {
            this.SubscribedPersons = new List<Person>();
            this.Books = new List<Livre>();
        }

        public void AddBook(Livre b)
        {
            Books.Add(b);
        }

        public void Registration(Person p)
        {
            SubscribedPersons.Add(p);
        }

        public Livre GetBook(String ISBN)
        {
            return Books.FirstOrDefault(x => x.ISBN == ISBN);
        }
        public Person GetPerson(int id)
        {
            return SubscribedPersons.Where(x => x.Id == id).FirstOrDefault();
        }

        public Livre SearchBook(String ISBN ="", String title ="", String author ="")
        {
            return Books.FirstOrDefault( x => x.ISBN.Contains(ISBN) || x.Title.Contains(title) || x.Author.Contains(author));
        }

        public BorrowBookState Borrow(int idperson, String ISBN)
        {
            Livre l = GetBook(ISBN);
            if (l is null)
                return BorrowBookState.BookNotFound;
            if (!l.IsAvailable)
                return BorrowBookState.BookNotAvailable;
            Person p = GetPerson(idperson);
            if (p is null)
                return BorrowBookState.PersonNotFound;
            l.IsAvailable = false;
            p.addBook(l);
            return BorrowBookState.TransactionOK;
        }
        public BorrowBookState Return(int idperson, String ISBN)
        {
            Livre l = GetBook(ISBN);
            if (l is null)
                return BorrowBookState.BookNotFound;
            if (l.IsAvailable)
                return BorrowBookState.BookAlreadyAvailable;
            Person p = GetPerson(idperson);
            if (p is null)
                return BorrowBookState.PersonNotFound;
            l.IsAvailable = true;
            p.removeBook(l);
            return BorrowBookState.TransactionOK;
        }


    }
}
