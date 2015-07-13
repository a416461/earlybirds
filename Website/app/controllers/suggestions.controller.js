(function () {
    'use strict';

    angular
        .module('earlybirds')
            .controller("SuggestionController", ["$scope", "$http","ticketService", SuggestionController]);

    function SuggestionController($scope, $http, ticketService) {
        $scope.client = {
            name: '',
            gender: 1,
            mailAddress: '',
            userName: '',
            occupation: ''
        }

        $scope.ticket = {
            clientId: 1,
            title: '',
            description: '',
            ticketType: '',
        }

        $scope.submit = submit;

        function submit() {
            var onTicketComplete = function (response) {
                $scope.tickets = response.data;
            };

            var onError = function (reason) {
                $scope.error = "No tickets exists this moment";
            };

            $http.post("http://localhost:2001/clients", $scope.client)
                .success(function (data) {
                    $scope.ticket.clientId = data.id;

                    $http.post("http://localhost:2001/tickets", $scope.ticket)
                    .success(function (data, status, headers, config) {
                        ticketService.getTickets();
                    }).
                    error(function (data, status, headers, config) {
                        $scope.error = "unable to post new ticket"
                    });
                })
                .error(function (data, status, headers, config) {
                    $scope.error = "unable to post new client"
                });
        }
    };
}());
