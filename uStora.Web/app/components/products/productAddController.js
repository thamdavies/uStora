/// <reference path="../../../Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productAddController', productAddController);
    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];
    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.productCategories = [];
        $scope.loadProductCategories = loadProductCategories;
        $scope.AddProduct = AddProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.moreImages = [];
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.chooseMoreImages = function () {
            var finder = new CKFinder();

            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }

        $scope.chooseImage = function () {
            var finder = new CKFinder();

            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.post('/api/product/create', $scope.product,
                function (result) {
                    notificationService.displaySuccess('Đã thêm ' + result.data.Name + ' thành công');
                    $state.go('products');
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Thêm không thành công');
                });
        }

        function loadProductCategories() {
            apiService.get('/api/productcategory/getallparents', null,
                function (result) {
                    $scope.productCategories = result.data;
                }, function () {
                    console.log('Không có dữ liệu!!!');
                });
        }

        loadProductCategories();
    }
})(angular.module('uStora.products'));