define(['ko', 'jquery'], function(ko, $) {
    return function() {
        ko.components.register('songs-list-block',
            {
                viewModel: {require: 'models/list-songs-model'},
                template: { require: 'text!/js/view/list-songs-view-model.html'}
            });
        ko.components.register('time-widget',
            {
                viewModel: { require: 'models/time-view-model' },
                template: { require: 'text!/js/view/time-view-model.html' }
            });
    }
});