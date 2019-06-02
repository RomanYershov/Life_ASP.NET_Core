define(['ko','jquery'], function(ko, $) {
    return function() {
        ko.components.register('add-song-block',
            {
                viewModel: { require: 'models/admin/create-song-model' },
                template: {require: 'text!/js/view/admin/create-song-view.html'}
            });
    }
});