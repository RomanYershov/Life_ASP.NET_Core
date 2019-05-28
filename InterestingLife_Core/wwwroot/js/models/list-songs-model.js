define(['ko', 'jquery', 'remote'], function(ko, $, Remote) {
    return function() {
        var self = this;

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
            debugger;
            self.remote.get("https://localhost:5001/api/songs/getSongById/"+song.id,
                function (result) {
                    debugger;
                    if (result.isSuccess) {
                        self.lyrics(result.data.lyrics);
                        self.name(result.data.name);
                    }
                });
        }

        self.getCategories = function() {
            debugger;
            self.remote.get("https://localhost:5001/api/songs/categories",
                function (result) {
                    if (result.isSuccess) {
                        debugger;
                        for (var i = 0; i < result.data.length; i++) {
                            self.categories.push({ id: result.data[i].id, name: result.data[i].name });
                        }
                    } else {
                        self.errorMessage(result.errorText);
                    }
                });
        }
        self.getSongsByCategory = function (category) {
            self.remote.get("https://localhost:5001/api/songs/getSongsByCategory/" + category.id,
                function (result) {
                    if (result.isSuccess) {
                        self.reset();
                        for (var i = 0; i < result.data.length; i++) {
                            self.songs.push({ id: result.data[i].id, name: result.data[i].name });
                        }
                    } else {
                        self.errorMessage(result.errorText);
                    }
                });
        }
        self.reset = function() {
            self.lyrics("");
            self.name("");
            self.songs([]);
        }
        self.errorMessage = function(message) {
            $('.error-block').html(message);
            $('.error-block').animate({
                opacity: '1'
            },100, function() {
                $('.error-block').animate({
                    opacity: '0'
                },5000);
            });
        }
        self.getCategories();

        //  self.getSongs();
    }
});