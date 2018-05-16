angular.module('twitterApp.services', []).factory('twitterService', function($q) {

    var authorizationResult = false;

    return {
        initialize: function() {
            //initialize OAuth.io with public key of the application
            OAuth.initialize('19gVB-kbrzsJWQs5o7Ha2LIeX4I', { cache: true });  //19gVB-kbrzsJWQs5o7Ha2LIeX4I
            //try to create an authorization result when the page loads, this means a returning user won't have to click the twitter button again
            authorizationResult = OAuth.create('twitter');
        },
        isReady: function() {
            return (authorizationResult);
        },
        connectTwitter: function() {
            var deferred = $q.defer();
            OAuth.popup('twitter', { cache: true }, function (error, result) { //cache means to execute the callback if the tokens are already present 
                if (!error) {
                    authorizationResult = result;
                    //console.log(result);
                    deferred.resolve();
                } else {
                    //do something if there's an error

                }
            });
            return deferred.promise;
        },
        clearCache: function() {
            OAuth.clearCache('twitter');
            authorizationResult = false;
        },
        getLatestTweets: function (maxId) {
            //create a deferred object using Angular's $q service
            var deferred = $q.defer();
      			var url='/1.1/statuses/home_timeline.json';
      			if(maxId){
      				url+='?max_id='+maxId;
      			}
            var promise = authorizationResult.get(url).done(function(data) { //https://dev.twitter.com/docs/api/1.1/get/statuses/home_timeline
                //when the data is retrieved resolve the deferred object
                console.log(data);
				        deferred.resolve(data);
            }).fail(function(err) {
               //in case of any error we reject the promise with the error object
                deferred.reject(err);
            });
            var url1 = '/1.1/account/verify_credentials.json'; var uid;
            var promise1 = authorizationResult.get(url1).done(function (data) { //https://dev.twitter.com/docs/api/1.1/get/statuses/home_timeline
                //when the data is retrieved resolve the deferred object
                console.log('shubham');
                uid = data.user_id;
                console.log(data);
                deferred.resolve(data);
            }).fail(function (err) {
                //in case of any error we reject the promise with the error object
                deferred.reject(err);
            });

            var url1 = '/1.1/account/verify_credentials.json?include_email=true'; var uid;
            var promise2 = authorizationResult.get(url1).done(function (data) { //https://dev.twitter.com/docs/api/1.1/get/statuses/home_timeline
                //when the data is retrieved resolve the deferred object
                console.log('shubhamDone');
                
                console.log(data);
                deferred.resolve(data);
            }).fail(function (err) {
                //in case of any error we reject the promise with the error object
                deferred.reject(err);
            });


            //return the promise of the deferred object
            return deferred.promise2;
        }
    }

});
