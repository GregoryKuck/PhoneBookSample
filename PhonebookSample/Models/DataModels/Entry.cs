using System;
using System.Collections.Generic;

namespace PhonebookSample.Models.DataModels
{
    public partial class Entry
    {
        public int Id { get; set; }
        public int PhoneBookId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneBook PhoneBook { get; set; }
    }
}
