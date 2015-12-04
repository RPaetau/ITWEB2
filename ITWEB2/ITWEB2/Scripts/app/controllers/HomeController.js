var HomeController = function ($scope, $http) {
    $scope.models = {
        helloAngular: 'I work!'
    };

    var callbackData = function(data) {
        $scope.models.listOfFood = JSON.parse(data);
        $scope.$digest();
    }

    var init = function() {
        //$.ajax({
        //    dataType: "json",
        //    url: "/api/FoodStuffs",
        //    data: data,
        //    success: callbackData
        //});

        $http({
            method: 'GET',
            url: '/api/FoodStuffs'
        }).then(function successCallback(response) {
            callbackData(response.data)
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });


    }

    init();
}




// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
HomeController.$inject = ['$scope','$http'];