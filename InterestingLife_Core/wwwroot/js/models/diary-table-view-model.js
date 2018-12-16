define(['ko', 'jquery', 'remote', 'models/cell-model'], function (ko, $, remote, Cell) {
    return function () {
        var self = this;
        self.remote = new remote();
        self.title = ko.observable('ДУХОВНЫЙ ДНЕВНИК');
        self.id = ko.observable();
        self.getCurrentDate = function () {
            var date = new Date();
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            return year + '-' + month;
        }
        self.currentDate = ko.observable(self.getCurrentDate());
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
        self.createNewTable = function () {

        }
        self.saveNewValue = function (formElement) {
            debugger;
            var strValue = self.valueToString(formElement);
            self.remote.post('/Diary/Save', { id: self.id(), str: strValue, date: self.currentDate() },
                function (result) {
                    self.id(result);
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
        var fakeFillCells = function () {
            self.table([]);
            var col = new column();
            for (var i = 0; i < 651; i++) {
                if (i % 21 == 0) {
                    col = new column();
                    self.table.push(col);
                }
                col.cells.push(new Cell());
            }
        }
        self.getTable = function (evnt) {
            var selectedDate = !!!evnt ? self.currentDate() : evnt.currentDate();
            self.remote.get('/Diary/GetTableByDate', { date: selectedDate },
                function (result) {
                    if (result === "not data") {
                        fakeFillCells();
                        return;
                    }
                    self.id(result.id);
                    fillCells(result.oneMonthStatistic.split(";"));
                });
        }

        self.getTable();

    }
});