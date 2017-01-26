
//(function () {
'use strict';

angular.module('webshop').controller('CartController', ['$scope', 'CartFactory', cartController]);
angular.module('webshop').controller('ProductsController', ['$scope', '$http', ProductsController]);

function cartController($scope, CartFactory) {
    loadCart($scope, CartFactory);
}

function loadCart($scope, CartFactory) {
    CartFactory.getCartItems().then(function (data) {
        $scope.cart = data;
        getCartCount($scope, CartFactory);
        getCartTotal($scope, CartFactory);
        $scope.cart.changeQuantity =
            function (productId, quantity) {
                if (quantity < 1) {
                    quantity = 1;
                }
                CartFactory.changeQuantity(productId, quantity).then(function (response) {
                    getCartTotal($scope, CartFactory);
                }, function (error) { console.log(error) });
            };
        $scope.cart.deleteItem =
            function (productId, item) {
                CartFactory.deleteItem(productId).then(function (response) {

                    var index = $scope.cart.data.indexOf(item);
                    $scope.cart.data.splice(index, 1);
                    getCartTotal($scope, CartFactory);
                    getCartCount($scope, CartFactory);
                }, function (error) { console.log(error) });
            };
        $scope.cart.clearCart =
            function () {
                CartFactory.clearCart().then(function (response) {
                    $scope.cart.data = [];
                    getCartTotal($scope, CartFactory);
                    getCartCount($scope, CartFactory);
                }, function (error) { console.log(error) });
            };

    }, function (error) { console.log(error) });
}

function getCartCount($scope, CartFactory) {
    CartFactory.getCartCount().then(function (data) {
        $scope.cart.CartCount = data.data;
    },
    function (error) {
        console.log(error)
    });
}

function getCartTotal($scope, CartFactory) {
    CartFactory.getCartTotal().then(function (data) {
        $scope.cart.CartTotal = data.data;
    },
    function (error) {
        console.log(error)
    });
}

function ProductsController($scope, $http) {
    $http(
        {
            method: "GET",
            url: "/products/GetProducts"
        }).then(function mySucces(items) {
            $scope.shopList = angular.fromJson(items.data);
        }, function myError(response) {
            $scope.status = 'Unable to load product data: ' + error.message;
            console.log($scope.status);
        });
}
//})();

