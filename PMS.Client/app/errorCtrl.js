
    (function () {
        "use strict";
        angular.module("productManagement")
            .controller("ErrorCtrl",
                ["error", ErrorCtrl]);

        function ErrorCtrl(error) {
            var vm = this;
            vm.message = error;


            console.log(error + "\r\n");
            

        }
    }());
