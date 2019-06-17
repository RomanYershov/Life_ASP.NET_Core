define(['ko', 'messages', 'validator', 'services/categoryService', 'remote'], function(ko, Messages, Validator, CategoryService, Remote) {
    return function(params) {
        var self = this;
        
       
        self.msgBox = new Messages();
        self.validator = new Validator();
        self.remote = new Remote();

        self.name = ko.observable();
        self.validator.validation([self.name],'Необходимо ввести текст . .');

        self.create = function () {
            var res = self.validator.validationGroup();
            if (res.length > 0) {
                self.msgBox.message('#message', 'Необходимо заполнить все поля', 'red');
                return;
            }
            self.remote.post('/admin/createCategory',
                { name: self.name() }, function (res) {
                    if (res) {
                        if (res.isSuccess) {
                            self.msgBox.message('#message', 'Успешно !', 'green');
                            self.name('');
                            params.getCategories();
                        } else {
                            self.msgBox.message('#message',  res.errorText , 'red', 100, 17000);
                        }
                    }
                });
        }
    }
});