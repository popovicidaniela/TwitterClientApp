app.controller('TweetsController', function ($scope, tweetsService, $window) {
    if (localStorage.getItem('Token') == null) {
        $scope.ShowAuth = true;
        $scope.ShowSearch = false;
    }
    else {
        $scope.ShowSearch = true;
        $scope.ShowAuth = false;
    }

    $scope.authenticate = function () {
        if ($scope.key != null && $scope.secret != null) {
            $scope.alert = "";
            tweetsService.gettoken($scope.key, $scope.secret).success(function (data, status, headers, config) {
                if (data.token_type == 'bearer') {
                    localStorage.setItem('Token', JSON.stringify(data.access_token));
                    $scope.alert = "";
                    $scope.ShowSearch = true;
                    $scope.ShowAuth = false;
                }
            }).error(function (data, status) {
                $scope.alert = "Incorrect credentials!";
            })
        }
        else {
            $scope.alert = "Fill in all the fields!";
        }
    };
    $scope.getusertweets = function () {
        tokenFromStorage = localStorage.getItem('Token');
        tweetsService.gettweets(tokenFromStorage, $scope.username).success(function (data, status, headers, config) {
            if (data) {
                $scope.tweets = data;
                exportTweets($scope.tweets);
                $scope.IsVisible = true;
            }
        });
    }
    $scope.gethashtagtweets = function () {
        tokenFromStorage = localStorage.getItem('Token');
        tweetsService.searchtweets(tokenFromStorage, $scope.hashtag).success(function (data, status, headers, config) {
            if (data) {
                $scope.tweets = data.statuses;
                exportTweets($scope.tweets);
                $scope.IsVisible = true;
            }
        });
    }
    exportTweets = function (tweets) {
        var toExport = JSON.stringify(tweets);
        var data = toExport, blob = new Blob([data], { type: 'application/json' }), url = $window.URL || $window.webkitURL;
        $scope.fileUrl = url.createObjectURL(blob);
    }
   
});