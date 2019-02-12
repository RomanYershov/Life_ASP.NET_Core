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

        self.getSongs = function() {
            self.remote.get("https://localhost:5005/api/songs",
                function (result) {
                for (var i = 0; i < result.length; i++) {
                    self.songs.push({id: result[i].id, name: result[i].name});
                }
            });
        }

        self.getSongById = function(song) {
            debugger;
            self.remote.get("https://localhost:5005/api/songs/"+song.id,
                function (result) {
                   // self.song(new Song(result.id, result.name, result.lyrics, result.author, result.status));
                    self.lyrics(result.lyrics);
                    self.name(result.name);
                });
        }

        self.getSongs();
    }
});