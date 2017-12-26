
(function () {
    "use strict";
    angular.module("productManagement")
        .controller("ProductDetailCtrl",
            ["product", ProductDetailCtrl]);

    function ProductDetailCtrl(product) {
       var  vm = this;
        //
        //vm.product = product;
        //product.then(function(data) {
        //        vm.product = data;
        //    },
        //    function(response) {
        //        console.log(response.statusText);
        //    });

       

        vm.product = product;
    }
}());