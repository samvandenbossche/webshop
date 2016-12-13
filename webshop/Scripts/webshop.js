
var webshop = angular.module('webshop', []);
webshop.controller('webshopController', function ($scope, $http) {
    
    $http({
        method: "GET",
        url: "/products/GetProducts"
    }).then(function mySucces(items) {
        $scope.shopList = angular.fromJson(items.data);
    }, function myError(response) {
        $scope.status = 'Unable to load product data: ' + error.message;
        console.log($scope.status);
    });
});