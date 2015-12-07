var HomeController = function ($scope, $http) {
    

    $scope.models = {
        helloAngular: 'This is the HomePage. Login or register to gain access to the app.'
    };
    $scope.User = {};



    var callbackData = function(data) {
        $scope.models.listOfFood = JSON.parse(data);
    }



    $scope.init = function() {
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
        //$scope.getMyUser();


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
            data: model,
            headers: {
                'Accept': '*/*',
                'Authorization': 'Bearer ' + localStorage.getItem('tokenKey')
            }
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


    $scope.getMyUser = function(){
        $http({
            url: '/api/User/1',
            method: 'GET',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
                'Accept': '*/*',
                'Authorization': 'Bearer ' + localStorage.getItem('tokenKey')
            }
        })
        .success(function (response) {
                $scope.User = JSON.parse(response);
           })
        .error(function (error) {
            console.log("Error:");
            console.log(error);
        });
    }
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
HomeController.$inject = ['$scope','$http'];
