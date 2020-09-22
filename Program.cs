using System;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.Registration(Person.getTestInstance());
            Livre lTemp = Livre.GetTestInstance();
            lTemp.IsAvailableChanged += L_IsAvailableChanged;
            library.AddBook(lTemp);

            bool running = true;
            do
            {
                Console.WriteLine("1) Afficher les livres empruntés d'une personne \n" +
                    "2) Chercher un livre\n" +
                    "3) Gérer les emprunts et les retours");
                String step = Console.ReadLine();
                switch (step)
                {
                    case "1":
                        AfficherLivrePersonne(library);
                        break;
                    case "2":
                        ChercherUnLivre(library);
                        break;
                    case "3":
                        Console.WriteLine("Entrez l'ISBN du livre à retourner\\emprunter ");
                        String ISBNTemp = Console.ReadLine();
                        Livre l2 = library.GetBook(ISBNTemp);
                        if (l2 is null)
                            Console.WriteLine("Livre introuvable");
                        else
                            Console.WriteLine("Entrer l'id de la personne :");
                            String tempRes = Console.ReadLine();
                            int idPerson = Int32.Parse(tempRes);
                            Person resultPerson = library.GetPerson(idPerson);
                            if (resultPerson is null)
                                Console.WriteLine("Personne introuvable");
                            else
                            {
                                switch (l2.IsAvailable)
                                {
                                    case true: //emprunter
                                    BorrowBookState result = library.Borrow(idPerson, ISBNTemp);
                                    if (result != BorrowBookState.TransactionOK)
                                        Console.WriteLine(result);
                                    break;
                                    case false: //rendre
                                    BorrowBookState result2 = library.Return(idPerson, ISBNTemp);
                                    if (result2 != BorrowBookState.TransactionOK)
                                        Console.WriteLine(result2);
                                    break;
                                }
                                break;
                            }
                        break;
                    default:
                        Console.WriteLine("Erreur !");
                        break;
                }
                Console.WriteLine("Continuer le programme ? (Y/N)");
                String run = Console.ReadLine();
                if (run != "Y")
                    running = false;
            } while(running);

            static void AfficherLivrePersonne(Library library)
            {
                Console.WriteLine("Entrer l'id de la personne :");
                String id = Console.ReadLine();
                Person result = library.GetPerson(Int32.Parse(id));
                if (result is null)
                    Console.WriteLine("Personne introuvable");
                else
                    Console.WriteLine(result);
            }

            static void ChercherUnLivre(Library library)
            {
                Console.WriteLine("Entrer l'ISBN (optionel)");
                String ISBN = Console.ReadLine();
                Console.WriteLine("Entrer l'auteur (optionel)");
                String auteur = Console.ReadLine();
                Console.WriteLine("Entrer le titre (optionel)");
                String titre = Console.ReadLine();
                Livre l = library.SearchBook(ISBN, titre, auteur);
                if (l is null)
                    Console.WriteLine("Livre introuvable");
                else
                    Console.WriteLine(l);
            }
        }


        private static void L_IsAvailableChanged(Livre l)
        {
            if (l.IsAvailable)
            {
                Console.WriteLine(l.Title + " est maintenant disponible");
            }
            else
            {
                Console.WriteLine(l.Title + " n'est maintenant plus disponible");
            }
        }
    }
}
