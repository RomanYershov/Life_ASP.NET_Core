define(["jquery"], function ($) {
    return function () {
        var self = this;


        self.get = function (url, callback) {
            $.get(url, callback);
        };
        self.get = function (url, data, callback) {
            $.get(url + '/', data, callback);
        }

        self.post = function (url, data, callback) {
            $.post(url, data, callback);
        }


    }
});