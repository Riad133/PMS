(function () {
    "using strict";
    angular.module("common.services")
        .factory("productResource",
            [
                "$resource",
                "appSettings",
                "currentUser",
                productResource
            ]);

    function productResource($resource, appSettings, currentUser) {
        return $resource(appSettings.serverPath + "/api/products/:id",null,
            {
                'update': {
                    method:'PUT',
                     headers: {'Authorization':'Bearer '+currentUser.getProfile().token}
                },
                'save': {
                    
                     headers: {'Authorization':'Bearer '+currentUser.getProfile().token}
                },
                'get': {

                    headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
                }
            });
    }
}());