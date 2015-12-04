﻿var HomeController = function ($scope, $http) {
    $scope.models = {
        helloAngular: 'I work!'
    };

    var callbackData = function(data) {
        $scope.models.listOfFood = JSON.parse(data);
        $scope.$digest();
    }



    var init = function() {
        $http({
            method: 'GET',
            url: '/api/FoodStuffs'
        }).then(function successCallback(response) {
            callbackData(response.data);
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });


    }

    $scope.submitFood = function () {
        var model = {
            "Id": "null", 
            "Navn": $scope.models.FoodName,
            "Protein100Gr": $scope.models.Protein,
            "User": "null",
            "UserId": "null"
        }
        $http({
            method: 'POST',
            url: '/api/FoodStuffs',
            data: model
        }).then(function successCallback(response) {
            init();
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });
    }

    $scope.clearFood = function () {
        $scope.models.FoodName = null;
        $scope.models.Protein = null;
        $scope.$digest();
    }


    init();
}




// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
HomeController.$inject = ['$scope','$http'];