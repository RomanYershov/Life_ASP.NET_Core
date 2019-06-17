define(['ko', 'remote', 'messages', 'validator', 'services/categoryService'], function(ko, Remote, Messages, Validator, CategoryService) {
    return function(params) {
        var self = this;

        self.remote = new Remote();

        self.categoryService = new CategoryService();
        self.msgBox = new Messages();

        self.categories = ko.observableArray();


        self.getCategories = function() { //ToDo: заменить на сервис
            self.remote.get('/admin/getCategories', function(result) {
                if (result) {
                    if (result.isSuccess) {
                        self.categories(result.data);
                    }
                }
            });
        }

        self.remove = function (item) {
            self.remote.post('/admin/removeCategory', { category: item },
                function(result) {
                    if (result) {
                        if (result.isSuccess) {
                            self.msgBox.message('#info-msg', 'Запись успешно удалена !', 'green', 100, 8000);
                            self.getCategories();
                        } else {
                            self.msgBox.message('#info-msg', result.errorText, 'red',100, 30000);
                        }
                    }
                });
        }

        self.getCategories();


    }
});