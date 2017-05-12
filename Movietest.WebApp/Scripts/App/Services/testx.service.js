(function() {
    "use strict";
    angular.module("testX")
           .factory("movieService", movieService);

    movieService.$inject = ['$http', 'logger', '$config'];

    function movieService($http, logger, $config) {
        return {
            all: all
            //get: Get,
            //add: Add,
            //update: Update,
            //remove: Remove

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
    }

})();