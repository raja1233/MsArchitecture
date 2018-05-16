(function () {
    'use strict';

    angular.module('Park', ['common.core', 'common.ui','ngSanitize','twitterApp.services'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
       
        var baseUrl = "";
        if (window.location.pathname.length > 1)
            baseUrl = "/" + window.location.pathname.replace(/\//g, '') + "/";
        $routeProvider
            .when("/", {
                templateUrl: baseUrl + "scripts/spa/home/index.html",
                controller: "indexCtrl"
            }) 
            .when("/create", {
                templateUrl: "scripts/spa/home/create.html",
                controller: "createCtrl"
            })
            .otherwise({ redirectTo: "/" }); 
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        $rootScope.applicationBaseUrl = window.location.pathname;
        $rootScope.autocompleteData = {
        };
        $rootScope.reservations = {
        };
        $rootScope.reservations.transaction = {};
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });

            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    media: {}
                }
            }); 
            $(document).on("blur", ":input[data-role=combobox]", function (e) { 
                var combobox = $(this).data("kendoComboBox");
                if (combobox != undefined) {
                    if (combobox.selectedIndex == -1 || combobox.input.val().trim() == "") {
                        combobox.input.val('');
                        combobox.selectedIndex = -1;
                        combobox.value(null);
                    }
                }
            });
        }); 
    } 
})();