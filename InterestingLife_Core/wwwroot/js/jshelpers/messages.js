define(['ko', 'jquery'], function(ko, $) {
    return function() {
        var self = this;

        self.message = function (tagId, message, color = 'red') {
            debugger;
            var tag = $(tagId);
            tag.html(message);
            tag.css({ color: color });
            tag.animate({ opacity: '1' }, 200, function() {
                tag.animate({opacity: '0'}, 5000);
            });
        }

    }
});