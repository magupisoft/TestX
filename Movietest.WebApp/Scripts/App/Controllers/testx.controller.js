(function () {
    'use strict';
    angular.module("testX").controller('MovieController', MovieController);

    MovieController.$inject = ['movieService', 'logger'];

    function MovieController(movieService, logger) {
        var moviesVm = this;
        moviesVm.movies = [];

        activate();

        function activate() {
            return getAllMovies().then(function () {
                logger.info('Activated Movies View');
                console.log(moviesVm.movies);
            });
        }

        function getAllMovies() {
            return movieService.all().then(function (data) {
                moviesVm.movies = data;
                return moviesVm.movies;
            });
        }

        moviesVm.addNewMovie = function() {
            console.log("Add new movie");
        };

        activate();
    }
})();