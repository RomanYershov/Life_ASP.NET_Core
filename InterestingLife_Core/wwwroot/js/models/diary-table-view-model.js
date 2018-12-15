define(['ko', 'jquery', 'remote', 'models/cell-model'], function (ko, $, remote, Cell) {
    return function () {
        var self = this;
        self.remote = new remote();
        self.title = ko.observable('ДУХОВНЫЙ ДНЕВНИК');
        self.currentDate = ko.observable('2018-12');//todo Нужно чтоб текущая дата устан динамически
        self.table = ko.observableArray();
        var column = function () {
            this.cells = ko.observableArray();
        }




        self.valueToString = function (formElement) {
            var str = "";
            for (var i = 0; i < formElement.length; i++) {
                if (i === 0 || i % 22 === 0) continue;
                str += formElement[i].value + ';';
            }
            return str;
        }

        self.saveNewValue = function (formElement) {
            var strValue = self.valueToString(formElement);
            self.remote.post('/Diary/Test', { str: strValue }, function (result) {
                debugger;
            });
        }

        var fillCells = function (arrValue) {
            self.table([]);
            var col = new column(); 
            for (var i = 0; i < arrValue.length - 1; i++) {
                if (i % 21 == 0) {
                    col = new column();
                    self.table.push(col);
                }
                col.cells.push(new Cell(arrValue[i]));
            }
        };
        self.getTable = function (evnt) {
            var selectedDate = !!!evnt ? self.currentDate() : evnt.currentDate();
            self.remote.get('/Diary/GetTableByDate', { date: selectedDate },
                function (result) {
                    debugger;
                    fillCells(result.oneMonthStatistic.split(";"));
                });
        }

        self.getTable();

    }
});