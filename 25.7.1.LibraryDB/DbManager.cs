using _25._7._1.LibraryDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._7._1.LibraryDB
{
    public static class DbManager
    {
        public static BookRepository BookRep;
        public static UserRepository UserRep;
        static DbManager() 
        {
            BookRep = new BookRepository();
            UserRep = new UserRepository();            
        }
    }
}
