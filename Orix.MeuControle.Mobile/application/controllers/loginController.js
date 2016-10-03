app.controller('loginController', function ($scope, $ionicLoading, AuthService, $timeout,$ionicPopup) {

    $scope.usuario = {
        grant_type : 'password',
        username:'',
        password:''
    };

    $scope.login = function () {
        AuthService.signin($scope.usuario);  
    };


    $ionicLoading.hide();
});