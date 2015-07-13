(function () {
    'use strict';

    angular
        .module('earlybirds')
        .directive('ticketList', ticketList);

    function ticketList() {
        var directive = {
            restrict: 'E',
            templateUrl: '/app/directives/ticket-list.html',
            scope: {
                tickets: '='
            },
            controller: ticketListController,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    function ticketListController() {

    }
}());