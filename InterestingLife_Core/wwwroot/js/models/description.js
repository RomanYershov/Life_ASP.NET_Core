﻿define(['ko'], function(ko) {
    return function() {
        var self = this;

        self.list = ko.observableArray([
             "В мыслях",
            "В словах",
            "В поступках",
            "Ложь",
            "Хитрость",
            "Лицемерие",
            "Обман",
            "Противозаконное приобретение"]);

        self.descriptionText = 
            {
            1: "Зависть, обидчивость, ревность, агрессивные и злые мысли, жалость к себе или похвала себя, мстительность, гнев, любое нарушение условий к Посвящению и рекомендаций Мастера для духовного прогресса.",
            2: "Критика, злословие(говорить негативное о других или слушать негативные речи о других), высмеивание, пустословие, болтливость, претензии и упреки, ревность, жалость к себе, похвала себя и других, раздражительность, злость, агрессия, гнев, мстительность, колкость, язвительность, грубый тон, нецензурные слова, любое нарушение условий к Посвящению и рекомендаций Мастера для духовного прогресса.",
            3: "Наказание кого-либо, применение физической силы с агрессией, лень, причинение вреда своему организму или организму других (например, нарушение гигиены), любое нарушение условий к Посвящению и рекомендаций Мастера для духовного прогресса.",
            4: "Любая искаженная информация, независимо от цели",
            5: "Оправдание собственных поступков, приспособленчество, извлечение выгоды для себя, притворство, неискренность, фальшь, дача взяток и чаевых.",
            6: "Неискренность; думаешь -  одно, говоришь - другое, делаешь – третье; фальшь.",
            7: "Продуманная заранее дезинформация, невыполнение обещаний",
            8: "Желание что-то получить любой ценой, при этом нарушая закон (например, неоплата проезда в транспорте), кража, воровство, получение взяток и  чаевых, задержка выплаты долга, неуплата алиментов.",
            9: "Похоть, прелюбодеяние в мыслях, в том числе и во сне.",
            10: "Похоть, прелюбодеяние в словах, разжигание похоти в других, просмотр и прослушивание информации сексуально-эротического содержания.",
            11: "Прелюбодеяние",
            12: "Похвала себя и других в мыслях и в словах, чувство собственной значимости, превосходства над другими, гордость способностями, привлечение внимания к себе",
            13: "Деньгами, материальными вещами, привлечение внимание к себе (например, красование перед другими одеждой), жадность.",
            14: "Гордость своим положением, поучение, навязывание своего мнения, пренебрежительное отношение к другим, привлечение внимание к себе, красование своей внешностью, дача обещания.",
            15: "Переедание, жадность по отношению к пище, гурманство, не повторение Симрана; любое нарушение вегетарианского питания, нечаянное или осознанное.",
            16: "Любой отказ в физической севе, независимо от причины; выполнение севы без Симрана.",
            17: "Упустить возможность сделать финансовую севу",
            18: "Трата времени на пустые мысли, разговоры или дела, из-за которых внимание опускается ниже уровня Третьего глаза или привязывается к внешнему миру (например, просмотр телевизора, чтение литературы недуховного содержания и т.п.), или которые являются нарушением заповедей. Время, когда мысленно на держал Симран или не думал о Мастере",
            19: "Вести учет времени медитации в часах и минутах.",
            20: "Вести учет времени медитации в часах и минутах."
            };
    }
});