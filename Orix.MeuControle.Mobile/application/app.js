var app = angular.module("MEUCONTROLE", ['ionic', 'ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider.when("/", { templateUrl: 'application/views/home', controller: 'homeController' });

    $routeProvider.otherwise({ redirectTo: "/" });
});