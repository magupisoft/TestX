﻿(function(){
	'use strict';
	angular.module("testX").controller('SaveMovieController', SaveMovieController);

	SaveMovieController.$inject = ['movieService', 'logger', '$uibModalInstance'];

	function SaveMovieController(movieService, logger, $uibModalInstance, product) {
		var saveMovieVm = this;
		saveMovieVm.product = product;
		console.log(saveMovieVm.product);

		saveMovieVm.saveMovie = function () {
			if (saveMovieVm.product.id === null) {
			    movieService.add(saveMovieVm.product).then(
                    function(p) {
                        $uibModalInstance.close(p);
                    },
			        function(e) {
			            logger.error(e);
			        });
			} else {
			  movieService.update(saveMovieVm.product).then(
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