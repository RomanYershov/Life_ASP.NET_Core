define(['ko', 'jquery'], function(ko, $) {
    return function() {
        var self = this;

        self.message = function (tagId, message, color = 'red', start = 100, end = 5000) {
            var tag = $(tagId);
            tag.html(message);
            tag.css({ color: color });
            tag.animate({ opacity: '1' }, start, function() {
                tag.animate({opacity: '0'}, end);
            });
        }

    }
});