// Code goes here
angular.module("app", ["ngRoute"])
    .controller("MainController", function ($scope, $http, $log) {
        $scope.message = "Github Viewer1";

        var LoadUserRepository = function (response) {
            $log.info('Inside LoadUserRepository func....');
            $scope.repos = response.data;
        }

        var onGithubRequestComplete = function (response) {
            $scope.user = response.data;
            console.log($scope.user);
            $http.get($scope.user.repos_url)
                .then(LoadUserRepository, error);
        }

        var error = function (ex) {
            $scope.error = "Could not fetch data.";
        }

        $scope.search = function (username) {
            $log.info('Inside search func....');
            $http.get('https://api.github.com/users/' + username)
                .then(onGithubRequestComplete, error);
        }

        $scope.username = "Angular";
    })
   .config(function ($routeProvider) {
       $routeProvider
            .when("/userDetails", {
                templateUrl: "userDetails.html"
            })
       .when("/userDetails2", {
           templateUrl: "userDetails2.html"
       })
       .otherwise("/html", {
       templateUrl : "html.html"});
   });