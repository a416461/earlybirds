(function () {
	'use strict';

	angular
        .module('earlybirds')
        .controller('HeaderController', HeaderController);
	function HeaderController() {
		var vm = this;
		vm.state = 0;
		vm.swipeLeft = function () {
		        vm.state=0;    
		};
		vm.swipeRight = function () {
		    if (vm.state < 1) {
		        vm.state++;
		    }
		};
	}
	}());