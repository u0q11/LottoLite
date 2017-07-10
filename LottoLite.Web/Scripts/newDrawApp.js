var newDrawApp = angular.module("newDraw", []);

newDrawApp.controller("drawCtrl", function ($scope, $http, $attrs, $httpParamSerializer) {
    $scope.url = $attrs.apiEndpoint;

    $scope.draw = { // hardcoded just to make testing quicker
        name: "Test",
        description: "test desc",
        dateOfDraw: "11/07/2017",
        totalPrimaryNumbers: 4,
        primaryNumbersMin: 1,
        primaryNumbersMax: 49,
        totalSecondaryNumbers: 2,
        secondaryNumbersMin: 1,
        secondaryNumbersMax: 10
    }

    $scope.saveErrors = [];
    $scope.saveSuccess = false;
    $scope.saveFailed = false;

    $scope.save = function () {
        var config = { headers: { "Content-Type": "application/x-www-form-urlencoded" } };
        $scope.saveErrors = [];
        $scope.saveSuccess = false;
        $scope.saveFailed = false;

        $http.post($scope.url, $httpParamSerializer($scope.draw), config).
              then(function (response) {
                  $scope.saveFailed = false;
                  $scope.saveSuccess = true;
              }, function (response) {
                  $scope.saveFailed = true;
                  $scope.saveSuccess = false;
                  $scope.saveError = response.data || "Request failed";

                  // could break this out to a service to flatten the model state errors
                  var modelState = response.data.ModelState;
                  if (modelState) {
                      for (var key in modelState) {
                          for (var i = 0; i < modelState[key].length; i++) {
                              if($scope.saveErrors.indexOf(modelState[key][i]) === -1)
                                $scope.saveErrors.push(modelState[key][i]);
                          }
                      }
                  }
              });
    };
});