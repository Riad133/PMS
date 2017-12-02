
(function () {
    "use strict";
    angular.module("productManagement")
        .controller("ProductDetailCtrl",
            ["product", ProductDetailCtrl]);

    function ProductDetailCtrl(product) {
       var  vm = this;
        vm.product = product;
        console.log(product);

    }
}());