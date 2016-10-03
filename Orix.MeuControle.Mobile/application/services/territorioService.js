app.service("territorioService",function ($http) {
	var urlService = "http://www.apiprojetos.somee.com/api/v1/";
	var urlLocal = "http://localhost:4644/api/v1/";
	
		this.Listar = function () {
		return $http({
			url:urlLocal+"Territorio",
            method: "GET"
		});
	}
});