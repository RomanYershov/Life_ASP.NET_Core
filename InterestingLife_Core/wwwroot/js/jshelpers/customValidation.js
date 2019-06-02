define(['ko', 'jquery'], function(ko, $) {
    return function() {
        var self = this;
        self.objects = ko.observableArray([]);

        ko.extenders.validation = function (target, params) {
            target.istValid = ko.observable(true);
            target.validationMessage = ko.observable();
            target.subscribe(function(val) {
                 target.istValid(val == null || val === '');
                target.validationMessage(params);
            });
        }


        self.validation = function(objects, message) {
            
            $.each(objects,function(a,obj) {
                debugger;
                obj.extend({ validation: message });
                self.objects.push(obj);
            });
        }


        self.validationGroup = function () {
            self.errorObjects = ko.observableArray([]);
            $.each(self.objects(), function(val, obj) {
                if (obj() == null || obj() === '') {
                    self.errorObjects.push(obj);
                }
            });
            return self.errorObjects();
        }
    }
});