(function (app) {

    app.controller('revenueStatisticController', revenueStatisticController);
    revenueStatisticController.$inject = ['apiService', '$scope', 'notificationService', '$filter'];
    function revenueStatisticController(apiService, $scope, notificationService, $filter) {
        $scope.tableData = [];
        $scope.getStatistic = getStatistic;
        $scope.labels = [];
        $scope.series = ['Doanh thu', 'Lợi nhuận'];
        $scope.chartData = [];
        $scope.loading = true;
        $scope.fromDate = '01/01/2015';
        $scope.toDate = new Date().toLocaleDateString();

        function getStatistic() {
            $scope.loading = true;
            var config = {
                params: {
                    fromDate: $filter('date')(new Date($scope.fromDate), 'dd/MM/yyyy'),
                    toDate: $filter('date')(new Date($scope.toDate), 'dd/MM/yyyy')
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
                        labels.push($filter('date')(item.Date, 'dd/MM/yyyy'));
                        revenues.push(item.Revenues);
                        benefit.push(item.Benefit);

                    });
                    chartData.push(revenues);
                    chartData.push(benefit);
                    $scope.labels = labels;
                    $scope.chartData = chartData;
                    $scope.loading = false;
                }, function (response) {
                    setTimeout(function () {
                        $scope.loading = false;
                    }, 100);
                });
        }
        var toDate = $filter('date')(new Date($scope.toDate), 'dd/MM/yyyy')
        getStatistic();
        $('#fromDate').click(function () {
            jQuery('#fromDate').datetimepicker({
                format: 'd/m/Y',
                lang: 'vi',
                timepicker: false
            });
        });
        $('#toDate').click(function () {
            jQuery('#toDate').datetimepicker({
                format: 'd/m/Y',
                lang: 'vi',
                timepicker: false
            });
        });
    }
})(angular.module('uStora.statistics'));