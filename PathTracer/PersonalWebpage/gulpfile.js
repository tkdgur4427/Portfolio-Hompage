/// <binding AfterBuild='copy' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var gulp_minify = require('gulp-clean-css');
var gulp_rename = require('gulp-rename');
var gulp_watch = require('gulp-watch');
var gulp_imagemin = require('gulp-imagemin');

gulp.task('copy', function () {
    // copy pure-min.css file to the wwwroot/css directory
    //gulp.src("./node_modules/purecss/build/pure-min.css").pipe(gulp.dest("./wwwroot/css"));
});

gulp.task('clean', function () {
    // watch any changes exists, if it is run the clean
    gulp_watch('./dev/css/global.css', function () {
        gulp.src("./dev/css/global.css")
            .pipe(gulp_rename(function (path) {
                path.basename += "-min";
            }))
            .pipe(gulp_minify({ debug: true }, (details) => {
                console.log(details.name + ":" + details.stats.originalSize);
                console.log(details.name + ":" + details.stats.minifiedSize);
            }))
            .pipe(gulp.dest("./wwwroot/css"));
    });
});

gulp.task('imagemin', function () {
    gulp.src('./dev/img/*')
        .pipe(gulp_imagemin())
        .pipe(gulp.dest('./wwwroot/img'));
});
