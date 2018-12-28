define(['ko'], function(ko) {
    return function (val) {
        var self = this;
        self.cell = ko.observable(val);

        ko.extenders.forCalcSummEx = function (target, params) {
            target.subscribe(function (val) {
                var par1 = (!!!params[1]() ? 0 : params[1]()).toString();
                var par2 = (val == '' ? 0 : val).toString();
                var preRes1 = par1.split('.');
                var preRes2 = par2.split('.');
                if (preRes1.length > 1) {
                    par1 = (parseInt(preRes1[0]) * 60) + parseInt(preRes1[1]);
                } else {
                    par1 = (parseInt(preRes1[0]) * 60);
                }
                if (preRes2.length > 1) {
                    par2 = (parseInt(preRes2[0]) * 60) + parseInt(preRes2[1]);
                } else {
                    par2 = (parseInt(preRes2[0]) * 60);
                }
                
                var summ = par1 + par2;
                var drob = summ % 60;
                var n1 = (summ - drob) / 60;
                var res = (n1 + ':' + drob).toString();
                params[0](res == '0' ? '' : res);
            });
        }

        ko.extenders.totalTimeCellExt = function (target, params) {
            var tar = target();
            var hasTotalCell = ((params + 1) % 21 == 0);
            target.isTotalTimeCell = ko.observable(hasTotalCell);
            

        }

        self.cell.subscribe(function (newVal) {
            var isWord = newVal.match(/[a-zA-Zа-яА-Я]/ig);
            self.cell(isWord != null ? '' : newVal);
        });
    }
});