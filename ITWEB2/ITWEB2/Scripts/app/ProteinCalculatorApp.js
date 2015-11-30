var ProteinCalculatorApp = angular.module('ProteinCalculatorApp', ['ui.router']);

ProteinCalculatorApp.config([
    '$urlRouterProvider', '$stateProvider', function($urlRouterProvider, $stateProvider) {
        // default route
        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: 'Scripts/app/views/LandingPageView.html',
                controller: 'LandingPageController'
            });
    }
]);

ProteinCalculatorApp.controller('LandingPageController', LandingPageController);