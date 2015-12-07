var ProteinCalculatorApp = angular.module('ProteinCalculatorApp', ['ui.router']);

ProteinCalculatorApp.config([
    '$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {
        // default route
        $urlRouterProvider.otherwise('/home');

        $stateProvider
            .state('home', {
                url: '/home',
                views: {
                    nav: {
                        templateUrl: '/Scripts/app/views/menuPartial.html',
                        controller: 'MenuController'
                    },
                    content: {
                        templateUrl: '/Scripts/app/views/HomeView.html',
                        controller: 'HomeController'
                    }
                }
            })
            .state('intake', {
                url: '/intake',
                views: {
                    nav: {
                        templateUrl: '/Scripts/app/views/menuPartial.html',
                        controller: 'MenuController'
                    },
                    content: {
                        templateUrl: '/Scripts/app/views/IntakeView.html',
                        controller: 'IntakeController'
                    }
                }
            })
            .state('user', {
                url: '/user',
                views: {
                    nav: {
                        templateUrl: '/Scripts/app/views/menuPartial.html',
                        controller: 'MenuController'
                    },
                    content: {
                        templateUrl: '/Scripts/app/views/UserView.html',
                        controller: 'UserController'
                    }
                }
            })
            .state('register', {
                url: '/register',
                views: {
                    nav: {
                        templateUrl: '/Scripts/app/views/menuPartial.html',
                        controller: 'MenuController'
                    },
                    content: {
                        templateUrl: '/Scripts/app/views/RegisterView.html',
                        controller: 'RegisterController'
                    }
                },
                
            })
            .state('login', {
                url: '/login',
                views: {
                    nav: {
                        templateUrl: '/Scripts/app/views/menuPartial.html',
                        controller: 'MenuController'
                    },
                    content: {
                        templateUrl: 'Scripts/app/views/LoginView.html',
                        controller: 'LoginController'
                    }
                }
            });
    }
]);

ProteinCalculatorApp.run([
    '$rootScope', function($rootScope) {
        $rootScope.loginStatus = false;
    }
]);

ProteinCalculatorApp.controller('HomeController', HomeController);
ProteinCalculatorApp.controller('IntakeController', IntakeController);
ProteinCalculatorApp.controller('UserController', UserController);
ProteinCalculatorApp.controller('RegisterController', RegisterController);
ProteinCalculatorApp.controller('LoginController', LoginController);
ProteinCalculatorApp.controller('MenuController', MenuController);
