(function() {
    'use strict';

    angular.module('carsServices', ['ngResource']).factory('Car', Car);

    Car.$inject = ['$resource'];

    function Car($resource) {
        return $resource('/api/cars/:id');
    }
})();
