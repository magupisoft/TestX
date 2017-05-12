(function () {
    'use strict';
    angular.module("testX").controller('movieController', movieController);

    movieController.$inject = ['movieService', 'logger'];

    function movieController(movieService, logger) {
        var vm = this;
        vm.movies = [];

        activate();

        function activate() {
            return getAllMovies().then(function () {
                logger.info('Activated Movies View');
                console.log(vm.movies);
            });
        }

        function getAllMovies() {
            return movieService.all().then(function (data) {
                vm.movies = data;
                return vm.movies;
            });
        }

        activate();
    }
})();