﻿/// <reference path="../../../Assets/admin/libs/angular/angular.min.js" />
(function (app) {
    app.service('commonService', commonService);

    function commonService() {
        return {
            getSeoTitle: getSeoTitle,
            objectToString: objectToString
        }

        function getSeoTitle(input) {
            if (input == undefined || input == '')
                return '';
            //Đổi chữ hoa thành chữ thường
            var slug = input.toLowerCase();

            //Đổi ký tự có dấu thành không dấu
            slug = slug.replace(/á|à|ả|ạ|ã|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ/gi, 'a');
            slug = slug.replace(/é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ/gi, 'e');
            slug = slug.replace(/i|í|ì|ỉ|ĩ|ị/gi, 'i');
            slug = slug.replace(/ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ/gi, 'o');
            slug = slug.replace(/ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự/gi, 'u');
            slug = slug.replace(/ý|ỳ|ỷ|ỹ|ỵ/gi, 'y');
            slug = slug.replace(/đ/gi, 'd');
            //Xóa các ký tự đặt biệt
            slug = slug.replace(/\`|\~|\!|\@|\#|\||\$|\%|\^|\&|\*|\(|\)|\+|\=|\,|\.|\/|\?|\>|\<|\'|\"|\:|\;|_/gi, '');
            //Đổi khoảng trắng thành ký tự gạch ngang
            slug = slug.replace(/ /gi, "-");
            //Đổi nhiều ký tự gạch ngang liên tiếp thành 1 ký tự gạch ngang
            //Phòng trường hợp người nhập vào quá nhiều ký tự trắng
            slug = slug.replace(/\-\-\-\-\-/gi, '-');
            slug = slug.replace(/\-\-\-\-/gi, '-');
            slug = slug.replace(/\-\-\-/gi, '-');
            slug = slug.replace(/\-\-/gi, '-');
            //Xóa các ký tự gạch ngang ở đầu và cuối
            slug = '@' + slug + '@';
            slug = slug.replace(/\@\-|\-\@|\@/gi, '');

            return slug;
        }
        function objectToString(obj) {
            //create an array that will later be joined into a string.
            var string = [];

            //is object
            //    Both arrays and objects seem to return "object"
            //    when typeof(obj) is applied to them. So instead
            //    I am checking to see if they have the property
            //    join, which normal objects don't have but
            //    arrays do.
            if (typeof (obj) == "object" && (obj.join == undefined)) {
                string.push("{");
                for (prop in obj) {
                    string.push(prop, ": ", objectToString(obj[prop]), ",");
                };
                string.push("}");

                //is array
            } else if (typeof (obj) == "object" && !(obj.join == undefined)) {
                string.push("[")
                for (prop in obj) {
                    string.push(convertToText(obj[prop]), ",");
                }
                string.push("]")

                //is function
            } else if (typeof (obj) == "function") {
                string.push(obj.toString())

                //all other values can be done with JSON.stringify
            } else {
                string.push(JSON.stringify(obj))
            }

            return string.join("")
        }
    }
})(angular.module('uStora.common'));