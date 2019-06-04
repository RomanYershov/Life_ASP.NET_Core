define(['ko', 'remote', 'messages'], function(ko, Remote, Messages) {
    return function() {
        var self = this;

        self.remote = new Remote();
        self.msg = new Messages();
        self.songsWithCategories = ko.observableArray([]);
       

        self.getSongs = function() {
            self.remote.get('/admin/GetSongsWithCategories', function(result) {
                self.songsWithCategories(result.data);
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

        self.getSongs();
    }


});