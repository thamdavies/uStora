(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','commonService'];
    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            UpdatedDate: new Date()
        }
        $scope.parentCategories = [];
        $scope.loadParentCategories = loadParentCategories;
        $scope.loadProductCategoryDetail = loadProductCategoryDetail;
        $scope.UpdateProductCategory = UpdateProductCategory;
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

        function loadProductCategoryDetail() {
            apiService.get('/api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function UpdateProductCategory() {
            apiService.put('/api/productcategory/update', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess('Đã cập nhật ' + result.data.Name + ' thành công');
                    $state.go('product_categories');
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Cập nhật không thành công');
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
        loadProductCategoryDetail();
    }
})(angular.module('uStora.product_categories'));