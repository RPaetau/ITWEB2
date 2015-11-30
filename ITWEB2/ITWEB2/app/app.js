'use strict';

(function() {
    angular
        .module('ittweb2', ['ui.bootstrap', 'ui.router'])
        .config(function ($stateProvider, $urlRouterProvider) {

            // No matching url
            $urlRouterProvider.otherwise("/* placeholder */");

            // Set up states
            $stateProvider
                .state("/* placeholder */", {
                    url: "/* placeholder */",
                    templateUrl: "/* placeholder */"
            })
        });
})