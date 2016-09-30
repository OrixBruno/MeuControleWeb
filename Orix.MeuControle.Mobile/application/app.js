var app = angular.module("MEUCONTROLE", ['ionic', 'ngRoute', 'ngStorage'])
    .config(function ($routeProvider) {
        $routeProvider.when('/', { templateUrl: 'application/views/home/home.html', controller: 'homeController' })
                      .when('/login', { templateUrl: 'application/views/login/login.html', controller: 'loginController' })
                      .when('/surdo/listar', { templateUrl: 'application/views/surdo/listar.html', controller: 'surdoController' })
        $routeProvider.otherwise({ redirectTo: "/" });
    });

function AuthService($http, $localStorage, $q) {
    return {
        getToken: function () {
            return $localStorage.token;
        },
        setToken: function (token) {
            $localStorage.token = token;
        },
        signin: function (data) {
            $http({
                method: 'POST',
                url: 'http://www.apiprojetos.somee.com/token',
                data: data,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                }
            }).success(function (data, status, headers, config) {
                $localStorage.token = data.access_token;
                return status;

            }).error(function (data, status, headers, config) {
                
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
function AuthInterceptor($location, AuthService, $q) {
    return {
        request: function (config) {
            config.headers = config.headers || {};
            if (AuthService.getToken) {
                config.headers['Authorization'] = 'Bearer ' + AuthService.getToken;
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