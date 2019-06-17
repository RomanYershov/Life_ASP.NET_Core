define(['ko', 'remote'], function(ko, Remote) {
    return function(params) {
        var self = this;

        self.remote = new Remote();
        self.categories = ko.observableArray();

        self.getCategories = function () {
            self.remote.get("/admin/getcategories",
                function (result) {
                    debugger;
                    if (result.isSuccess) {
                        self.categories(result.data);
                    }
                });
            return self.categories();
        }

        self.create = function(data) {
            self.remote.post('/admin/createCategory',
                {name: data}, function(res) {
                            params.onResultCreate(res);
                });
                    
                
        }
    }
});