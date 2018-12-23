define(['ko'], function(ko) {
    return function (val) {
        var self = this;
        self.cell = ko.observable(val);
        ko.extenders.forCalcSummEx = function (target, params) {
            target.subscribe(function (val) {
                var par1 = !!!params[1]() ? 0 : params[1]();
                var par2 = val == '' ? 0 : val;
                var summ = (parseFloat(par1) + parseFloat(par2)).toString();
                params[0](summ == '0' ? '' : summ);
            });
        }
        self.cell.subscribe(function (newVal) {
            var isWord = newVal.match(/[a-zA-Zа-яА-Я]/ig);
            self.cell(isWord != null ? '' : newVal);
        });
    }
});