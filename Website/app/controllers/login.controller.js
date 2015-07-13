(function () {
    'use strict';

    angular
        .module('earlybirds')
        .controller('LoginController', LoginController);

    function LoginController($scope) {
        $scope.password = '';
        $scope.isPasswordValid = isPasswordValid;
        $scope.showPasswordHint = false;
        $scope.$watch('password', TrackPasswordValidation);

        function  isPasswordValid() {
            return $scope.password.length> 10;
        }

        function TrackPasswordValidation() {
            if (isPasswordValid()) {
                $scope.showPasswordHint = false;
            }
            else {
                $scope.showPasswordHint = true;
            }
        }
    }
}());


//(function () {
//    'use strict';

//    angular
//        .module('earlybirds')
//        .controller('LoginController', LoginController);

//    function LoginController($scope) {
//        $scope.password = '';
//        $scope.isPasswordValid = isPasswordValid;
//        $scope.showPasswordHint = false;
//        $scope.passwordChanged = passwordChanged;


//        function isPasswordValid() {
//            return $scope.password.length > 10;
//        }

//        function passwordChanged() {
//            $scope.showPasswordHint = !isPasswordValid();
//        }
//    }
//}());