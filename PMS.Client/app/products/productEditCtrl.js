(function () {
    "use strict";
    angular.module("productManagement")
        .controller("ProductEditCtrl",
            ["product","$filter","$state",
                ProductEditCtrl]);

    function ProductEditCtrl(product, $filter, $state) {
        var vm = this;
        vm.product = product;
        
        vm.product.releaseDate = new Date(vm.product.releaseDate);
         vm.product.releaseDate = $filter('date')(new Date(), "MMM dd, yyyy");

        vm.message = "Hello World";
        vm.openDatePicker = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();
            vm.opened = !vm.opened;
        }

        vm.submit = function (isvalid) {

            if (isvalid) {

                if (vm.product.productId !== 0) {
                    vm.product.$update({ id: vm.product.productId },function(data) {
                        if (data) {
                            bootbox.alert("Update Successfully");

                        }
                    }, function(response) {
                        var error = response.statusText + "</br>";
                        if (response.data.modelState) {
                            console.log("User define Exception message"+response.data.modelStatus);
                            for (var key in response.data.modelState) {
                                error += response.data.modelState[key] + "</br>";
                            }
                        }
                        if (response.data.exceptionMessage) {
                            error += response.data.exceptionMessage;
                        }
                        bootbox.alert(error);
                    });
                } else {
                    vm.product.$save(function(data) {
                        if (data) {
                            bootbox.alert({
                               
                                title: "Product Save",
                                message: "Save Successfully…",
                                callback: function() {
                                    $state.go("productList"); /* your callback code */
                                }
                            });
                        }
                    },
                    function(response) {
                        var error = response.statusText + "</br>";
                        if (response.data.modelState) {
                            console.log("User define Exception message" + response.data.modelStatus);
                            for (var key in response.data.modelState) {
                                error += response.data.modelState[key] + "</br>";
                            }
                        }
                        if (response.data.exceptionMessage) {
                            error += response.data.exceptionMessage;
                        }
                        bootbox.alert(error);
                    }
                    );
                }
            } else {
               bootbox.alert("Please Correct the Validation Error First!!");
            }
        }
        vm.cancel = function() {
            $state.go("productList");
        }
    }
   

}());