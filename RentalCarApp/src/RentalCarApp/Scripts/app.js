(function() {
    'use strict';

    config.$inject = ['$routeProvider', '$locationProvider'];
    angular.module('carsApp', ['ngRoute', 'carsServices']).config(config);

    function config($routeProvider, $locationProvider) {
        $routeProvider.when('/', {
                templateUrl: '/templates/pages/welcome.html',
            })
            .when('/cars/browse', {
                templateUrl: '/templates/pages/car/list.html',
                controller: 'CarsQueryController'
            })
            .when('/cars/add', {
                templateUrl: '/templates/pages/car/add.html',
                controller: 'CarsAddController'
            })
            .when('/cars/edit/:id', {
                templateUrl: '/templates/pages/car/edit.html',
                controller: 'CarsEditController'
            })
            .when('/cars/delete/:id', {
                templateUrl: '/templates/pages/car/delete.html',
                controller: 'CarsDeleteController'
            })
            .otherwise({
                redirectTo: "/"
            });
            

        $locationProvider.html5Mode(true);
    }

})();
