app.controller('loginController', function ($scope, $ionicLoading, AuthService, $timeout, $location) {
    $ionicLoading.show({
        template: "Aguarde..."
    });
    $scope.usuario = {}

    $scope.login = function () {
        var status = AuthService.signin($scope.usuario)
        if (status == 200) {
            $location.path("/login");
        }        
    }


    $ionicLoading.hide();
});