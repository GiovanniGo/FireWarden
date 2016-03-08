(function() {
    'use strict';

    angular.module('appResources', ['ngResource']).factory('carsResource', carsResource);

    carsResource.$inject = ['$resource'];

    function carsResource($resource) {
        return $resource('/api/cars/:id');
    }
})();
