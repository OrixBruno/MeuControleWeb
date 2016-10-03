var app = angular.module("MEUCONTROLE", ['ionic', 'ngRoute', 'ngStorage'])
    .config(function ($routeProvider) {
        $routeProvider.when('/', { templateUrl: 'application/views/home/home.html', controller: 'homeController' })
                      .when('/login', { templateUrl: 'application/views/login/login.html', controller: 'loginController', authorize:true})
                      .when('/surdo/listar', { templateUrl: 'application/views/surdo/listar.html', controller: 'surdoController' })
                      .when('/surdo/dados/:Codigo', { templateUrl: 'application/views/surdo/dados.html', controller: 'surdoController' })
                      .when('/territorio/listar', { templateUrl: 'application/views/territorio/listar.html', controller: 'territorioController' })
        $routeProvider.otherwise({ redirectTo: "/" });
    }); 

function AuthService($http, $localStorage, $q, $ionicPopup,$location) {
    return {
        getToken: function () {
            return $localStorage.token;
        },
        setToken: function (token) {
            $localStorage.token = token;
        },
        signin: function (data) {
            //http://www.apiprojetos.somee.com/token
            $http({
                method: 'POST',
                url: 'http://localhost:4644/token',
                data: data,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                }
            }).success(function (data, status, headers, config) {
                if (status == 200) {
                    $localStorage.token = data.access_token;
                    $ionicPopup.alert({
                         title: 'Token',
                         template: 'Token adicionado com sucesso.'
                    });
                    $location.path('/');
                };
            }).error(function (data, status, headers, config) {
                if (status == 503) {
                    $ionicPopup.alert({
                         title: 'Error',
                         template: 'Serviço indisponivel. Status: '+status
                    });
                }
            });
        },
        signup: function (data) {
            
        },
        logout: function (data) {
            delete $localStorage.token;
            $q.when;
        }
    }
}
function AuthInterceptor($localStorage, $location, AuthService, $q) {
    return {
        request: function (config) {
            config.headers = config.headers || {};
            if ($localStorage.token) {
                config.headers['Authorization'] = 'Bearer ' + $localStorage.token;
            }

            return config;
        },

        responseError: function (response) {
            if (response.status === 401 || response.status === 403) {
                $location.path('/signin');
            }

            //return $q.reject(response);
        }
    }
};



app.factory('AuthService', AuthService);
app.factory('AuthInterceptor', ['$q', '$location', AuthInterceptor]);
app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('AuthInterceptor');
});

app.run(function ($rootScope, $location, AuthService) {
    $rootScope.$on('$routeChangeStart', function (event, next, current) {
        if (next.authorize) {
            if (!AuthService.getToken) {
                /* Ugly way
                event.preventDefault();
                $location.path('/login');
                ========================== */

                $rootScope.$evalAsync(function () {
                    $location.path('/login');
                })
            }
        }
    });

});