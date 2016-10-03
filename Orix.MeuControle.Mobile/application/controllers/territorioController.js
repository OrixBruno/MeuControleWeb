app.controller("territorioController",function ($scope,$location, territorioService) {
$scope.territorios = [{
  ID: 0,
  Nome: ''
}];

	if ($location.path() == '/territorio/listar') {
		$scope.territorio = territorioService.Listar()
			.success(function (response, status) {
				if (status == 200) {
					$scope.territorios = response;
				}
			})
			.error(function (response, status) {
				
			});
	}

});