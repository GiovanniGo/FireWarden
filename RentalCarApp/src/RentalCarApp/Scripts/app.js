(function() {
    'use strict';

    config.$inject = ['$routeProvider', '$locationProvider'];
    angular.module('rentalCarApp', ['ngRoute', 'appResources']).config(config);
    
    function config($routeProvider, $locationProvider) {
        $routeProvider.when('/', {
                templateUrl: '/templates/pages/welcome.html',
            })
            .when('/cars/browse', {
                templateUrl: '/templates/pages/car/list.html',
                controller: 'CarsQueryController',
                controllerAs: 'CarsQueryCtrl'
            })
            .when('/cars/add', {
                templateUrl: '/templates/pages/car/add.html',
                controller: 'CarsAddController',
                controllerAs: 'CarsAddCtrl'
            })
            //.when('/cars/edit/:id', {
            //    templateUrl: '/templates/pages/car/edit.html',
            //    controller: 'CarsEditController'
            //})
            .otherwise({
                redirectTo: "/"
            });
            

        $locationProvider.html5Mode(true);
    }

})();
