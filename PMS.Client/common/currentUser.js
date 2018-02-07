(function() {
    "use strict";
    angular.module("common.services")
        .factory("currentUser", 
            currentUser);

    function currentUser() {
        var Profile = {
            isLoggedIn: false,
            username: "",
            token: ""
        };
        var setProfile = function(username, token) {
            Profile.username = username;
            Profile.isLoggedIn = true;
            Profile.token = token;
            

            // Put the object into storage
            localStorage.setItem('profile', JSON.stringify(Profile));

            // Retrieve the object from storage
            var retrievedObject = localStorage.getItem('profile');

            console.log('retrievedObject: ', JSON.parse(retrievedObject));
        };
        var removeProfile = function () {
           
            Profile.username = "";
            Profile.isLoggedIn = false;
            Profile.token = null;
            localStorage.removeItem('profile');
            localStorage.setItem('profile', JSON.stringify(Profile));
            var profile = JSON.parse(retrievedObject);
            console.log('retrievedObject: ', profile);
            $location.path('/');
            $location.reload(true);

        };
        var getProfile = function () {
            var retrievedObject = localStorage.getItem('profile');
            var profile = JSON.parse(retrievedObject);
            console.log('retrievedObject: ', profile);
            return profile;
        };
        return {
            setProfile: setProfile,
            getProfile: getProfile,
            removeProfile: removeProfile
        }

    }
})();