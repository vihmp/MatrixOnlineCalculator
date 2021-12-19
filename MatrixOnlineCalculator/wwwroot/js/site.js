function renderMatrixInput(rowCount, columnCount, name) {
    let div = $("<div></div>");
    div.addClass("matrix");

    let table = $("<table><tbody></tbody></table>");
    div.append(table);

    let index = 0;

    for (let i = 0; i < rowCount; i++) {
        let row = $("<tr></tr>");

        for (let j = 0; j < columnCount; j++) {
            let input = $(`<input class="form-control" name="${name}[${index}]" value="0" />`);
            index++;

            input.focusout(function () {
                if (!$(this).val().trim()) {
                    $(this).val(0);
                }
            });

            let td = $("<td></td>");
            td.append(input);
            row.append(td);
        }

        table.append(row);
    }

    return div;
}

function renderEquationsSystemInput(equationsNumber, variablesNumber, aName, bName) {
    let div = $("<div></div>");
    div.addClass("equationSystem");

    let table = $("<table><tbody></tbody></table>");
    div.append(table);

    let aIndex = 0;

    for (let i = 0; i < equationsNumber; i++) {
        let row = $("<tr></tr>");

        for (let j = 0; j < variablesNumber; j++) {
            let input = $(`<input class="form-control" name="${aName}[${aIndex}]" value="0" />`);
            aIndex++;

            input.focusout(function () {
                if (!$(this).val().trim()) {
                    $(this).val(0);
                }
            });

            let td = $("<td></td>");
            td.append(input);
            row.append(td);

            td = $("<td></td>");
            let operator = "";

            if (j < variablesNumber - 1) {
                operator = "+";
            }
            else {
                operator = "=";
            }

            td.append(`<math><mrow><mo>&sdot;</mo><msub><mi>x</mi><mn>${j + 1}</mn></msub><mo>${operator}</mo></mrow></math>`);
            row.append(td);
        }

        let input = $(`<input class="form-control" name="${bName}[${i}]" value="0" />`);

        input.focusout(function () {
            if (!$(this).val().trim()) {
                $(this).val(0);
            }
        });

        let td = $("<td></td>");
        td.append(input);
        row.append(td);
        table.append(row);
    }

    return div;
}