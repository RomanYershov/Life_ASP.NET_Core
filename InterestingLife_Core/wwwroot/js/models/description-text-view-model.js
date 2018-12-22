define(['ko', 'models/description'], function(ko, Description) {
    return function(params) {
        var self = this;

        var desc = new Description();

        self.text = desc.descriptionText();
        params.selectCellId.subscribe(function (newValue) {
            debugger;
           
        });
        debugger;
    }
});