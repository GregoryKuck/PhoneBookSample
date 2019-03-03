using Newtonsoft.Json;
using PhonebookSample.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookSample.Models
{
    public class PhoneBookViewModel
    {
        [JsonProperty(PropertyName = "index")]
        public char Index { get; set; }
        [JsonProperty(PropertyName = "contacts")]
        public IEnumerable<PhoneBook> Contacts { get; set; }
    }
}
