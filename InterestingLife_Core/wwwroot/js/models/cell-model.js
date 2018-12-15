define(['ko'], function(ko) {
    return function(val) {
        this.cell = ko.observable(val);
        this.cell.subscribe(function (newVal) {
            debugger;
        });
    }
});