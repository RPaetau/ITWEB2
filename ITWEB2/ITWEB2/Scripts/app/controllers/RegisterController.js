var RegisterController = function ($scope, $http) {

    $scope.register = function (email, password, confirmPassword) {
        console.log(email);
        console.log(password);
        console.log(confirmPassword);

        var data = {
            email: email,
            password: password,
            confirmPassword: confirmPassword
        }

        $http.post('api/Account/Register', data)
            .then(
                function(response) {
                    console.log(response);
                },
                function(error) {
                    console.log(error);
                });
    }
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
RegisterController.$inject = ['$scope', '$http'];