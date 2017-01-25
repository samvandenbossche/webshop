
//(function () {
'use strict';

angular.module('webshop').factory('CartFactory', ['$http', CartFactory]);

function CartFactory($http) {

    function GetCartItems() {
        return $http.get('/Cart/GetCartItems');
    }

    function GetCartCount() {
        return $http.get('/Cart/GetCartCount')
    }

    function GetCartTotal() {
        return $http.get('/Cart/getCartTotal')
    }

    var service = {
        getCartItems: GetCartItems,
        getCartCount: GetCartCount,
        getCartTotal: GetCartTotal
    };

    return service;
}

//})();