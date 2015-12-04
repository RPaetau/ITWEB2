var HomeController = function ($scope) {
    $scope.models = {
        helloAngular: 'This is the HomePage. Login or register to gain access to the app.'
    };
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
HomeController.$inject = ['$scope'];