appModule.controller("sorteioCtrl", function ($scope, $window, $timeout, invokerApostas) {

    $scope.sortear = function () {
        var parametros = {
            "idConcurso": 1,
            "qtdNumeros": 6
        };

        invokerApostas.addSorteio(parametros).then(function successCallback(response) {

         $scope.numerosSorteados = response.data;

        }, function errorCallback(response) {
            $scope.numerosSorteados = response.data;
            alert("Erro");
            console.error('Error occurred:', response.status, response.data);

        });
    };

});
