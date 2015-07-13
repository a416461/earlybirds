(function () {
    'use strict';

    angular
        .module('earlybirds')
        .controller('TicketsController', TicketsController);

    TicketsController.$inject = ['$routeParams', 'ticketService'];

    function TicketsController($routeParams, ticketService) {
        var vm = this;
        vm.tickets = [];
        vm.ticket = {};
        vm.client = {};
        vm.ticketSortOrder = 'id';
        vm.error = null;
        vm.state = 0;

        vm.swipeLeft = function () {
            console.log('swipe left');
            if (vm.state > -1) {
                vm.state--; console.log(vm.state)
            }
        };

        vm.swipeRight = function () {
            console.log('swipe right');
            if (vm.state < 1) {
                vm.state++; console.log(vm.state)
            }
        };

        activate();

        function activate() {
            vm.data = ticketService.data;

            ticketService.getTickets().then(function () {
                if ($routeParams.ticketId) {
                    ticketService.getTicket($routeParams.ticketId).then(function () {
                        ticketService.getClient(ticketService.data.ticket.clientId);
                    });
                }
            }, onError);      
        }

        function onError() {
            vm.error = 'No tickets exists this moment';
        }
    }
}());
