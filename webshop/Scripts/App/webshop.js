
'use strict';
var webshop = angular.module('webshop', []);

webshop.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
