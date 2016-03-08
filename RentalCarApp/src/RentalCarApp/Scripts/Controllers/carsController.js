(function() {
    'use strict';

    angular.module('rentalCarApp')
        .controller('CarsQueryController', CarsQueryController)
        .controller('CarsAddController', CarsAddController)
        .controller('CarsEditController', CarsEditController);


    CarsQueryController.$inject = ['$route','carsResource'];
    function CarsQueryController($route, carsResource) {
        this.cars = carsResource.query();
        this.remove = function (carId) {
            var car = carsResource.get({
                id: carId
            });
            car.$remove({
                id: carId
            }, function () {
                $route.reload();
            });
        };
    }

    CarsAddController.$inject = ['$location', 'carsResource'];
    function CarsAddController($location, carsResource) {
        this.car = new carsResource();
        this.submit = function () {
            this.car.$save(function () {
                $location.path('/cars/browse');
            });
        };
    }

    CarsEditController.$inject = ['$routeParams', '$location', 'carsResource'];
    function CarsEditController($routeParams, $location, carsResource) {
        this.car = carsResource.get({
            id: $routeParams.id
        });
        this.submit = function() {
            this.car.$save(function() {
                $location.path('/cars/browse');
            });
        };
    }

})();
