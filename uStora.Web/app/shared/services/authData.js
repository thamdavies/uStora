(function (app) {
    'use strict';
    app.factory('authData', [function () {
        var authDataFactory = {};

        var authentication = {
            IsAuthenticated: false,
            userName: "",
            image: "/UploadedFiles/images/user-images/default-avatar.jpg",
            createdDate: "12/2/2016"
        };
        authDataFactory.authenticationData = authentication;

        return authDataFactory;
    }]);
})(angular.module('uStora.common'));