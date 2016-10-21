(function (app) {
    app.controller('revenueStatisticController', revenueStatisticController);
    revenueStatisticController.$inject = ['apiService', '$scope', 'notificationService', '$filter'];
    function revenueStatisticController(apiService, $scope, notificationService, $filter) {
        $scope.tableData = [];
        $scope.getStatistic = getStatistic;
        $scope.labels = [];
        $scope.series = ['Doanh số', 'Lợi nhuận'];
        $scope.chartData = [];

        $scope.fromDate = '01/01/2015';
        $scope.toDate = '01/01/2017';
        function getStatistic() {
            var config = {
                params: {
                    fromDate: $scope.fromDate,
                    toDate: $scope.toDate
                }
            }
            apiService.get('/api/statistic/getrevenue', config,
                function (response) {
                    $scope.tableData = response.data;
                    var labels = [];
                    var chartData = [];
                    var revenues = [];
                    var benefit = [];
                    $.each(response.data, function (i, item) {
                        labels.push($filter('date')(item.Date,'dd/MM/yyyy'));
                        revenues.push(item.Revenues);
                        benefit.push(item.Benefit);
                        
                    });
                    chartData.push(revenues);
                    chartData.push(benefit);
                    $scope.labels = labels;
                    $scope.chartData = chartData;
                }, function (response) {
                    notificationService.displayWarning('Không có dữ liệu...');
                });
        }
        getStatistic();
    }
})(angular.module('uStora.statistics'));