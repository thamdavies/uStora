(function (app) {
    app.controller('productEditController', productEditController);
    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];
    function productEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.product = {
            UpdatedDate: new Date()
        }
        $scope.productCategories = [];
        $scope.brands = [];
        $scope.loadBrands = loadBrands;
        $scope.loadProductCategories = loadProductCategories;
        $scope.loadProductDetail = loadProductDetail;
        $scope.UpdateProduct = UpdateProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.moreImages = [];
        $scope.thisClose = thisClose;

        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }

        function loadBrands() {
            apiService.get('/api/product/listbrands', null,
               function (result) {
                   $scope.brands = result.data;
               }, function () {
                   notificationService.displayError("Không có nhãn hiệu nào được tìm thấy.");
               })
        }

        function thisClose(img) {
            var value = commonService.objectToString(img);
            var split1 = value.substring(7);
            var split2 = split1.substring(-split1.length, split1.length - 3);
            value = split2;
            var array = $scope.moreImages;
            var index = array.indexOf(value);
            if (index > -1)
            {
                array.splice(index, 1);
            }
            console.log(index);
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

        function loadProductDetail() {
            apiService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                if ($scope.product.MoreImages != "null" && $scope.product.MoreImages != "NULL")
                {
                    $scope.moreImages = JSON.parse($scope.product.MoreImages);
                }
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function UpdateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.put('/api/product/update', $scope.product,
                function (result) {
                    notificationService.displaySuccess('Đã cập nhật ' + result.data.Name + ' thành công');
                    $state.go('products');
                }, function (error) {
                    console.log(error);
                    notificationService.displayError('Cập nhật không thành công');
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
        loadProductDetail();
        loadBrands();
    }
})(angular.module('uStora.products'));