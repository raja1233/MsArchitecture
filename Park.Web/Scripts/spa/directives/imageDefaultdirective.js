(function (app) {
    'use strict';

    app.directive('errSrc', imageDefault);
    
    function imageDefault() {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                element.bind('error', function () {
                    if (attrs.src != attrs.errSrc) {
                        attrs.$set('src', attrs.errSrc);
                    }
                });

                attrs.$observe('lazySrc', function (value) {
                    if (!value && attrs.errSrc) {
                        attrs.$set('src', attrs.errSrc);
                    }
                });
            }
        }
    }

})(angular.module('common.ui'));
//enter key event
(function (app) {
    'use strict';

    app.directive('myEnter', myEnter);

    function myEnter() {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                element.bind("keydown keypress", function (event) {
                    if (event.which === 13) {
                        scope.$apply(function () {
                            scope.$eval(attrs.myEnter);
                        });

                        event.preventDefault();
                    }
                });
            }
        }
    }

})(angular.module('common.ui')); 