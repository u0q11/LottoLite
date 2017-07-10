
var winningNumbersApp = angular.module("winningNumbers", []);
winningNumbersApp.controller("winningNumbersCtrl", function ($scope, $http, $attrs, $httpParamSerializer) {
    $scope.url = $attrs.apiEndpoint;

    $scope.winningNums = {
        drawName: "Test",
        primaryFirst: null,
        primarySecond: null,
        primaryThird: null,
        primaryFourth: null,
        primaryFifth: null,
        secondaryFirst: null,
        secondarySecond: null
    }

    $scope.saveErrors = [];
    $scope.saveSuccess = false;
    $scope.saveFailed = false;

    $scope.save = function () {
        var config = { headers: { "Content-Type": "application/x-www-form-urlencoded" } };

        $scope.saveErrors = [];
        $scope.saveSuccess = false;
        $scope.saveFailed = false;

        $http.post($scope.url, $httpParamSerializer($scope.winningNums), config).
              then(function (response) {
                  $scope.saveFailed = false;
                  $scope.saveSuccess = true;
              }, function (response) {
                  $scope.saveFailed = true;
                  $scope.saveSuccess = false;

                  // could break this out to a service to flatten the model state errors
                  var modelState = response.data.ModelState;
                  if (modelState) {
                      for (var key in modelState) {
                          for (var i = 0; i < modelState[key].length; i++) {
                              if ($scope.saveErrors.indexOf(modelState[key][i]) === -1)
                                  $scope.saveErrors.push(modelState[key][i]);
                          }
                      }
                  }
              });
    };

});

angular.bootstrap(document.getElementById("winningNumbers"), ['winningNumbers']);