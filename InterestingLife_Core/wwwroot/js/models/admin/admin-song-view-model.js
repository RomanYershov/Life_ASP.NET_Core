define(['ko', 'remote', 'messages', 'services/categoryService'], function(ko, Remote, Messages, CategoryService) {
    return function() {
        var self = this;

        self.remote = new Remote();
        self.msg = new Messages();
        self.categories = ko.observableArray();
        self.songsWithCategories = ko.observableArray([]);
        //self.shosenCategories = ko.observableArray();
        //self.shosenCategories.subscribe(function (va) { debugger; });
        //self.categoryService = new CategoryService();
        //self.getCategories = function() {
        //    self.categoryService.getCategories();
        //}
        self.resSongModel = ko.observable();
        self.getShosingCategories = function(categories) {
            $.each(categories, function(val, item) {
               
            });
        }
        self.editingSong = ko.observable();
        self.getEditinsSong = function (val) {
            self.editingSong(val);
        }
        
        self.getCategories = function () {
            self.remote.get("/api/songs/categories",
                function (result) {
                    if (result.isSuccess) {
                        self.categories(result.data);
                        self.getShosingCategories(result.data);
                    } 
                });
        }

       

        self.getSongs = function() {
            self.remote.get('/admin/GetSongsWithCategories', function (result) {
                if (result.isSuccess) {
                    self.songsWithCategories(result.data);
                } else {
                    self.msg.message('#info-msg', result.errorText, 'red', 100, 12000);
                }
            });
        }
        self.removeSong = function(item) {
            self.remote.post('/admin/RemoveSong', { song: item.song },
                function(result) {
                    if (result.isSuccess) {
                        self.getSongs();
                        self.msg.message('#info-msg', 'Запись удалена', 'green', 100, 12000);
                    } else {
                        self.msg.message('#info-msg', result.errorText, 'red', 100, 12000);
                    }
                });
        }
        self.getCategories();
        
        self.getSongs();
       
    }


});