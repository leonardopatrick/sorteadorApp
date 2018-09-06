appModule.controller("listarCtrl", function ($scope, $window, invokerApostas) {

    //$window.
    //Exemplo enviando dados controler
    //myFactory.setMSG("Tutlane (with Factory)");

   
        invokerApostas.getApostas().then(function successCallback(response) {
            $scope.apostasListadas = response.data;
        }, function errorCallback(response) {

            $scope.apostasListadas = response.data;

            alert(response.status);
            console.error('Error occurred:', response.status, response.data);

        });

  

});