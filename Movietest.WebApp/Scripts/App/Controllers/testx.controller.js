(function () {
    'use strict';
    angular.module("testX").controller('MovieController', MovieController);

    MovieController.$inject = ['movieService', 'logger', '$uibModal'];

    function MovieController(movieService, logger, $uibModal) {
        var moviesVm = this;
        moviesVm.movies = [];
       
        function FillTable() {
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
            var modalInstance = $uibModal.open({
                controller: "SaveMovieController",
                controllerAs: "saveMovieVm",
                templateUrl: "/Scripts/App/Partials/_SaveMovie.html",
                backdrop: 'static'
            });

            modalInstance.result.then(function() {
                alert("Movie was added successfully");
                FillTable();
            }, function() {
                logger.info("Modal dismissed");
            });
        };

        moviesVm.editMovie = function (movieEdit) {
            var modalInstance = $uibModal.open({
                controller: "SaveMovieController",
                controllerAs: "saveMovieVm",
                templateUrl: "/Scripts/App/Partials/_SaveMovie.html",
                backdrop: 'static',
                resolve: {
                    movie: function() {
                        return movieEdit;
                    }
                }
            });

            modalInstance.result.then(function () {
                alert("Movie was edited successfully");
                FillTable();
            }, function () {
                logger.info("Modal dismissed");
            });
        };

        moviesVm.deleteMovie = function(movie) {
            console.log("delete movie");
        };

        FillTable();
    }
})();