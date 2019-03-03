using PhonebookSample.Models.DataModels;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookSample.Services
{
    public class EFDataService : IDataService
    {
        private readonly PhonebookContext _db;

        public EFDataService(PhonebookContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PhoneBook>> GetAll()
        {
            return await _db.PhoneBook.Include(pb => pb.Entry).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<PhoneBook> AddPhonebook(PhoneBook phoneBook)
        {
            _db.PhoneBook.Add(phoneBook);
            await _db.SaveChangesAsync();
            return phoneBook;
        }

        public async Task<Entry> AddPhonebookEntry(Entry entry)
        {
            _db.Entry.Add(entry);
            await _db.SaveChangesAsync();
            return entry;
        }

        public async Task<IEnumerable<Entry>> GetEntriesById(int id)
        {
            return await _db.Entry.Where(e => e.PhoneBookId == id).OrderBy(e => e.Name).ToListAsync();
        }

        public async Task<IEnumerable<PhoneBook>> GetEntriesByName(string name)
        {
            return await _db.PhoneBook.Where(e => e.Name.Contains(name)).OrderBy(e => e.Name).ToListAsync();
        }
    }
}
