(function () {
    var app = angular.module('home', []);

    app.controller('MessageController', function () {
        this.message = msg;
    });

    var msg = {
        about: "Your application description page.",
        contact: "Your contact page.",
    }
})();