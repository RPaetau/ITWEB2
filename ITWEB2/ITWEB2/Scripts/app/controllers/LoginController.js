var LoginController = function ($scope, $http) {
    $scope.login = function (email, password) {
        var data = {
            grant_type: 'password',
            username: email,
            password: password
        };
        $http({
            url: '/token',
            method: 'POST',
            data: 'data',
            headers: {
                    "Content-Type": "application/json"
                }
            })
        .then(function (response) {
            console.log(response);
        });
    }
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
LoginController.$inject = ['$scope', '$http'];