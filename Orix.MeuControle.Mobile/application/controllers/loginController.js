app.controller('loginController', function ($scope, $ionicLoading, AuthService, $timeout, $location) {
    $ionicLoading.show({
        template: "Aguarde..."
    });
    $scope.usuario = {}

    $scope.login = function () {
        AuthService.signin($scope.usuario)
        .success(function (token) {
            AuthService.setToken(token);
            $location.path("/home");
        })
        .error(function () {
            $timeout(function () {
                $ionicLoading.hide();

                $ionicPopup.alert({
                    title: "Error",
                    template: "Usuário ou senha inválidos!"
                });
            }, 2000);

            $location.path("/login");
        });
    }


    $ionicLoading.hide();
});