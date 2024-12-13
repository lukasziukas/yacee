const {
	watch,
	parallel,
	series,
	src,
	dest } = require('gulp');

const path = require('path');

const babel = require('gulp-babel');
const sass = require('gulp-sass')(require('node-sass'));

const rename = require('gulp-rename');

const jsPathBase = 'assets\\js'
const jsBuild = path.join(jsPathBase, 'build');

const sassPathBase = 'assets\\sass';
const sassBuild = path.join(sassPathBase, 'build');

const libsPath = 'assets\\libs';

const imgPath = 'assets\\images';

function style(){
	return src(path.join(sassBuild, '*.scss'))
		.pipe(sass().on('error', sass.logError))
		.pipe(dest('wwwroot\\css'));
};

function lint(){
	return src(path.join(jsBuild, '*.js'))
		.pipe(babel())
		.pipe(dest('wwwroot\\js'))
		.pipe(rename({ extname: '.min.js' }))
		.pipe(dest('wwwroot\\js'));
};

function libs(){
	return src(path.join(libsPath, '**'))
		.pipe(dest('wwwroot\\js\\libs'));
};

function images(){
	return src(path.join(imgPath, '*'), {encoding: false})
	.pipe(dest('wwwroot\\images'));
}

function watchInit(){
	watch(path.join(jsPathBase, '**\\*.js'), lint);
	watch(path.join(sassPathBase, '**\\*.scss'), style);
	watch(path.join(libsPath, '**\\*'), libs);
	watch(path.join(imgPath, '**\\*'), images);
};

const defaultInit = series(style, lint, libs, images);

exports.default = defaultInit;
exports.watch = watchInit;
