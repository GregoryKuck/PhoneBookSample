var view = new Vue({
    el: '#main',
    data: {
        library: { data: [] },
        phonebooks: { data: [] },
        newPhoneBook: { id: 0, name: '', error: '' },
        selectedPhoneBook: { id: 0, name: '' },
        entries: { data: [] },
        newContact: { id: 0, name: '', phoneNumber: '', phoneBookId: 0, error: '' },
        searchContact: { phoneBookId: 0, searchText: '' }
    },
    computed: {

    },
    methods: {
        search: function () {
            view.$data.searchContact.phoneBookId = view.$data.selectedPhoneBook.id;
            if (view.$data.searchContact.searchText) {
                this.serverCall('POST', "/api/entry", view.$data.searchContact, view.$data.entries);
            }
        },
        getPhoneBookEntries: function (event, id, name) {
            view.$data.selectedPhoneBook.id = id;
            view.$data.selectedPhoneBook.name = name;
            this.serverCall('GET', `/api/entry/${id}`, null, view.$data.entries);
        },
        addNewPhoneBook: function () {
            var phoneBookBookName = view.$data.newPhoneBook.name.trim();
            if (phoneBookBookName) {
                this.serverCall('PUT', "/api/phonebook", view.$data.newPhoneBook, view.$data.library);
                this.resetNewPhoneBook(view.$data.newPhoneBook);
            }
            else {
                view.$data.newPhoneBook.error = "Name required";
            }
        },
        addNewContact: function () {
            var contactName = view.$data.newContact.name.trim();
            var contactNumber = view.$data.newContact.phoneNumber.trim();
            var phoneBookId = view.$data.selectedPhoneBook.id;
            view.$data.newContact.phoneBookId = phoneBookId;

            if (contactName && contactNumber && phoneBookId > 0) {
                this.serverCall('PUT', "/api/entry", view.$data.newContact, view.$data.entries);
                this.resetNewContact(view.$data.newContact);
            }
            else {
                view.$data.newContact.error = "Phone book, name and number required";
            }
        },
        getAllPhoneBooks: function () {
            this.serverCall('GET', "/api/phonebook", null, view.$data.library)
        },
        resetNewContact: function (obj) {
            obj.name = '';
            obj.phoneNumber = '';
            obj.error = '';
        },
        resetNewPhoneBook: function (obj) {
            obj.name = '';
            obj.error = '';
        },
        showSearchContact: function () {
            $('#addContact').hide();
            $('#searchContact').show();
        },
        showAddContact: function () {
            $('#addContact').show();
            $('#searchContact').hide();
        },
        serverCall: function (method, destUrl, obj, dataItem) {
            var jsonData = obj ? JSON.stringify(obj) : '';

            $.ajax({
                method: method,
                url: destUrl,
                dataType: "json",
                contentType: "application/json",
                data: jsonData,
                success: function (resp) {
                    dataItem.data = resp.slice();
                },
                error: function () {
                    console.log("failed");
                },
                complete: function () {
                    console.log("complete");
                }
            });
        }
    }
});

$(document).ready(function () {
    view.getAllPhoneBooks();
});