/// <reference path="welcomeView.html" />

(function() {
    "use strict";
    var app = angular.module("productManagement",
                             ["common.services",
                                 "ui.router"
                              
                            ]);

    app.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {

        // default route
       // $qProvider.errorOnUnhandledRejections(false);
        $urlRouterProvider.otherwise("/");
        $stateProvider
            .state("productList",
                {
                    url: "/products",
                    templateUrl: "app/products/productListView.html",
                    controller: "ProductListViewCtrl as vm"
                })
            .state("home",
                {
                    url: "/",
                    templateUrl: "app/welcomeView.html"
                });


    }]);

}());