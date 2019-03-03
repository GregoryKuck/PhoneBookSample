using PhonebookSample.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookSample
{
    public class PhonebookDataSeeder
    {
        private readonly PhonebookContext _db;

        public PhonebookDataSeeder(PhonebookContext db)
        {
            _db = db;
        }

        //TODO: This is just to easily populate some data in SQLEXPRESS for dev puposes, I have not gone with code first
        public void SeedData()
        {
            var count = _db.PhoneBook.Where(x => x.Id == 1).Count();
            if (count == 0)
            {
                PhoneBook phoneBook1 = new PhoneBook()
                {
                    Name = "Gregory"
                };

                PhoneBook phoneBook2 = new PhoneBook()
                {
                    Name = "Fred"
                };

                PhoneBook phoneBook3 = new PhoneBook()
                {
                    Name = "George"
                };

                PhoneBook phoneBook4 = new PhoneBook()
                {
                    Name = "Gary"
                };

                PhoneBook phoneBook5 = new PhoneBook()
                {
                    Name = "Susan"
                };

                PhoneBook phoneBook6 = new PhoneBook()
                {
                    Name = "Adam"
                };

                PhoneBook phoneBook7 = new PhoneBook()
                {
                    Name = "Brian"
                };

                PhoneBook phoneBook8 = new PhoneBook()
                {
                    Name = "Bruce"
                };

                PhoneBook phoneBook9 = new PhoneBook()
                {
                    Name = "Catherine"
                };
                PhoneBook phoneBook10 = new PhoneBook()
                {
                    Name = "Charles"
                };

                List<PhoneBook> phoneBooks = new List<PhoneBook>()
                {
                   phoneBook1,
                   phoneBook2,
                   phoneBook3,
                   phoneBook4,
                   phoneBook5,
                   phoneBook6,
                   phoneBook7,
                   phoneBook8,
                   phoneBook9,
                   phoneBook10,
                };


                _db.PhoneBook.AddRange(phoneBooks);
                _db.SaveChanges();

                List<Entry> entries = new List<Entry>()
                {
                    new Entry()
                    {
                        Name = "Work",
                        PhoneBookId = phoneBook1.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry() {
                        Name = "Home",
                        PhoneBookId = phoneBook1.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry()
                    {
                        Name = "Mobile",
                        PhoneBookId = phoneBook1.Id,
                        PhoneNumber = "0111231235"
                    },

                    new Entry()
                    {
                        Name = "Home",
                        PhoneBookId = phoneBook2.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry() {
                        Name = "Work",
                        PhoneBookId = phoneBook2.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry()
                    {
                        Name = "Mobile",
                        PhoneBookId = phoneBook2.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry()
                    {
                        Name = "Home",
                        PhoneBookId = phoneBook3.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry() {
                        Name = "Work",
                        PhoneBookId = phoneBook3.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry()
                    {
                        Name = "Mobile",
                        PhoneBookId = phoneBook3.Id,
                        PhoneNumber = "0111231235"
                    },
                    new Entry()
                    {
                        Name = "Home",
                        PhoneBookId = phoneBook4.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry()
                    {
                        Name = "Home",
                        PhoneBookId = phoneBook5.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry()
                    {
                        Name = "Home",
                        PhoneBookId = phoneBook6.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry()
                    {
                        Name = "Home",
                        PhoneBookId = phoneBook7.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry()
                    {
                        Name = "Home",
                        PhoneBookId = phoneBook8.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry()
                    {
                        Name = "Home",
                        PhoneBookId = phoneBook9.Id,
                        PhoneNumber = "0111231234"
                    },
                    new Entry()
                    {
                        Name = "Home",
                        PhoneBookId = phoneBook10.Id,
                        PhoneNumber = "0111231234"
                    },

                };

                _db.Entry.AddRange(entries);
                _db.SaveChanges();
            }

        }
    }
}
