app.controller("surdoController",function ($scope,surdoService,$ionicPopup, $location, AuthService, $routeParams) {
	$scope.nome='';
	$scope.surdosLista={};
	$scope.surdoCorrente={
	  Nome: '',
	  Genero: '',
	  Idade: 0,
	  Rua: '',
	  Numero: 0,
	  Bairro: '',
	  Observacao: '',
	  ID_Mapa: 0
	};

	if ($location.path() == '/surdo/listar') {
		//var response = surdoService.Lista();
	}
	if ($location.path() == '/surdo/dados/:Codigo') {
		//$location.path('/'+$routeParams.Codigo);
		$ionicPopup.alert({
                         title: 'Parametros',
                         template: 'Parametros: '+$routeParams.Codigo
        });
	}

	$scope.BuscaPorNome = function () {
		surdoService.BuscaPorNome($scope.nome);
	}
});