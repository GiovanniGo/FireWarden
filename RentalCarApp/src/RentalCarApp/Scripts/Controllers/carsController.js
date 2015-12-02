(function() {
    'use strict';

    angular.module('carsApp')
        .controller('CarsQueryController', CarsQueryController)
        .controller('CarsAddController', CarsAddController);
        //.controller('CarsEditController', CarsEditController)
        //.controller('CarsDeleteController', CarsDeleteController);


    CarsQueryController.$inject = ['Car'];
    function CarsQueryController( Car) {
        this.cars = Car.query();
    }

    CarsAddController.$inject = ['$location', 'Car'];
    function CarsAddController( $location, Car) {
        this.car = new Car();
        this.add = function () {
            this.car.$save(function () {
                $location.path('/');
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

    //CarsDeleteController.$inject = ['$scope', '$routeParams', '$location', 'Car'];
    //function CarsDeleteController($scope, $routeParams, $location, Car) {
    //    $scope.car = Car.get({
    //        id: $routeParams.id
    //    });
    //    $scope.remove = function() {
    //        $scope.car.$remove({
    //            id: $scope.car.Id
    //        }, function() {
    //            $location.path('/');
    //        });
    //    };
    //}

})();
