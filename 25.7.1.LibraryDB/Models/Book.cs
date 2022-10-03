using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._7._1.LibraryDB
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishingYear { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public override string ToString()
        {
            return "Book: " + Name + " " + PublishingYear;
        }
    }
}
