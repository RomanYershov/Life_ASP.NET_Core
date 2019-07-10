define(['ko', 'jquery', 'remote', 'validator', 'messages'], function (ko, $, Remote, Validator, MessageBox) {
    return function () {
        var self = this;

        self.remote = new Remote();
        self.validator = new Validator();
        self.msgBox = new MessageBox();

        self.login = ko.observable('');
        self.password = ko.observable('');

        self.validator.validation([self.login, self.password], "Необходимо заполнить поле");

        self.sendFormData = function() {
            if (self.validator.validationGroup().length > 0) {
                self.msgBox.message('#errorMessage', 'Необходимо заполнить все поля!', 'red');
                return ;
            } else {
                self.remote.post('/api/gettoken',
                    {
                        Login: self.login,
                        Password: self.password
                    }, function(result) {
                        if (result) {
                            if (result.IsSuccess) {
                                sessionStorage.setItem("accessToken", result.Data.access_token);

                            } else {
                                self.msgBox.message('#errorMessage', result.ErrorText, 'red');
                            }
                        }
                    });
            }
        }
    }
});