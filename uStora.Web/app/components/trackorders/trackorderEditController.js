(function (app) {
    app.controller('trackOrderEditController', trackOrderEditController);
    trackOrderEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];
    function trackOrderEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.trackorder = {
            UpdatedDate: new Date()
        }
        $scope.orders = [];
        $scope.vehicles = [];
        $scope.users = [];
        $scope.loadTrackOrderDetail = loadTrackOrderDetail;
        $scope.UpdateTrackOrder = UpdateTrackOrder;
        $scope.loading = true;
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        function loadOrders() {
            apiService.get('/api/trackorder/getorders', null,
               function (result) {
                   $scope.orders = result.data;
               }, function () {
                   notificationService.displayError("Không có đơn hàng nào được tìm thấy.");
               })
        }
        function loadVehicles() {
            apiService.get('/api/trackorder/getvehicles', null,
               function (result) {
                   $scope.vehicles = result.data;
               }, function () {
                   notificationService.displayError("Không có xe nào được tìm thấy.");
               })
        }
        function loadUsers() {
            apiService.get('/api/trackorder/getdriver', null,
               function (result) {
                   $scope.users = result.data;
               }, function () {
                   notificationService.displayError("Không có bản ghi nào được tìm thấy.");
               })
        }
        function loadTrackOrderDetail() {
            $scope.loading = true;
            apiService.get('/api/trackorder/getbyid/' + $stateParams.id, null, function (result) {
                $scope.trackorder = result.data;
                $scope.loading = false;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateTrackOrder() {
            apiService.put('/api/trackorder/update', $scope.trackorder,
                function (result) {
                    notificationService.displaySuccess('Đã cập nhật ' + result.data.Name + ' thành công');
                    $state.go('trackorders');
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Cập nhật không thành công');
                });
        }
        loadOrders();
        loadVehicles();
        loadUsers();
        loadTrackOrderDetail();
    }
})(angular.module('uStora.trackorders'));