define(['ko', 'jquery', 'remote', 'models/cell-model'], function (ko, $, remote, Cell) {
    var viewModel = function (params) {
        var self = this;
        self.remote = new remote();
        self.title = ko.observable('ДНЕВНИК');
        self.selectCellId = ko.observable();
        self.hasFocusCell = function (cell, element) {
            var id = element.target.id;
            self.selectCellId(id);
        }
        self.id = ko.observable();
        self.getCurrentDate = function () {
            var date = new Date();
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            return year + '-' + month;
        };
        self.selectedDate = ko.observable(self.getCurrentDate());
        self.table = ko.observableArray();
        var column = function () {
            this.cells = ko.observableArray();
        }




        self.valueToString = function () {
            var str = "";
            var tbl = self.table();
            for (var j = 0; j < tbl.length; j++) {
                for (var i = 0; i < tbl[j].cells().length; i++) {
                    var cell = tbl[j].cells()[i].cell();
                    str += (!!!cell ? '' : cell) + ";";
                }
            }
            return str;
        }

        self.saveNewValue = function () {
            var strValue = self.valueToString();
            self.remote.post('/Diary/Save', { id: self.id(), str: strValue, date: self.selectedDate() },
                function (result) {
                    self.id(result);
                    $('#message').animate({ opacity: 1}, 700);
                });
        }
       
        var getTotalTime = function () {
            var table = self.table();
            var soundCell, ligthCell, totalCell;
            for (var i = 0; i < table.length; i++) {
                for (var j = 0; j < table[i].cells().length; j++) {
                    if (j < 18) continue;
                    if (j == 18) {
                        soundCell = table[i].cells()[j].cell;
                    }
                    if (j == 19) {
                        ligthCell = table[i].cells()[j].cell;
                    }
                    if (j == 20) {
                        totalCell = table[i].cells()[j].cell;
                        soundCell.extend({ forCalcSummEx: [totalCell, ligthCell]});
                        ligthCell.extend({ forCalcSummEx: [totalCell, soundCell]});
                    }
                }
            }
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
            getTotalTime();
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
            getTotalTime();
        }

        self.getTable = function (evnt) {
            var selectedDate = !!!evnt ? self.selectedDate() : evnt.selectedDate();
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
    };
    return viewModel;
});