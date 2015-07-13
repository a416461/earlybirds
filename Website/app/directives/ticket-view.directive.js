(function () {
    'use strict';

    angular
        .module('earlybirds')
        .directive('ticketView', ticketView);

    function ticketView() {
        var directive = {
            restrict: 'E',
            templateUrl: '/app/directives/ticket-view.html',
            scope: {
                ticket: '=',
                client: '=',
            },
            controller: ticketViewController,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    ticketViewController.$inject = ['ticketService'];

    function ticketViewController(ticketService) {
        var vm = this;
        vm.upVoteSession = upVoteSession;
        vm.downVoteSession = downVoteSession;
        vm.showSolutionForm = showSolutionForm;
        vm.solutionSubmit = solutionSubmit;
        vm.claimTicket = claimTicket;
        vm.deleteTicket = deleteTicket;
        vm.showSolution = false;

        function upVoteSession() {
            vm.ticket.priority++;
            ticketService.updateTicket(vm.ticket).then(function () {
                ticketService.getTickets();
            })
        }

        function downVoteSession() {
            vm.ticket.priority--;
            ticketService.updateTicket(vm.ticket).then(function () {
                ticketService.getTickets();
            });
        }

        function showSolutionForm() {
            vm.showSolution = true;
        }

        function solutionSubmit() {
            vm.ticket.status = 'Processed';
            ticketService.updateTicket(vm.ticket).then(function () {
                ticketService.getTickets();
            });
            vm.showSolution = false;
        }

        function claimTicket() {
            vm.ticket.status = 'Processing';
            ticketService.updateTicket(vm.ticket);
        }

        function deleteTicket() {
            ticketService.deleteTicket(vm.ticket);
            //vm.ticketDeleted && vm.ticketDeleted(vm.ticket);
        }
    }
}());