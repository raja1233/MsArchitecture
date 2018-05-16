(function (app) {
	'use strict';

	app.directive('monthPicker', monthPicker);
	function monthPicker() {
	    return {
	        restrict: 'A',
	        link: function ($scope, $element, $attrs, $controller) {
	            $element.datetimepicker({
	                format: "MM-yyyy",
	                viewMode: "months",
	                minViewMode: "months",
	                pickTime: false,
	            }).on('changeDate', function (e) {
	                $controller.setViewValue(e.date);
	                $scope.apply();
	            });
	        }
	    }
	}

})(angular.module('common.ui'));

//var app = angular.module('Park', []);

//app.controller('MainCtrl', function ($scope) {
//    $scope.var1 = '07-2013';
//});


//app.directive('datetimez', function () {
//    return {
//        restrict: 'A',
//        require: 'ngModel',
//        link: function (scope, element, attrs, ngModelCtrl) {
//            element.datetimepicker({
//                format: "MM-yyyy",
//                viewMode: "months",
//                minViewMode: "months",
//                pickTime: false,
//            }).on('changeDate', function (e) {
//                ngModelCtrl.$setViewValue(e.date);
//                scope.$apply();
//            });
//        }
//    };
//});
