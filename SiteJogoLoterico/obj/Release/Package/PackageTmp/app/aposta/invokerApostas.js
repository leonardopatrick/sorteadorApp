appModule.factory('invokerApostas', function ($http) {


    var baseUrl ='http://localhost/appApi'
    var displayFact;
    var displayFactDois = [{ "idAposta": 1, "idConcurso": 100 }];

    var addMSG = function (msg) {

        displayFact = ' Hi Guest, Welcome to ' + msg;

    }

    return {

        setMSG: function (msg) {

            addMSG(msg);

        },

        getMSG: function () {

            return displayFact;

        },
         getMSG2: function () {

             return displayFactDois;

        },

         getApostas: function () {

             return $http({
                 method: 'get',
                 url: baseUrl+'/api/JogoLoterico/getApostas',
                 headers: {
                     'Content-type': 'application/json; charset=utf-8', 'crossDomain': 'true',
                     'xhrFields': '{ withCredentials: true }'
                 }
             });
        },

        addAposta: function (parametros) {

            return $http({
                method: 'POST', url: baseUrl + '/api/JogoLoterico/addAposta',
                data: parametros,
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        },

        addSurpresinha: function (parametros) {

            return $http({
                method: 'POST', url: baseUrl + '/api/JogoLoterico/geraSuprersinha',
                data: parametros,
                headers: { 'Content-Type': 'application/json;charset=utf-8' }
            });
        },

    };

});