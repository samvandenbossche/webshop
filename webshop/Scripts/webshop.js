var webshop = angular.module('webshop', []);

webshop.controller('webshopController', function ($scope, WebshopService) {



    getProducts();

    function getProducts() {

        WebshopService.getProducts()

            .success(function (items) {

                $scope.products = items;

                console.log($scope.products);

            })

            .error(function (error) {

                $scope.status = 'Unable to load product data: ' + error.message;

                console.log($scope.status);

            });

    }

});



webshop.factory('WebshopService', ['$http', function ($http) {



    var WebshopService = {};

    WebshopService.getProducts = function () {
        return $http.get('/products/GetProducts');
    };

    return WebshopService;



}]);