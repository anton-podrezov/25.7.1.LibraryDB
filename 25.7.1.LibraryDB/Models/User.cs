using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._7._1.LibraryDB
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public override string ToString()
        {
            return "User: " + Name + " " + Email;
        }
    }
}
