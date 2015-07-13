(function () {
    'use strict';

    angular
        .module('earlybirds')
        .config(config);

    config.$injenct = ['$routeProvider', '$locationProvider'];

    function config($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        $routeProvider
            .when('/tickets/:ticketId?', {
                templateUrl: '/app/templates/tickets.html',
                controller: 'TicketsController',
                controllerAs: 'vm'
            })
            .when('/sign-in', {
                templateUrl: '/app/templates/sign-in.html',
                controller:'LoginController'
            })
            .when('/about', {
                templateUrl: '/app/templates/about.html'
            })
            .when('/contact', {
                templateUrl: '/app/templates/contact.html'
            })
            .when('/inventory', {
                templateUrl: '/app/templates/inventory.html'
            })
            .when('/suggestion', {
                templateUrl: '/app/templates/suggestion.html',
                controller: 'SuggestionController',
                controllerAs: 'vm'
            })
            .otherwise({
                redirectTo: '/'
            });
    }
}());
