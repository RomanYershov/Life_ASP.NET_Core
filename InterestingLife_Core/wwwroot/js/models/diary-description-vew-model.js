define(['ko', 'models/description'], function(ko, Description) {
    var descriptionModel = function (params) {
        var self = this;


        self.description = ko.observableArray(Description);
      
        self.test = ko.observable(params.name);
    };
    debugger;
    ko.components.register('description-block', {
        viewModel: descriptionModel,
        template: { require: 'text!/js/view/description-view-model.html'}
    });
});