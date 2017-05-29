(function(){
	'use strict';
	angular.module("testX").controller('SaveMovieController', SaveMovieController);

	SaveMovieController.$inject = ['movieService', 'logger', '$uibModalInstance', 'movie'];

	function SaveMovieController(movieService, logger, $uibModalInstance, movie) {
		var saveMovieVm = this;
		saveMovieVm.movie = movie;

	    saveMovieVm.saveMovie = function () {
		    if (saveMovieVm.movie.id === null) {
		        movieService.add(saveMovieVm.movie).then(
                    function(p) {
                        $uibModalInstance.close(p);
                    },
			        function(e) {
			            logger.error(e);
			        });
			} else {
		        movieService.update(saveMovieVm.movie).then(
              function (p) {
                  $uibModalInstance.close(p);
              },
              function (e) {
                  logger.error(e);
              });
			}
		};

		saveMovieVm.cancelSaveMovie = function () {
			$uibModalInstance.dismiss("cancel");
		};
	}

})();