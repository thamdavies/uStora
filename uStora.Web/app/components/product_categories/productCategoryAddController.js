(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);
    productCategoryAddController.$inject = ['apiService', '$scope', 'notificationService','$state','commonService'];
    function productCategoryAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.parentCategories = [];
        $scope.loadParentCategories = loadParentCategories;
        $scope.AddProductCategory = AddProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        $scope.chooseImage = function () {
            var finder = new CKFinder();

            finder.selectActionFunction = function (fileUrl) {
               
                $scope.$apply(function () {
                    $scope.productCategory.Image = fileUrl;
                })
            }
            finder.popup();
        }

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function AddProductCategory() {
            apiService.post('/api/productcategory/create', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    $state.go('product_categories');
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Thêm không thành công');
                });
        }

        function loadParentCategories() {
            apiService.get('/api/productcategory/getallparents', null,
                function (result) {
                    $scope.parentCategories = result.data;
                }, function () {
                    console.log('Không có dữ liệu!!!');
                });
        }

        loadParentCategories();
    }
})(angular.module('uStora.product_categories'));