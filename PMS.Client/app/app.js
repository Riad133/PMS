/// <reference path="error_Page.html" />
/// <reference path="welcomeView.html" />

(function() {
    "use strict";
    var app = angular.module("productManagement",
                             ["common.services",
                                 "ui.router",
                                 "ui.mask",
                                 "ngResource",
                                 "ui.bootstrap"
                              
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
                    controller: "ProductListViewCtrl as vm",
                    resolve: {
                        productResource: "productResource",
                        product: function(productResource) {


                            return productResource.query().$promise;
                        }

                    }
                })
            .state("home",
                {
                    url: "/",
                    templateUrl: "app/welcomeView.html"
                })
            .state("productDetail",
                {
                    url: "/products/detail/:productId",
                    templateUrl: "app/products/productDetailView.html",
                    controller: "ProductDetailCtrl as vm",
                    resolve:
                    {
                        productResource: "productResource",
                        product: function(productResource, $stateParams, $state) {
                            var productId = $stateParams.productId;

                            return productResource.get({ id: productId },
                                function(data) {
                                    return{ product: data };
                                },
                                function(response) {
                                    var error = response.statusText + "</br>";
                                    if (response.data.exceptionMessage) {
                                        error += response.data.exceptionMesage;
                                    }
                                   
                                    bootbox.alert({
                                        title:"Error",
                                        message: "</br>" + error,
                                        className: 'bb-alternate-modal'
                                    });
                                   // bootbox.alert("Error Occure " + error);
                                    //$state.go('error', { error: error });
                                }).$promise;
                        }

                    }

                })
            .state("productEdit",
                {
                    abstract: true,
                    url: "/products/edit/:productId",
                    templateUrl: "app/products/productEditView/productEditView.html",
                    controller: "ProductEditCtrl as vm",
                    resolve:
                    {
                        productResource: "productResource",
                        product: function (productResource, $stateParams, $state) {
                            var productId = $stateParams.productId;

                            return productResource.get({ id: productId },
                                function(data) {
                                    return {product:data };
                                },
                                function(response) {
                                    var error = response.statusText;
                                    //if (response.data.modelState) {
                                    //    for (var key in response.data.modelState) {
                                    //        error += response.data.modelState[key] + "</br>";
                                    //    }
                                    //}
                                    bootbox.alert({
                                        title: "Error",
                                        message: "</br>" + error,
                                        className: 'bb-alternate-modal'
                                    });
                                    //alert(error);
                                    //$state.go('error', { error: error });
                                }
                                ).$promise;
                        }

                    }
                })
            .state("productEdit.info",
                {
                    url: "/info",
                    templateUrl: "app/products/productEditView/productEditInfoView.html"
                })
            .state("productEdit.price",
                {
                    url: "/price",
                    templateUrl: "app/products/productEditView/productEditPriceView.html"
                })
            .state("productEdit.tags",
                {
                    url: "/tags",
                    templateUrl: "app/products/productEditView/productEditTagsView.html"
                })
            .state('error',
                {
                    url: "/error:error",
                    templateUrl: 'app/error_Page.html',
                    controller: 'ErrorCtrl as vm',
                    
                    resolve: {
                        error: [
                            '$stateParams', function ($stateParams) {
                                var data = $stateParams.error;
                                return data;
                            }
                        ]
                    }
                });
    }]);

}());