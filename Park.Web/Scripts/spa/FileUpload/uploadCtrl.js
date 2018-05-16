(function (app) {
    'use strict';

    app.controller('uploadCtrl', uploadCtrl);

    uploadCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService'];
    function uploadCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService) {

        $scope.uploadFiles = uploadFiles;
        $scope.file = { Id: 1, Rating: 1, NumberOfStocks: 1 };
        //$scope.excelfile = {};
        var excelfile = null;
        function uploadFiles($files) {
            excelfile = $files;
            UploadExcel()
        }

        function UploadExcel() {
            //addfileSucceded;
            fileUploadService.uploadExcelFile(excelfile);
        }


        function addfileSucceded(response) {
            notificationService.displaySuccess('File has been submitted');
            $scope.file = response.data;

            if (excelfile) {
                fileUploadService.uploadExcelFile(excelfile);
            }
            
        }

        function addfileFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }
        ////  Test Codes for Multiple Image Upload  ////
        // GET THE FILE INFORMATION.
        $scope.getFileDetails = function (e) {

            $scope.files = [];
            $scope.$apply(function () {

                // STORE THE FILE OBJECT IN AN ARRAY.
                for (var i = 0; i < e.files.length; i++) {
                    $scope.files.push(e.files[i])
                }

            });
        };
        // NOW UPLOAD THE FILES.
        $scope.uploadFiles = function () {

            //FILL FormData WITH FILE DETAILS.
            var data = new FormData();

            for (var i in $scope.files) {
                data.append("uploadedFile", $scope.files[i]);
            }

            // ADD LISTENERS.
            var objXhr = new XMLHttpRequest();
            objXhr.addEventListener("progress", updateProgress, false);
            objXhr.addEventListener("load", transferComplete, false);

            // SEND FILE DETAILS TO THE API.
            objXhr.open("POST", "/api/fileupload/");
            objXhr.send(data);
        }

        // UPDATE PROGRESS BAR.
        function updateProgress(e) {
            if (e.lengthComputable) {
                document.getElementById('pro').setAttribute('value', e.loaded);
                document.getElementById('pro').setAttribute('max', e.total);
            }
        }

        // CONFIRMATION.
        function transferComplete(e) {
            alert("Files uploaded successfully.");
        }
    }
})(angular.module('Park'));