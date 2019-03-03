var view = new Vue({
    el: '#main',
    data: {
        phonebook: { entry: [] },
        selectedContact: { id: 0, name: '', entry: [] },
        newContact: { id: 0, name: '', entry: [], error: '' },
        newEntry: { id: 0, name: '', phoneNumber: '', phoneBookId: 0, error: '' },
        searchName: ''
    },
    computed: {
        filteredPhoneBook: function () {
            if (this.searchName.length === 0) {
                return this.phonebook.entry;
            }

            var search = this.searchName.toUpperCase();
            return this.phonebook.entry.filter((entry) =>
                entry.contacts.some((contact) => contact.name.toUpperCase().includes(search)))
                .map(entry => {
                        return Object.assign({}, entry, {
                            contacts: entry.contacts.filter(contact => contact.name.toUpperCase().includes(search))
                    });

                }); 
            }
    },
    methods: {
        getPhoneBook: function () {
            this.serverCall('GET', "/api/phonebook", null, view.$data.phonebook, this.resetNewEntry)
        },
        getContact: function (event, item) {
            var selectedContact = item;
            selectedContact.entry.sort(function (a, b) {
                var A = a.name.toUpperCase();
                var B = b.name.toUpperCase();
                return (A < B) ? -1 : (A > B) ? 1 : 0;
            });
            view.$data.selectedContact = selectedContact;
        },
        addNewContact: function () {
            var contact = view.$data.newContact;
            var entry = view.$data.newEntry;
            contact.entry.push(entry);
            this.serverCall('POST', "/api/phonebook", contact, view.$data.phonebook, this.resetNewContact);

        },
        addNewEntry: function () {
            var contact = view.$data.selectedContact;
            var entry = view.$data.newEntry;
            entry.phoneBookId = contact.id;
            this.serverCall('PUT', "/api/phonebook", entry, contact);
        },
        resetNewContact: function () {
            $('#entryModal').modal('hide');
            view.$data.newContact = { id: 0, name: '', entry: [], error: '' };
            this.resetNewEntry();
        },
        resetNewEntry: function () {
            view.$data.newEntry  = { id: 0, name: '', phoneNumber: '', phoneBookId: 0, error: '' };
        },
        serverCall: function (method, destUrl, obj, dataItem, callback) {
            var jsonData = obj ? JSON.stringify(obj) : '';

            $.ajax({
                method: method,
                url: destUrl,
                dataType: "json",
                contentType: "application/json",
                data: jsonData,
                success: function (resp) {
                    dataItem.entry = resp.slice();
                },
                error: function () {
                    console.log("failed");
                },
                complete: function () {
                    callback();
                    console.log("complete");
                }
            });
        }
    }
});

$(document).ready(function () {
    view.getPhoneBook();
});