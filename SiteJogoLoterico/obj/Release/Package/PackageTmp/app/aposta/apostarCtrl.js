appModule.controller("apostarCtrl", function ($scope, $window, $timeout, invokerApostas) {


    /*Possibilidades iniciais*/
    $scope.bolasRepete = [0, 1, 2, 3, 4, 5];
    $scope.qtdNumerosAposta = [6, 7, 8, 9, 10, 11];
    $scope.limiteQtdSelecionada = 6;
    $scope.bolas = [];
    $scope.ZERO = 0;
    $scope.bolaSelecionada = [];
    $scope.conjuntoApostas = [];
    $scope.nroUnicoAposta = 1;
   
    $scope.selecionaBola = function (bola) {
       
        alert(bola);
        if ($scope.bolaSelecionada==false) { 
            $scope.jogo = { color: '#FFF', background: '#000' };
            $scope.bolaSelecionada = true;
        } else if ($scope.bolaSelecionada==true) {
            $scope.jogo = { color: '#000', background: '#fff' };
            $scope.bolaSelecionada = false;
        }
       

    };
    $scope.selecionaQtd = function (qtd) {

        //*Cria os campos para digitar o valor*/
        $scope.limiteQtdSelecionada = qtd;
        $scope.bolasRepete = [];
        $scope.bolas = [];
        for (var i = 0; i < qtd; i++) {
           $scope.bolasRepete[i] = i;
         }
    };


    $scope.incluiSurpresinha = function () {
        var parametros = {
            "idConcurso": 1,
            "qtdNumeros": $scope.limiteQtdSelecionada
        };

        invokerApostas.addSurpresinha(parametros).then(function successCallback(response) {

            $scope.apostasRealizadas = response.data;

        }, function errorCallback(response) {
            $scope.apostasRealizadas = response.data;
            alert("Erro");
            console.error('Error occurred:', response.status, response.data);

        });
    };

    $scope.incluiAposta = function () {
        var parametros = {
            "$$hashKey": "object:"+$scope.nroUnicoAposta.toString(),
            "idAposta": $scope.nroUnicoAposta,
            "idConcurso": 1,
            "numeros": $scope.bolas,
            "qtdNumeros": $scope.limiteQtdSelecionada,
            "tipo": "MegaSena",
            "dataHora": "2018-09-05T05:31:44.5302523-03:00",
            "corConcurso": "#0b8043",
            "dataHoraFormatada": "05/09/2018 05:31:44"
        };

        $scope.nroUnicoAposta++;
      //  $scope.conjuntoApostas = parametros;

        $scope.conjuntoApostas.push(parametros); 

        /*Valida seleção de bolas*/
        var existeRepetidos = false;
        var existeForaRange = false;
        for (var i = 0; i < $scope.bolas.length; i++) {
            for (var j = 0; j < $scope.bolas.length; j++) 
                if ($scope.bolas[i] == $scope.bolas[j] && i != j) 
                    existeRepetidos = true;

            /*Verifica se está dentro do range permitido*/
            if ($scope.bolas[i] > 60 || $scope.bolas[i] < 1) 
                existeForaRange = true;
        }

        if (existeRepetidos || existeForaRange || $scope.bolas.length < ($scope.limiteQtdSelecionada-1)) {

            if (existeRepetidos) 
                alert("Não é permitido criar uma aposta com números repetidos, revise o formulário.");
            
            if (existeForaRange)
                alert("Selecione um numero de 1 a 60");

            if ($scope.bolas.length < ($scope.limiteQtdSelecionada - 1))
                alert("Preencha os "+($scope.limiteQtdSelecionada)+" campos numericos");
         
        } else {

            invokerApostas.addAposta(parametros).then(function successCallback(response) {
               // $scope.apostasRealizadas = $scope.conjuntoApostasArray;

                console.log(response.data);
                console.log($scope.conjuntoApostas);
                $scope.apostasRealizadas = response.data;
              //  $scope.conjuntoApostasNovo = response.data;

            }, function errorCallback(response) {
               // $scope.apostasRealizadas = response.data;
               // $scope.apostasListadas = response.data;
               // console.log(response.data);
                alert("Erro");
                console.error('Error occurred:', response.status, response.data);

            });

           
        }
    };

});
