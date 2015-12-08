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

    $scope.SubmitDailyIntake = function () {
        var total = 0;
        $scope.models.listOfFood.forEach(function (item) {
            if (!isNaN(item.Amount))
                total += item.Amount * (item.Protein100Gr / 100);
        });
        var intakeModel = {
            "Id": "null",
            "SamletProtein": Math.round(total),
            "Date": "null",
            "User": "null",
            "UserId": "null"
        }
        $http({
            method: 'POST',
            url: '/api/DailyIntake',
            data: intakeModel,
            headers: {
                'Accept': '*/*',
                'Authorization': 'Bearer ' + localStorage.getItem('tokenKey')
            }
        }).then(function () {
            $http({
                method: 'GET',
                url: '/api/DailyIntake',
                headers: {
                    'Accept': '*/*',
                    'Authorization': 'Bearer ' + localStorage.getItem('tokenKey')
                }
            }).then(function successCallback(response) {
                $scope.models.listOfDailyIntakes = JSON.parse(response.data);
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
        });


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
        url: '/api/FoodStuffs',
        headers: {
            'Accept': '*/*',
            'Authorization': 'Bearer ' + localStorage.getItem('tokenKey')
        }
    }).then(function successCallback(response) {
        callbackData(response.data);
    }, function errorCallback(response) {
        // called asynchronously if an error occurs
        // or server returns response with an error status.
    });

    $http({
        method: 'GET',
        url: '/api/DailyIntake',
        headers: {
            'Accept': '*/*',
            'Authorization': 'Bearer ' + localStorage.getItem('tokenKey')
        }
    }).then(function successCallback(response) {
        $scope.models.listOfDailyIntakes = JSON.parse(response.data);
    }, function errorCallback(response) {
        // called asynchronously if an error occurs
        // or server returns response with an error status.
    });



}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
IntakeController.$inject = ['$scope', '$http'];