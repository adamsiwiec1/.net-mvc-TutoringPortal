// JavaScript source code

//var gulp = require('gulp');
//var gulpSass = require('gulp-sass');


//gulp.task('compile-sass', function () {
//    gulp.src('./wwwroot/lib/bootstrap/scss/bootstrap.scss')
//        .pipe(gulpSass()).pipe(gulp.dest('./wwwroot/css'));
//});


gulp.task("scripts", function () {

    var streams = [];

    for (var prop in deps) {
        console.log("Prepping Scripts for: " + prop);
        for (var itemProp in deps[prop]) {
            streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                .pipe(gulp.dest("wwwroot/vendor/" + prop + "/" + deps[prop][itemProp])));
        }
    }

    return merge(streams);

});