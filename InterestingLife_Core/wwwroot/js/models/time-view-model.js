define(['ko'], function(ko) {
    return function() {
        var self = this;

        self.time = ko.observable();

        var getCurrentTime = function() {
            var date = new Date();
            var hour = date.getHours();
            var min = date.getMinutes();
            var sec = date.getSeconds();
            var time = hour + ':' + ( min.toString().length == 2 ? min : ('0' + min ) ) + ':' + (sec.toString().length == 2 ? sec : ('0' + sec));
            self.time(time);
        }
        setInterval(getCurrentTime, 1000);
    }
});