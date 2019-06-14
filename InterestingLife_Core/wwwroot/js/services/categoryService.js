define(['ko', 'remote'], function(ko, Remote) {
    return function() {
        var self = this;

        self.remote = new Remote();
        self.categories = ko.observableArray();

        self.getCategories = function () {
            self.remote.get("/api/songs/categories",
                function (result) {
                    if (result.isSuccess) {
                        self.categories(result.data);
                    }
                });
            return self.categories();
        }
    }
});