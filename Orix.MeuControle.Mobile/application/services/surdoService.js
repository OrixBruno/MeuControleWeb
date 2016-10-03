app.service("surdoService",function ($http) {
	var urlService = "http://www.apiprojetos.somee.com/api/v1/";
	var urlLocal = "http://localhost:4644/api/v1/";
	
	this.Lista = function () {
		return $http({
			url:urlLocal+"Surdo",
            method: "GET"
		});
	},

	this.BuscaPorNome = function (nome) {
		return	$http({
			url: urlLocal+"Surdo?nome="+nome,
			method: "GET"
		});
	}
});