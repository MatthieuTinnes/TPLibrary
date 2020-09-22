using System;
using System.Collections.Generic;
using System.Text;

namespace TP1
{
    delegate void LivreChange(Livre l);
    class Livre
    {
        public String ISBN { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public event LivreChange IsAvailableChanged;
        private bool isAvailable;
        

        public Livre(String ISBN, String Title, String Author, bool isAvailable = true)
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.Author = Author;
            this.IsAvailable = isAvailable;
        }
        public bool IsAvailable
        {
            get { return isAvailable; }
            set
            {
                if(isAvailable =!value)
                    IsAvailableChanged?.Invoke(this);
                isAvailable = value;
               
            }
        }

        public override string ToString()
        {
            return $"ISBN = {ISBN} title= {Title} author= {Author} isAvailable {IsAvailable}";
        }

        public static Livre GetTestInstance()
        {
            return new Livre("111", "Le Pacte des Yōkai", "Yuki Midorikawa");
        }

    }
}
