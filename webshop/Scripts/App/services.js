
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

    function ChangeQuantity(productId, quantity) {
        var result = $http({
            method: 'POST',
            url: '/Cart/ChangeQuantity',
            params: {
                productId: productId,
                quantity: quantity
            }
        });
        return result;

    }

    function DeleteItem(productId) {
        var result = $http({
            method: 'POST',
            url: '/Cart/DeleteItem',
            params: {
                productId: productId
            }
        });
        return result;
    }

    function ClearCart() {
        var result = $http({
            method: 'POST',
            url: '/Cart/ClearCart',
        });
        return result;
    }

    var service = {
        getCartItems: GetCartItems,
        getCartCount: GetCartCount,
        getCartTotal: GetCartTotal,
        changeQuantity: ChangeQuantity,
        deleteItem: DeleteItem,
        clearCart: ClearCart

    };

    return service;
}
