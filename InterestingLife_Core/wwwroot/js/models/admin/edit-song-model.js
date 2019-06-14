define(['ko', 'remote', 'validator', 'messages'], function(ko, Remote, Validator, MessageBox) {
    return function(params) {
        var self = this;
        
        self.remote = new Remote();
        self.msgBox = new MessageBox();
        self.validator = new Validator();
        self.songId = ko.observable();
        self.name = ko.observable();
        self.lirycs = ko.observable();
        self.choosingCategories = ko.observableArray();
        self.categories = ko.observableArray([]);
        self.categories.subscribe(function (val) {
            $.each(val, function(i, item) {
                item.hasChoosing = ko.observable(item.hasChoosing);
            });
        });

        params.song.subscribe(function (val) {
            self.songId(val.song.id);
            self.name(val.song.name);
            self.lirycs(val.song.lyrics);
            self.categories(val.categories);
        });


        self.validator.validation([self.name, self.lirycs], 'Необходимо ввести текст  .. ');
        self.save = function() {
            var res = self.validator.validationGroup();
            if (res.length > 0) {
                self.msgBox.message('#info-message', 'Необходимо заполнить все поля', 'red');
                return;
            }
            $.each(self.categories(), function (i, item) {
                if (item.hasChoosing()) {
                    debugger;
                    self.choosingCategories.push(item.category);
                }
            });
            var choosing = self.choosingCategories();
            debugger;
            self.remote.post('/admin/editSong/',
                {
                    Id: self.songId(),
                    Name: self.name(),
                    Lirycs: self.lirycs(),
                    Categories: self.choosingCategories()
                }, function (result) {
                    debugger;
                    if (result.isSuccess) {
                        self.msgBox.message('#info-message', 'Данные успешно обновлены !', 'green', 100, 7000);
                        params.getSongs();
                    } else {
                        self.msgBox.message('#info-message', result.errorText, 'red', 100, 20000);
                    }

            } );

        }


    }


});