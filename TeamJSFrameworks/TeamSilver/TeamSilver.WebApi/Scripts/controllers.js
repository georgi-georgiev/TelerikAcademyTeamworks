﻿/// <reference path="../data/menuItems.js" />
/// <reference path="../libs/_references.js" />


function UsersController($scope, $http) {
    var sessionKey = localStorage.getItem("sessionKey");

    $http({
        method: 'GET',
        url: 'http://localhost:55544/api/users/all-users',
        headers: { 'X-sessionKey': sessionKey }
    }).success(function (data) {
        $scope.users = data;
    });
}

function ProductsController($scope, $http) {
    var sessionKey = localStorage.getItem("sessionKey");

    $scope.newProduct = {
        price: "",
        category: "",
        dateOfCreation: "",
        description: "",
        manufacturer: "",
        productName: "",
        quantity: ""
    };

    $http({
        method: 'GET',
        url: 'http://localhost:55544/api/products',
        headers: { 'X-sessionKey': sessionKey }
    }).success(function (data) {
        $scope.products = data;
        
        $scope.addProduct = function () {
            $scope.products.push($scope.newProduct);

            $http({
                method: 'POST',
                url: 'http://localhost:55544/api/products',
                data: $scope.newProduct,
                headers: { 'X-sessionKey': sessionKey }
            }).success(function (data) {
                $scope.newProduct = data;
                console.log(data);
                console.log($scope.newProduct);
            }).error(function (error) {
                console.log(error);
            });
        }
    });

    
}

function ProductsDeleteController($scope, $http) {
    var sessionKey = localStorage.getItem("sessionKey");

    $http({
        method: 'GET',
        url: 'http://localhost:55544/api/products',
        headers: { 'X-sessionKey': sessionKey }
    }).success(function (data) {
        $scope.products = data;
    });
}

function SingleProductDeleteController($scope, $http, $routeParams) {
    var sessionKey = localStorage.getItem("sessionKey");

    var id = $routeParams.id;

    $http({
        method: 'DELETE',
        url: 'http://localhost:55544/api/products/' + id,
        headers: { 'X-sessionKey': sessionKey }
    }).success(function (data) {
        this.ProductsDeleteController($scope, $http);
    });
}

function CategoriesController($scope, $http) {
    $http.get('http://localhost:55544/api/Categories').success(function (data) {
        $scope.categories = data;
    });
}

function SingleCategotyController($scope, $http, $routeParams) {
    var id = $routeParams.id;

    $http.get('http://localhost:55544/api/Categories/' + id).success(function (data) {
        //var category = _.where(data, { "id": parseInt(id) });
        //debugger;
        //var catPosts = category[0].posts;
        $scope.posts = data;
    }); 
}