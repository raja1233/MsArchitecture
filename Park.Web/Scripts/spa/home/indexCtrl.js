(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', '$rootScope', '$location', 'apiService', 'notificationService', '$timeout', '$uibModalStack', '$uibModal', 'fileUploadService'];

    function indexCtrl($scope, $rootScope, $location, apiService, notificationService, $timeout, $uibModalStack, $uibModal, fileUploadService)
    {
        $scope.filterCustomersColumn = "1";
        $scope.imageNotFoundpath = $rootScope.applicationBaseUrl + "Content/images/movies/unknown.jpg";
        $scope.newUser={};
        $scope.loadingCustomers = true;
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.Customers = [];
        $scope.customersLoadCompleted= function (result) {
            $scope.Customers = result.data.Items; 
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.loadingCustomers = false; 
            if ($scope.filterCustomers && $scope.filterCustomers.length) {
                notificationService.displayInfo(result.data.Items.length + ' customers found');
            }

        }
        function Failed(result) {
            notificationService.displayError("Please try again.");
        }
        $scope.customersLoadFailed = function (result) {
            notificationService.displayError(response.data);
        }

        $scope.clearSearch = function (result) {
            $scope.filterCustomers = '';
            search();
        }

        $scope.search = function (page) {
            page =  page || 0;

            $scope.loadingCustomers = true;

            var config = {
                params: {
                    page: page,
                    pageSize: 5,
                    filter: $scope.filterCustomers,
                    filterCustomersColumn: $scope.filterCustomersColumn
                }
            };
            apiService.get('/api/common/GetEmployeeList', config,
                  $scope.customersLoadCompleted,
                   $scope.customersLoadFailed);

        }
        $scope.search();


        // edit customer
        $scope.openCustomerEditPopup = function (customerId) {
            $scope.getCustomerData(customerId);
            $scope.CustomerEditPopup = $uibModal.open({
                templateUrl: 'scripts/spa/home/editCustomerModal.html',
                scope: $scope,
                backdrop: false
            }).opened.then(function () {  
            });
        }
        $scope.getCustomerData = function (customerId) {
            apiService.post('/api/common/GetEmployeeDetailsById', customerId,
                  $scope.customerLoadCompleted,
                   $scope.customerLoadFailed);
        }
        $scope.customerLoadCompleted = function (result) { 
            $scope.newUser = result.data;
            $scope.defaultpath = $rootScope.applicationBaseUrl + $scope.newUser.ProfileImageURL;
            $scope.getStateList($scope.newUser.CountryId);
            $scope.getCityList($scope.newUser.StateId);
        }
        $scope.customerLoadFailed = function (result) {

        }
        $scope.uploadFiles = function ($files) {

            $scope.customerImage = $files;
            if ($scope.customerImage[0].type == "image/png" || $scope.customerImage[0].type == "image/jpeg") { 
                if ($scope.customerImage) {
                    fileUploadService.uploadCustomerprofilepic($scope.customerImage, saveimage);
                }
            }
            else {
                notificationService.displayError("Kindly select valid image");
                angular.element("input[type='file']").val(null);
                return false
            }
        }
        function saveimage(data) {
            $scope.defaultpath = $rootScope.applicationBaseUrl + data.AttachmentPath;
            $scope.newUser.ProfileImageURL = data.AttachmentPath;
        }
        //delete customer
        $scope.deleteCustomer = function (customerId) {
            apiService.post('/api/common/DeleteEmployee', customerId,
                  $scope.deleteCompleted,
                   $scope.deleteFailed);
        }
        $scope.deleteCompleted = function (result) {
            notificationService.displaySuccess('Deleted Successfully');
            $scope.search();
        }
        $scope.deleteFailed = function (result) {
        }

        //load default data
        function completedCountry(result) {
            $scope.countrylist = result.data; 
        }
        function completedState(result) {
            $scope.statelist = result.data;
        }
        function completedCity(result) {
            $scope.citylist = result.data;
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

        //update customer

        $scope.UpdateCustomer = function () {
            $scope.newUser.Phone = $scope.newUser.Phone.replace('(', '').replace(')', '').replace('-', '').replace(' ', '');
            $scope.newUser.CountryId = $scope.newUser.Country;
            $scope.newUser.StateId = $scope.newUser.State;
            $scope.newUser.CityId = $scope.newUser.City;
            apiService.post('/api/common/saveCustomer', $scope.newUser,
           addCustomerSucceded,
           Failed);
        }
        function addCustomerSucceded(response) {
            notificationService.displaySuccess('Updated Successfully');
            $uibModalStack.dismissAll();
            $scope.newUser = {};
            $scope.search();
        }
        $scope.closeCustomerpopup = function ($pristine, $dirty) {
            //if ($dirty == true) { }
            //else {
                $uibModalStack.dismissAll();
            //}
        }
        $scope.propertyName = 'Name';
        $scope.reverse = true;
        $scope.sortBy = function (propertyName) {
            $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
            $scope.propertyName = propertyName;
        };
    }

})(angular.module('Park'));
