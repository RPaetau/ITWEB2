var UserController = function ($scope, $http) {
    $scope.username = localStorage.getItem("userData").username;
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
UserController.$inject = ['$scope', '$http'];