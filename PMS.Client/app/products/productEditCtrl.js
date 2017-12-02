(function () {
    "use strict";
    angular.module("productManagement")
        .controller("ProductEditCtrl",
            ["product", "$state",
                ProductEditCtrl]);

    function ProductEditCtrl(product, $state) {
        var vm = this;
        vm.product = product;
        vm.product.releaseDate = new  Date(vm.product.releaseDate);
        console.log(product);
    }

}());