(function(){
	'use strict';
	angular.module("testX").controller('SaveMovieController', SaveMovieController);

	SaveMovieController.$inject = ['movieService', 'logger', '$uibModalInstance'];

	function SaveMovieController(movieService, logger, $uibModalInstance, product) {
		var saveMovieVm = this;
		saveMovieVm.product = product;
		console.log(saveMovieVm.product);

		saveMovieVm.saveMovie = function () {
			console.log("save movie");
		};

		saveMovieVm.cancelSaveMovie = function () {
			$uibModalInstance.dismiss("cancel");
		};
	}

})();