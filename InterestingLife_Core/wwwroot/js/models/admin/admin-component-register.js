define(['ko','jquery'], function(ko, $) {
    return function() {
        ko.components.register('add-song-block',
            {
                viewModel: { require: 'models/admin/create-song-model' },
                template: {require: 'text!/js/view/admin/create-song-view.html'}
            });
        ko.components.register('song-block',
            {
                viewModel: { require: 'models/admin/admin-song-view-model' },
                template: {require: 'text!/js/view/admin/song-view-block.html'}
            });
    }
});