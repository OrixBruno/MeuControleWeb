app.service("surdoService",function ($http) {
	this.Lista = function () {
		return $http({
			url:".../api/v1/amigo",
            method: "GET"
		});
	}
});