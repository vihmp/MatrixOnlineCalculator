function renderMatrixInput(rowCount, columnCount, name) {
    let div = $("<div></div>");
    div.addClass("matrix");

    let table = $("<table><tbody></tbody></table>");
    div.append(table);

    for (let i = 0; i < rowCount; i++) {
        let row = $("<tr></tr>");

        for (let j = 0; j < columnCount; j++) {
            row.append(`<td><input name="${name}[${i}][${j}]" value="0" /></td>`);
        }

        table.append(row);
    }

    return div;
}