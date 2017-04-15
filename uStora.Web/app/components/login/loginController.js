(function (app) {
    app.controller('loginController', ['$scope', 'loginService', '$injector', 'notificationService',
        function ($scope, loginService, $injector, notificationService) {

            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.loginSubmit = function () {
                if ($scope.loginData.userName === "" || $scope.loginData.password === "") {
                    return;
                }
                
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {

                    if (response !== null) {
                        notificationService.displayError("Tên đăng nhập hoặc mật khẩu không chính xác.");
                    }
                    else {
                        var stateService = $injector.get('$state');
                        stateService.go('home');
                    }
                });
            };
        }]);
})(angular.module('uStora'));