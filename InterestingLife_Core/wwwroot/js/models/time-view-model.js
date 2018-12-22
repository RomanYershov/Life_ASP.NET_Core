define(['ko'], function(ko) {
    return function() {
        var self = this;

        self.time = ko.observable();

        var getCurrentTime = function() {
            var date = new Date();
            var hour = date.getHours();
            var min = date.getMinutes();
            var sec = date.getSeconds();
            var time = hour + ':' + min + ':' + sec;
            self.time(time);
        }
        setInterval(getCurrentTime, 1000);
    }
});