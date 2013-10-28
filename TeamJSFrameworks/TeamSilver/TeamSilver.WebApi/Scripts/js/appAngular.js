
angular.module('adminApp', []).
  config(['$routeProvider', function ($routeProvider) {
      $routeProvider.
          when('/users', { templateUrl: 'Scripts/partialsAngular/users-list.html', controller: UsersController }).
          when('/products', { templateUrl: 'Scripts/partialsAngular/create-product.html', controller: ProductsController }).
          when('/products/delete', { templateUrl: 'Scripts/partialsAngular/delete-products.html', controller: ProductsDeleteController }).
          when('/products/delete/:id', { templateUrl: 'Scripts/partialsAngular/delete-products.html', controller: SingleProductDeleteController }).
          //when('/categories/:id/posts', { templateUrl: 'partials/posts-list.html', controller: SingleCategotyController }).
          //when('/posts/create', { templateUrl: 'partials/create-post.html', controller: PostsListCtrl }).
          otherwise({ redirectTo: '/' });
  }]);