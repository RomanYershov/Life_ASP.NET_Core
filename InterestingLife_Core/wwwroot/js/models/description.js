define(['ko'], function(ko) {
    return function() {
        var self = this;

        self.list = ko.observableArray(["1.asdf", "2.asdf", "3.asdf", "4.asdf", "5.asdf"]);

        self.descriptionText = ko.observableArray([
            {
                1: "sdfasdf",
                2: "ytlsfdkpasgf[oaelwafkszs'dl'aslf",
                3: "sdfasfaowrjfslkjsakdjfljalsdjfljl"
            }]);
    }
});