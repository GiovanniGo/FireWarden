(function() {
    'use strict';

    angular.module('carsApp')
        .controller('CarsQueryController', CarsQueryController)
        .controller('CarsAddController', CarsAddController)
        .controller('CarsEditController', CarsEditController)
        .controller('CarsDeleteController', CarsDeleteController);


    CarsQueryController.$inject = ['$scope', 'Car'];
    function CarsQueryController($scope, Car) {
        $scope.cars = Car.query();
    }

    CarsAddController.$inject = ['$scope', '$location', 'Car'];
    function CarsAddController($scope, $location, Car) {
        $scope.car = new Car();
        $scope.add = function() {
            $scope.car.$save(function() {
                $location.path('/');
            });
        };
    }

    CarsEditController.$inject = ['$scope', '$routeParams', '$location', 'Car'];
    function CarsEditController($scope, $routeParams, $location, Car) {
        $scope.car = Car.get({
            id: $routeParams.id
        });
        $scope.edit = function() {
            $scope.car.$save(function() {
                $location.path('/');
            });
        };
    }

    CarsDeleteController.$inject = ['$scope', '$routeParams', '$location', 'Car'];
    function CarsDeleteController($scope, $routeParams, $location, Car) {
        $scope.car = Car.get({
            id: $routeParams.id
        });
        $scope.remove = function() {
            $scope.car.$remove({
                id: $scope.car.Id
            }, function() {
                $location.path('/');
            });
        };
    }

})();
