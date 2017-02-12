
(function (app) {
    'use strict';

    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData', 'apiService',
    function ($http, $q, authenticationService, authData, apiService) {
        var userInfo;
        var deferred;
        this.login = function (userName, password) {
            deferred = $q.defer();
            var data = "grant_type=password&username=" + userName + "&password=" + password;
            $http.post('/oauth/token', data, {
                headers:
                   { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (response) {
                var config = {
                    params: {
                        username: userName
                    }
                }
                apiService.get('/api/applicationuser/getbyname/', config, function (res) {
                    userInfo = {
                        accessToken: response.access_token,
                        userName: res.data.UserName,
                        image: res.data.Image,
                        createdDate: res.data.CreatedDate
                    };

                    authenticationService.setHeader();
                    authenticationService.setTokenInfo(userInfo);
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.accessToken = userInfo.accessToken;
                    authData.authenticationData.userName = userInfo.userName;
                    authData.authenticationData.image = userInfo.image;
                    authData.authenticationData.createdDate = userInfo.createdDate;
                    deferred.resolve(null);

                }, function (error) { });

            })
            .error(function (err, status) {
                initialValue();
                deferred.resolve(err);
            });
            return deferred.promise;
        }
       
        this.logOut = function () {
            apiService.post('/api/account/logout', null, function (response) {
                authenticationService.removeToken();
                initialValue();
                authData.authenticationData.accessToken = "";
            }, null);
        }
        function initialValue() {
            authData.authenticationData.IsAuthenticated = false;
            authData.authenticationData.userName = "";
            authData.authenticationData.image = "";
            authData.authenticationData.createdDate = "";
        }
    }]);
})(angular.module('uStora.common'));