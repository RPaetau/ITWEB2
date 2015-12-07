var LoginController = function ($scope, $http, $state) {

    $scope.login = function (email, password) {
        var data = {
            grant_type: 'password',
            username: email,
            password: password
        };
        $http({
                url: '/token',
                method: 'POST',
                data: 'grant_type=' + data.grant_type + '&username=' + data.username + '&password=' + data.password,
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                    'Accept': '*/*'
                }
            })
            .success(function(response) {
                localStorage.setItem("tokenKey", response.access_token);
                $state.transitionTo('home');
            })
            .error(function(error) {
                console.log("Error:");
                console.log(error);
        });
    }

    $scope.logout = function() {
        $http.post('/api/Account/Logout');
        $state.transitionTo('home');
    }
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
LoginController.$inject = ['$scope', '$http', '$state'];