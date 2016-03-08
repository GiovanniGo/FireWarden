(function() {
    'use strict';

    angular.module('rentalCarApp')
        .controller('CarsQueryController', CarsQueryController)
        .controller('CarsAddController', CarsAddController);
        //.controller('CarsEditController', CarsEditController)
        //.controller('CarsDeleteController', CarsDeleteController);


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
        this.add = function () {
            this.car.$save(function () {
                $location.path('/cars/browse');
            });
        };
    }

    //CarsEditController.$inject = ['$scope', '$routeParams', '$location', 'Car'];
    //function CarsEditController($scope, $routeParams, $location, Car) {
    //    $scope.car = Car.get({
    //        id: $routeParams.id
    //    });
    //    $scope.edit = function() {
    //        $scope.car.$save(function() {
    //            $location.path('/');
    //        });
    //    };
    //}

})();
