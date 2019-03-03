using System;
using System.Collections.Generic;

namespace PhonebookSample.Models.DataModels
{
    public partial class PhoneBook
    {
        public PhoneBook()
        {
            Entry = new HashSet<Entry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Entry> Entry { get; set; }
    }
}
