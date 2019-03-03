using System.Collections.Generic;
using System.Threading.Tasks;
using PhonebookSample.Models.DataModels;

namespace PhonebookSample.Services
{
    public interface IDataService
    {
        Task<PhoneBook> AddPhonebook(PhoneBook phoneBook);
        Task<Entry> AddPhonebookEntry(Entry entry);
        Task<IEnumerable<PhoneBook>> GetAll();
        Task<IEnumerable<Entry>> GetEntriesById(int id);
        Task<IEnumerable<PhoneBook>> GetEntriesByName(string name);
    }
}