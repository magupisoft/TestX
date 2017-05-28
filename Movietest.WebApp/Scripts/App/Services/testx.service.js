(function() {
    "use strict";
    angular.module("testX")
           .factory("movieService", movieService);

    movieService.$inject = ['$http', 'logger', '$config'];

    function movieService($http, logger, $config) {
        return {
            all: all,
            get: get,
            add: add,
            update: update,
            remove: remove

        };   

        function all() {
            return $http({
                method: "GET",
                url: $config.endpoints.api + "api/movies/all"
            }).then(getAllMoviesResponse).catch(getAllMoviesFailed);

            function getAllMoviesResponse(response) {
                return response.data;
            }

            function getAllMoviesFailed(error) {
                logger.error('Failed when getting All Movies.' + error.data);
            }
        }

        function get(id) {
            return $http({
                method: "GET",
                url: $config.endpoints.api + "api/movies/find/" + id
            }).then(getMovieResponse).catch(getMovieFailed);

            function getMovieResponse(response) {
                return response.data;
            }

            function getMovieFailed(error) {
                logger.error('Failed when getting Movies width:' + id + ". Error:" + error.data);
            }
        }

        function add(movie) {
            return $http({
                method: "POST",
                url: $config.endpoints.api + "api/movies/add",
                data: movie
            }).then(addMovieResponse).catch(addMovieFailed);

            function addMovieResponse(response) {
                return response.data;
            }

            function addMovieFailed(error) {
                logger.error('Failed when getting Adding a new Movie.' + error.data);
            }
        }

        function update(movie) {
            return $http({
                method: "PUT",
                url: $config.endpoints.api + "api/movies/update",
                data: movie
            }).then(updateMovieResponse).catch(updateMovieFailed);

            function updateMovieResponse(response) {
                return response.data;
            }

            function updateMovieFailed(error) {
                logger.error('Failed when getting Updating Movie width id:' + movie.id + ". Error:" + error.data);
            }
        }

        function remove(id) {
            return $http({
                method: "DELETE",
                url: $config.endpoints.api + "api/movies/remove/" + id,
                data: { id:id }
            }).then(deleteMovieResponse).catch(deleteMovieFailed);

            function deleteMovieResponse(response) {
                return response.data;
            }

            function deleteMovieFailed(error) {
                logger.error('Failed when deleting Movie width:' + id + ". Error:" + error.data);
            }
        }
    }

})();