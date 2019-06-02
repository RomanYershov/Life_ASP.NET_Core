define(['ko', 'remote', 'validator'], function(ko, Remote, Validator) {
    return function(params) {
        var self = this;
        self.remote = new Remote();
        self.validator = new Validator();

        self.name = ko.observable();
        self.lirycs = ko.observable();
        self.categories = ko.observableArray([]);
        self.selectedCategoryId = ko.observable();
        self.validator.validation([self.name, self.lirycs], '(!)');
        

        

        self.create = function (newSong) {
            var res = self.validator.validationGroup();
            if (res.length > 0) return;
           self.remote.post('/admin/createSong/',
                {
                    Name: newSong.name,
                    Lirycs: newSong.lirycs,
                    CategoryId: newSong.selectedCategoryId
               }, function (result) {
                    if (result.isSuccess) {

                    }
                });
        }

        self.getCategories = function () {
            self.remote.get("/api/songs/categories",
                function (result) {
                    debugger;
                    if (result.isSuccess) {
                        for (var i = 0; i < result.data.length; i++) {
                            self.categories.push({ id: result.data[i].id, name: result.data[i].name });
                        }
                    } else {
                        self.errorMessage("Не найдено ни одной категории");
                    }
                });
        }
        self.getCategories();
    } 
});