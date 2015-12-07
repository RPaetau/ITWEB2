var IntakeController = function ($scope, $http) {

    $scope.models = {};

    var multiplier = 0.8;
    $scope.GramsPrDayNeeded = 0;

    $scope.IAmAdult = function() {
        multiplier = 0.8;
    }
    $scope.IAmWeakened = function () {  
        multiplier = 1.5;
    }
    $scope.IAmTraining = function () {
        multiplier = 2;
    }

    $scope.SubmitData = function (){
        $scope.GramsPrDayNeeded = $scope.UserWeight * multiplier;
    }

    var callbackData = function (data) {
        $scope.models.listOfFood = JSON.parse(data);
        $scope.$digest();
    }

    $http({
        method: 'GET',
        url: '/api/FoodStuffs'
    }).then(function successCallback(response) {
        callbackData(response.data);
    }, function errorCallback(response) {
        // called asynchronously if an error occurs
        // or server returns response with an error status.
    });

    var intakeModel = {
            "Id": "null", 
            "SamletProtein": 0,
            "Date": "null",
            "User": "null",
            "UserId": "null"
        }

    $http({
        method: 'POST',
        url: '/api/DaylyIntake'
    }).then(function () {
    });

}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
IntakeController.$inject = ['$scope', '$http'];