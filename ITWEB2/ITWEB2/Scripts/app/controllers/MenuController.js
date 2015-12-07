var MenuController = function($scope, $rootScope, $http, $state) {
    $rootScope.UserData = localStorage.getItem("userData");
    //$rootScope.loginStatus = sessionStorage.getItem("tokenKey") !== null;
    $scope.loginStatus = $rootScope.loginStatus;
    //var registerBtn = window.angular.element(document).find("#RegisterBtn");
    //var loginBtn = window.angular.element(document).find("#LoginBtn");
    //var logoutBtn = window.angular.element(document).find("#LogoutBtn");

    $scope.logout = function () {
        $http({
            url: '/api/Account/Logout',
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
                'Accept': '*/*',
                'Authorization': 'Bearer ' + localStorage.getItem('tokenKey')
            }
        })
        localStorage.removeItem("tokenKey");
        $rootScope.loginStatus = false;
        location.reload();
        $state.transitionTo('home');
    }

}

MenuController.$inject = ['$scope', '$rootScope', '$http', '$state'];