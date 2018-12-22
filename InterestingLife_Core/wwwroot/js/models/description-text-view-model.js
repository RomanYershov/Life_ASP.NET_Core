define(['ko', 'models/description'], function(ko, Description) {
    return function(params) {
        var self = this;

        var desc = new Description();

        self.text = ko.observable();
        params.selectCellId.subscribe(function (newValue) {
            $.each(desc.descriptionText, function (key, val) {
                if(newValue === key)
                self.text(val);
            });

        });
    }
});