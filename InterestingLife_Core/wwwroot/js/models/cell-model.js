define(['ko'], function(ko) {
    return function (val) {
        var self = this;
        self.cell = ko.observable(val);
        self.cell.subscribe(function (newVal) {
            var isWord = newVal.match(/[a-zA-Zа-яА-Я]/ig);
            self.cell(isWord != null ? '' : newVal);
        });
    }
});