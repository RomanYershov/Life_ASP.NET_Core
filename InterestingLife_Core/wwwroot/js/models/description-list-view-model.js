define(['ko', 'models/description', 'models/table-model'], function (ko, Description, table) {
    var descriptionModel = function (params) {
        var self = this;
        var descriptionModel = new Description();
       
        self.description = descriptionModel.list();

        self.cellId = ko.observable();
        params.selectCellId.subscribe(function (newValue) {
            self.cellId(newValue);
        });;


    };
    return descriptionModel;
});