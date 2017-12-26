(function() {
    "use strict";
    angular.module("productManagement")
        .controller("ProductListViewCtrl",
        ["product",
            ProductListViewCtrl]);

    function ProductListViewCtrl(product) {
        var vm = this;
        vm.showImage = false;
        vm.products = product;
       
        vm.toggleImage = function() {
            vm.showImage = ! vm.showImage;
        };
    }

}());