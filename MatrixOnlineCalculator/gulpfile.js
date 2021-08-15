const { src, dest } = require("gulp");
const minify = require("gulp-minify");
const merge = require("merge-stream");

function minify_file(input, output) {
    return src(input)
        .pipe(minify())
        .pipe(dest(output));
}

function copy_file(input, output) {
    return src(input)
        .pipe(dest(output));
}

function min(cb) {
    let paths = [
        { in: "./node_modules/cldrjs/dist/cldr.js", out: "./wwwroot/lib/cldrjs/dist" },
        { in: "./node_modules/cldrjs/dist/cldr/event.js", out: "./wwwroot/lib/cldrjs/dist/cldr" },
        { in: "./node_modules/cldrjs/dist/cldr/supplemental.js", out: "./wwwroot/lib/cldrjs/dist/cldr" },
        { in: "./node_modules/globalize/dist/globalize.js", out: "./wwwroot/lib/globalize/dist" },
        { in: "./node_modules/globalize/dist/globalize/number.js", out: "./wwwroot/lib/globalize/dist/globalize" },
        { in: "./node_modules/jquery-validation-globalize-fix/jquery.validate.globalize.js", out: "./wwwroot/lib/jquery-validation-globalize-fix" }
    ];

    return merge(
        paths.map(function (val) {
            return minify_file(val.in, val.out);
        }));
}

function copy(cb) {
    let paths = [
        { in: "./node_modules/cldr-data/supplemental/likelySubtags.json", out: "./wwwroot/lib/cldr-data/supplemental" },
        { in: "./node_modules/cldr-data/supplemental/numberingSystems.json", out: "./wwwroot/lib/cldr-data/supplemental" },
        { in: "./node_modules/cldr-data/main/ru/numbers.json", out: "./wwwroot/lib/cldr-data/main/ru" }
    ];

    return merge(
        paths.map(function (val) {
            return copy_file(val.in, val.out);
        }));
}

exports.min = min
exports.copy = copy