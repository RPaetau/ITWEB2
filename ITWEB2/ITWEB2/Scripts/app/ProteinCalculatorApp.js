var ProteinCalculatorApp = angular.module('ProteinCalculatorApp', ['ui.router']);

ProteinCalculatorApp.config([
    '$urlRouterProvider', '$stateProvider', function($urlRouterProvider, $stateProvider) {
        // default route
        $urlRouterProvider.otherwise('/home');

        $stateProvider
            .state('home', {
                url: '/home',
                templateUrl: '/Scripts/app/views/HomeView.html',
                controller: 'HomeController'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/Scripts/app/views/RegisterView.html',
                controller: 'RegisterController'
            })
        .state('login', {
            url: '/login',
            templateUrl: 'Scripts/app/views/LoginView.html',
            controller: 'LoginController'
        });
    }
]);

ProteinCalculatorApp.controller('HomeController', HomeController);
ProteinCalculatorApp.controller('RegisterController', RegisterController);
ProteinCalculatorApp.controller('LoginController', LoginController)