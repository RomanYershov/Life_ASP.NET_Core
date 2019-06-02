define(['ko', 'jquery', 'remote', 'messages'], function(ko, $, Remote, Messages) {
    return function() {
        var self = this;
        self.msg = new Messages();
        self.remote = new Remote();
        self.songs = ko.observableArray();
        var Song = function(id, name, lyrics, author, status) {
            this.id = ko.observable(id);
            this.name = ko.observable(name);
            this.lyrics = ko.observable(lyrics);
            this.author = ko.observable(author);
            this.status = ko.observable(status);

        }
        self.song = ko.observable();
        self.selectedSong = ko.observableArray();
        self.lyrics = ko.observable();
        self.name = ko.observable();
        self.categories = ko.observableArray();

        //self.getSongs = function() {
        //    self.remote.get("https://localhost:5005/api/songs",
        //        function (result) {
        //        for (var i = 0; i < result.length; i++) {
        //            self.songs.push({id: result[i].id, name: result[i].name});
        //        }
        //    });
        //}

        self.getSongById = function(song) {
            self.remote.get("/api/songs/getSongById/"+song.id,
                function (result) {
                    debugger;
                    if (result.isSuccess) {
                        self.lyrics(result.data.lyrics);
                        self.name(result.data.name);
                    }
                });
        }

        self.getCategories = function() {
            self.remote.get("/api/songs/categories",
                function (result) {
                    if (result.isSuccess) {
                        for (var i = 0; i < result.data.length; i++) {
                            self.categories.push({ id: result.data[i].id, name: result.data[i].name });
                        }
                    } else {
                        self.msg.message('.error-block', 'Не найдено ни одной категории', 'red');
                    }
                });
        }
        self.getSongsByCategory = function (category) {
            self.remote.get("/api/songs/getSongsByCategory/" + category.id,
                function (result) {
                    if (result.isSuccess) {
                        self.reset();
                        for (var i = 0; i < result.data.length; i++) {
                            self.songs.push({ id: result.data[i].id, name: result.data[i].name });
                        }
                    } else {
                        self.reset();
                        self.msg.message('.error-block', 'Нет песен по выбранной категории', 'red');
                    }
                });
        }
        self.reset = function() {
            self.lyrics("");
            self.name("");
            self.songs([]);
        }
        
        self.getCategories();

        //  self.getSongs();
    }
});