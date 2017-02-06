(function (app) {
    'use strict';
    app.service('authenticationService', ['authData', '$http', '$q', '$window', 'localStorageService',
        function (authData, $http, $q, $window, localStorageService) {
            var tokenInfo;

            this.setTokenInfo = function (data) {
                tokenInfo = data;
                localStorageService.set("TokenInfo", JSON.stringify(tokenInfo));
            }

            this.getTokenInfo = function () {
                return tokenInfo;
            }

            this.removeToken = function () {
                tokenInfo = null;
                localStorageService.set("TokenInfo", null);
            }

            this.init = function () {
                if (localStorageService.get("TokenInfo")) {
                    tokenInfo = JSON.parse(localStorageService.get("TokenInfo"));
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.userName = tokenInfo.userName;
                    authData.authenticationData.image = tokenInfo.image;
                    authData.authenticationData.createdDate = tokenInfo.createdDate;
                    authData.authenticationData.accessToken = tokenInfo.accessToken;
                }
            }

            this.setHeader = function () {
                delete $http.defaults.headers.common['X-Requested-With'];
                if ((tokenInfo != undefined) && (tokenInfo.accessToken != undefined) && (tokenInfo.accessToken != null) && (tokenInfo.accessToken != "")) {
                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenInfo.accessToken;
                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                }
            }
            this.init();
        }
    ]);
})(angular.module('uStora.common'));