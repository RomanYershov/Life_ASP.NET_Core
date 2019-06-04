define(['ko', 'remote', 'validator', 'messages'], function(ko, Remote, Validator, Messages) {
    return function(params) {
        
        
        var self = this;
        self.remote = new Remote();
        self.validator = new Validator();
        self.msg = new Messages();
        
       
        self.shosenCategories = ko.observableArray();
        self.name = ko.observable();
        self.lirycs = ko.observable();
        self.categories = ko.observableArray([]);
        self.validator.validation([self.name, self.lirycs], 'необходимо ввести текст ..');
        
        

        self.create = function (newSong) {
            var res = self.validator.validationGroup();
            if (res.length > 0) {
                self.msg.message('#message', 'Необходимо заполнить все поля', 'red');
                 return;
            }
           self.remote.post('/admin/createSong/',
                {
                    Name: newSong.name,
                    Lirycs: newSong.lirycs,
                    Categories: newSong.shosenCategories()
               }, function (result) {
                    if (result.isSuccess) {
                        self.cleanForm();
                        self.msg.message('#message', 'Данные успешно сохранены', 'green');
                        params.getSongs();
                    } else {
                        self.msg.message('#message', result.errorText, 'red', 100, 15000);
                        params.getSongs();
                    }
                });
        }
       
        self.getCategories = function () {
            self.remote.get("/api/songs/categories",
                function (result) {
                    if (result.isSuccess) {
                        for (var i = 0; i < result.data.length; i++) {
                            self.categories.push({ id: result.data[i].id, name: result.data[i].name });
                        }
                    } else {
                        self.msg.message('#message', 'Не найдено ни одной категории', 'red');
                    }
                });
        }

        self.cleanForm = function() {
            self.name('');
            self.lirycs('');
        }
        self.getCategories();
    } 
});