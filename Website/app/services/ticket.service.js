angular
    .module('earlybirds')
    .factory('ticketService', ticketService);

ticketService.$inject = ['$http'];

function ticketService($http) {
    var service = {
        data: {
            tickets: [],
            ticket: {},
            client: {}
        },
        getTickets: getTickets,
        deleteTicket: deleteTicket,
        updateTicket: updateTicket,
        getClient: getClient,
        getTicket: getTicket
    };
    return service;

    function getTickets() {
        return $http
            .get('http://localhost:2001/tickets')
            .then(function (response) {
                service.data.tickets = response.data;
                return response.data;
            });
    }

    function getTicket(id) {
        return $http
            .get('http://localhost:2001/tickets/' + id)
            .then(function (response) {
                service.data.ticket = response.data;
                return response.data;
            });
    }

    function deleteTicket(ticket) {
        return $http
            .delete('http://localhost:2001/tickets/' + ticket.id)
            .then(function (response) {
                service.getTickets();
                service.data.ticket = {};
                service.data.client = {};

                return response.data;
            })
    }

    function updateTicket(ticket) {
        return $http
            .put('http://localhost:2001/tickets/' + ticket.id, ticket)
            .then(function (response) {
                service.data.ticket = response.data;
                service.getTickets();
                return response.data;
            });
    }

    function getClient(clientId) {
        return $http
            .get('http://localhost:2001/clients/' + clientId)
            .then(function (response) {
                service.data.client = response.data;
                return response.data;
            });
    }
}