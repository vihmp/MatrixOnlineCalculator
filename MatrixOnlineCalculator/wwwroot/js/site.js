function renderMatrixInput(rowCount, columnCount, name) {
    let div = $("<div></div>");
    div.addClass("matrix");

    let table = $("<table><tbody></tbody></table>");
    div.append(table);

    for (let i = 0; i < rowCount; i++) {
        let row = $("<tr></tr>");

        for (let j = 0; j < columnCount; j++) {
            let input = $(`<input class="form-control" name="${name}" value="0" />`);
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