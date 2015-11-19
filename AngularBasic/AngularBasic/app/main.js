(function () {
    'use strict';

    angular.module('wardenapp',['ngRoute'])
      .config(function ($routeProvider) {
          $routeProvider.when('/', { 
              templateUrl: '/pages/home.html' 
          })
          .when('/about', {
              templateUrl: '/pages/about.html'
          })
           .when('/contact', {
               templateUrl: '/pages/contact.html'
           })
    });
    angular.module('wardenapp').controller('WardenController', function () {
        var vm = this;
        vm.status = 'fire';
        this.update = function () {
            
            vm.status = 'fure';
        };
    });
})();