
(function () {
    "use strict";
    angular.module("productManagement")
        .controller("MainCtrl",
            ["userAccount", "currentUser",
               
             MainCtrl]);

    function MainCtrl(userAccount, currentUser) {
        var vm = this;
        vm.message = "";
        vm.userData = {
            userName: "",
            email: '',
            password: '',
            confirmPassword:''
        }
        vm.registerUser = function() {
            
        }
        vm.login = function() {
            vm.userData.grant_type = "password";
            vm.userData.userName = vm.userData.email;
            userAccount.login.loginUser(vm.userData,
                function(data) {
                    
                    vm.message = '';
                    vm.password = '';

                    currentUser.setProfile(vm.userData.userName, data.access_token);
                    console.log(currentUser.getProfile.token);
                },
                function(response) {
                    vm.password = '';
                   
                    vm.message = response.statusText + "\r\n";
                    if (response.data.exceptionMessage) {
                        vm.message += response.data.exceptionMessage;
                    if (response.data.error) {
                        vm.message = + response.data.error;
                    }
                    }
                });
        }


        vm.isLoggedIn = function ()
        {
            return currentUser.getProfile().isLoggedIn;
        };
    }
}());