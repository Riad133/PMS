(function() {
    "use strict";
    angular.module("productManagement")
        .controller("ProductListViewCtrl",
        ["productResource",
            ProductListViewCtrl]);

    function ProductListViewCtrl(productResource) {
        var vm = this;
        vm.showImage = false;

        productResource.query(function (data) {
            vm.products = data;
        });

        vm.toggleImage = function() {
            vm.showImage = ! vm.showImage;
        };
    }

}());