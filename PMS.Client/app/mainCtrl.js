
(function () {
    "use strict";
    angular.module("productManagement")
        .controller("MainCtrl",
            ["userAccount", "currentUser","$state","$window",
               
             MainCtrl]);

    function MainCtrl(userAccount, currentUser, $state, $window) {
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
        
        vm.logOut = function () {
            console.log("home");
          
            
            vm.userData = null;
            $window.location.reload();
            currentUser.removeProfile();
            $state.go("home");

    
            
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
            $window.location.reload();
        }


        vm.isLoggedIn = function ()
        {
            return currentUser.getProfile().isLoggedIn;
        };
    }
}());