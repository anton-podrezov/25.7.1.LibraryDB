using _25._7._1.LibraryDB.Repositories;

namespace _25._7._1.LibraryDB
{
    public class Program
    {
        static void ShowList<T>(List<T> info) 
        {
            foreach (var item in info)
            {
                Console.WriteLine(item);
            }           
        }
        public enum Commands
        {
            stop,
            choose_user,
            choose_all_users,
            add_user,
            remove_user,
            update_user,
            count_of_user_books,
            check_if_user_has_book,
            choose_book,
            choose_all_books,
            add_book,
            remove_book,
            update_book,
            get_genre,
            get_date_range,
            get_count_of_author_books,
            get_count_of_genre_books,
            check_book,
            get_last_book,
            get_sorted_books_name,
            get_sorted_books_year
        }

        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Alice", Email = "mail@mai.ru" };
                var user2 = new User { Name = "Bob", Email = "mail@mai.ru" };
                var user3 = new User { Name = "Bruce", Email = "mail@mai.ru" };
                db.Users.AddRange(user1, user2, user3);
                db.SaveChanges();

                var book1 = new Book { Name = "Война и мир", PublishingYear = "1967", Author = "Толстой", Genre = "Роман-эпопея" };
                var book3 = new Book { Name = "Отцы и дети", PublishingYear = "1986", Author = "Тургенев", Genre = "Роман" };
                var book2 = new Book { Name = "Преступление и наказание", PublishingYear = "1991", Author = "Достоевский", Genre = "Роман" };
                var book4 = new Book { Name = "Севастопольские рассказы", PublishingYear = "2000", Author = "Толстой", Genre = "Рассказ" };

                user1.Books.AddRange(new List<Book> { book1, book4 });
                book2.UserId = user2.Id;
                book3.User = user3;

                db.Books.AddRange(book1, book2, book3);
                db.SaveChanges();
            }

            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(Commands.stop + ": прекращение работы");
            Console.WriteLine(Commands.choose_user + ": выбрать пользователя");
            Console.WriteLine(Commands.choose_all_users + ": выбрать всех пользователей");
            Console.WriteLine(Commands.add_user + ": добавить пользователя");
            Console.WriteLine(Commands.remove_user + ": удалить пользователя");
            Console.WriteLine(Commands.update_user + ": обновить данные пользователя");
            Console.WriteLine(Commands.count_of_user_books + ": показать количество книг на руках у пользователя");
            Console.WriteLine(Commands.check_if_user_has_book + ": проверить, находится ли книга у пользователя");
            Console.WriteLine(Commands.choose_book + ": выбрать книгу");
            Console.WriteLine(Commands.choose_all_books + ": выбрать все книги");
            Console.WriteLine(Commands.add_book + ": добавить книгу");
            Console.WriteLine(Commands.remove_book + ": удалить книгу");
            Console.WriteLine(Commands.update_book + ": обновить данные о книге");
            Console.WriteLine(Commands.get_genre + ": показать все книги определенного жанра");
            Console.WriteLine(Commands.get_date_range + ": показать книги, изданные в определенный период времени");
            Console.WriteLine(Commands.get_count_of_author_books + ": показать количество книг определенного автора");
            Console.WriteLine(Commands.get_count_of_genre_books + ": показать количество книг определенного жанра");
            Console.WriteLine(Commands.check_book + ": проверить, есть ли книга в библиотеке");
            Console.WriteLine(Commands.get_last_book + ": получить последнюю изданную книгу");
            Console.WriteLine(Commands.get_sorted_books_name + ": выбрать все книги,отсортированные по названию");
            Console.WriteLine(Commands.get_sorted_books_year + ": выбрать все книги,отсортированные по году издания");

            string command;
            do
            {
                Console.WriteLine("Ведите команду");
                command = Console.ReadLine();
                Console.WriteLine();
                switch (command)
                {
                    case nameof(Commands.stop):
                        break;
                    case nameof(Commands.choose_user):
                        Console.WriteLine(DbManager.UserRep.ChooseById());
                        break;
                    case nameof(Commands.choose_all_users):
                        ShowList(DbManager.UserRep.ChooseAll());
                        break;
                    case nameof(Commands.add_user):
                        DbManager.UserRep.AddUser();
                        break;
                    case nameof(Commands.remove_user):
                        DbManager.UserRep.RemoveUser();
                        break;
                    case nameof(Commands.update_user):
                        DbManager.UserRep.UpdateUsername();
                        break;
                    case nameof(Commands.count_of_user_books):
                        Console.WriteLine(DbManager.UserRep.GetCountOfUserBooks());
                        break;
                    case nameof(Commands.check_if_user_has_book):
                        Console.WriteLine(DbManager.UserRep.CheckIfUserHasBook());
                        break;
                    case nameof(Commands.choose_book):
                        Console.WriteLine(DbManager.BookRep.ChooseById());
                        break;
                    case nameof(Commands.choose_all_books):
                        ShowList(DbManager.BookRep.ChooseAll());
                        break;
                    case nameof(Commands.add_book):
                        DbManager.BookRep.AddBook();
                        break;
                    case nameof(Commands.remove_book):
                        DbManager.BookRep.RemoveBook();
                        break;
                    case nameof(Commands.update_book):
                        DbManager.BookRep.UpdateYear();
                        break;
                    case nameof(Commands.get_genre):
                        ShowList(DbManager.BookRep.GetGenre());
                        break;
                    case nameof(Commands.get_date_range):
                        ShowList(DbManager.BookRep.GetDateRange());
                        break;
                    case nameof(Commands.get_count_of_author_books):
                        Console.WriteLine(DbManager.BookRep.GetCountOfAuthorBooks());
                        break;
                    case nameof(Commands.get_count_of_genre_books):
                        Console.WriteLine(DbManager.BookRep.GetCountOfGenreBooks());
                        break;
                    case nameof(Commands.check_book):
                        Console.WriteLine(DbManager.BookRep.CheckBookNameOrAuthor());
                        break;
                    case nameof(Commands.get_last_book):
                        Console.WriteLine(DbManager.BookRep.GetLastBook());
                        break;
                    case nameof(Commands.get_sorted_books_name):
                        ShowList(DbManager.BookRep.GetSortedBooksByName());
                        break;
                    case nameof(Commands.get_sorted_books_year):
                        ShowList(DbManager.BookRep.GetSortedBooksByYear());
                        break;
                    default:
                        Console.WriteLine("Неверная команда");
                        break;
                }
            }
            while (command != nameof(Commands.stop));
            using (var db = new AppContext())
            {
                db.Database.EnsureDeleted();
            } 
        }
    }
}
