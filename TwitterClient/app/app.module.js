var app = angular.module('app', ['ngResource', 'ui.router'])
.config(function ($urlRouterProvider, $stateProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider
        .state('tweets', {
            url: '/',
            templateUrl: 'app/components/Tweets/tweets.html',
            controller: "TweetsController"
        });
});
app.config(['$compileProvider',
    function ($compileProvider) {
        $compileProvider.aHrefSanitizationWhitelist(/^\s*(|blob|):/);
    }]);