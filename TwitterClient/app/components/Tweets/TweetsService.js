app.factory('tweetsService', function ($http) {
    var tweetsService = {};
    //bearertokencredentials = "s18uttHpn9qW06fwdPGZrFirQ:tCX1IUdaIh1uefPXvHR6Jh3fEQ5IhB2DCa9X5uwbYCwmf92Oqk";
    //appkeys = JSON.stringify(window.btoa(bearertokencredentials));

    tweetsService.gettoken = function (key, secret) {
        bearertokencredentials = key + ':' + secret;
        appkeys = JSON.stringify(window.btoa(bearertokencredentials));
        return $http({
            method: 'POST',
            url: 'http://localhost:56863/api/tweets/gettoken',
            data: appkeys
        });
    }

    tweetsService.gettweets = function (data, username) {
        return $http({
            method: 'POST',
            url: 'http://localhost:56863/api/tweets/gettweets/' + username,
            data: data
        });
    }

    tweetsService.searchtweets = function (data, hashtag) {
        return $http({
            method: 'POST',
            url: 'http://localhost:56863/api/tweets/searchtweets/' + hashtag,
            data: data
        });
    }
    return tweetsService;
});