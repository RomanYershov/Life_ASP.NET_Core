define(['ko'], function(ko) {
  return function() {
    ko.components.register('login-form',
      {
        viewModel: { require: 'models/account/account-login-model' },
        template: {require: 'text!/js/view/account/account-login-view.html'}
      });
  }
});