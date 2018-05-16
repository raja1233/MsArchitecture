(function (app) {
    'use strict';

    app.controller('createCtrl', createCtrl);

    createCtrl.$inject = ['$scope', '$rootScope', '$location', 'apiService', 'notificationService', '$timeout', '$uibModalStack', '$uibModal', 'fileUploadService', '$window'];
    function createCtrl($scope, $rootScope, $location, apiService, notificationService, $timeout, $uibModalStack, $uibModal, fileUploadService, $window)
    {
        $scope.defaultpath = $rootScope.applicationBaseUrl + "Content/images/movies/unknown.jpg";
        $scope.nextLocation = "/";
        $scope.Customer = {};
        $scope.newCustomer = {};
        $scope.countryData = {
        };
        $scope.newUser = {};
        function Failed(result) {
            notificationService.displayError("Please try again.");
        }
        function completedCountry(result) {
            $scope.countrylist = result.data;
        }
        function completedState(result) {
            $scope.statelist = result.data;
        }
        function completedCity(result) {
            $scope.citylist = result.data;
        }
        function saveimage(data) {
            $scope.defaultpath = $rootScope.applicationBaseUrl + data.AttachmentPath;
            $scope.newUser.ProfileImageURL = data.AttachmentPath;
        }
        $scope.getCountryList = function () {
            apiService.post('/api/common/country', null,
            completedCountry,
            Failed);
        }

        $scope.getStateList = function (country) { 
            apiService.post('/api/common/state', country,
            completedState,
            Failed);
        };
        $scope.getCityList = function (state) { 
            apiService.post('/api/common/getstatescity', state,
            completedCity,
            Failed);
        };

        $scope.getCountryList();

        $scope.uploadFiles = function ($files) {

            $scope.customerImage = $files;
            if ($scope.customerImage) {
                fileUploadService.uploadCustomerprofilepic($scope.customerImage, saveimage);
            }
        }
        $scope.AddCustomer = function ($dirty) { 
                $scope.newUser.Phone = $scope.newUser.Phone.replace('(', '').replace(')', '').replace('-', '').replace(' ', '');
                $scope.newUser.CountryId = $scope.newUser.Country;
                $scope.newUser.StateId = $scope.newUser.State;
                $scope.newUser.CityId = $scope.newUser.City;
                apiService.post('/api/common/saveCustomer', $scope.newUser,
               addCustomerSucceded,
               Failed); 
        }
        function addCustomerSucceded(response) {
            notificationService.displaySuccess('Created Successfully');
            $location.path('/');
        }
        $scope.stayonPage = function () {
            $uibModalStack.dismissAll(); 
        }
        $scope.leaveThisPage = function () {
            $scope.addCustomerForm.$dirty = false;
            $location.path($scope.nextLocation);
        } 
        $scope.$on('$locationChangeStart', function (event, next, current) {
            if (event.currentScope.addCustomerForm.$dirty == true) {
                $scope.nextLocation= next.split('#')[1];
                $scope.ConfirmExit = $uibModal.open({
                    templateUrl: 'scripts/spa/home/confirmBox.html',
                    scope: $scope,
                    backdrop: false
                }).opened.then(function () {
                });
                event.preventDefault();
            } 
        }); 
    }

})(angular.module('Park'));
