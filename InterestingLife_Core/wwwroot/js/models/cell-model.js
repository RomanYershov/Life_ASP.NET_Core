define(['ko'], function (ko) {
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

                var totalSumCell = params[0];
                totalSumCell.extend({ statusColor: res == '0' ? '' : res });
                totalSumCell(res == '0' ? '' : res);
            });
        }
        ko.extenders.statusColor = function (target, params) {
            var el = this.document.activeElement.nextElementSibling;
            if (el.id == '20')
                el = el.nextElementSibling;

            if (parseInt(params) < 3)
                el.style.backgroundColor = '#ff5252';
            if (parseInt(params) >= 3)
                el.style.backgroundColor = '#2196F3';
        }
        ko.extenders.totalTimeCellExt = function (target, params) {

            var tar = target();
            var hasTotalCell = ((params + 1) % 21 == 0);
            target.isTotalTimeCell = ko.observable(hasTotalCell);
            target.goodResultColor = ko.observable(false);
            target.badResultColor = ko.observable(false);
            if (hasTotalCell) {
                debugger;
                var val = !!!tar ? 0 : tar.split(':')[0];
                if (parseInt(val) >= 3) {
                    target.goodResultColor(true);
                }
                else {
                    target.badResultColor(true);
                }
            }


        }

        self.cell.subscribe(function (newVal) {
            var isWord = newVal.match(/[a-zA-Zа-яА-Я]/ig); //\*\/\\:;\|\{\}\(\)-=_,&\^%\$#@\!~`<>\?\"'   
            self.cell(isWord != null ? '' : newVal);
        });
    }
});