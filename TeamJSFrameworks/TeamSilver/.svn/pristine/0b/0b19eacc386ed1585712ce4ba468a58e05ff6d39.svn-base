/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
	var data = null;

	function getLoginViewModel(successCallback) {		
		var viewModel = {
			username: $("#tb-username").val(),
			password: $("#tb-password").val(),
			usernameReg: $("#tb-usernameReg").val(),
			passwordReg: $("#tb-passwordReg").val(),
			firstName: $("#tb-firstName").val(),
			lastName: $("#tb-lastName").val(),
			email: $("#tb-email").val(),
			login: function () {
				data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
							successCallback();
						}
					});
			},
			register: function () {
			    data.users.register(this.get("usernameReg"), this.get("passwordReg"), this.get("firstName"), this.get("lastName"),
                    this.get("email"))
					.then(function () {
						if (successCallback) {
							successCallback();
						}
					});
			}
		};
		return kendo.observable(viewModel);
	};

	function getProductsViewModel() {
		return data.products.all()
			.then(function (products) {
			    console.log(products);
				var viewModel = {
					products: products,
					message: ""
				};
				console.log(viewModel);
				return kendo.observable(viewModel);
			}, function (err) {
			    console.log(err);
			});
	}

	function getProductsByIdViewModel(id) {
	    return data.products.getById(id)
			.then(function (products) {
			    console.log(products);
			    var viewModel = {
			        products: products,
			        message: "",
			        buy: function () {
			            data.products.buy(id).then(function (data) {
			                console.log(data);
			                console.log("success buy");
			                viewModel.products = data;
			                kendo.bind(document.body, viewModel);
			            }, function (err) {
			                console.log(err);
			            });
			        }
			    };
			    console.log(viewModel);
			    return kendo.observable(viewModel);
			}, function (err) {
			    console.log(err);
			});
	}
	
	function getCategoriesViewModel() {
	    return data.categories.all()
			.then(function (categories) {
			    console.log(categories);
			    var viewModel = {
			        categories: categories,
			        message: ""
			    };
			    console.log(viewModel);
			    return kendo.observable(viewModel);
			}, function (err) {
			    console.log(err);
			});
	}

	function getCategoriesIdViewModel(id) {
	    return data.categories.getById(id)
			.then(function (products) {
			    console.log(products);
			    var viewModel = {
			        products: products,
			        message: ""
			    };
			    console.log(viewModel);
			    return kendo.observable(viewModel);
			}, function (err) {
			    console.log(err);
			});
	}
	
	function getBasketViewModel() {
	    return data.users.getProducts()
            .then(function (products) {
                console.log(products);
                var viewModel = {
                    products: products,
                    message: ""
                };
                console.log(viewModel);
                return kendo.observable(viewModel);
            }, function (err) {
                console.log(err);
            });
	}

	function getNicknameViewModel() {
	    var viewModel ={
	        nickname: data.getNickname()
	    }
	    return kendo.observable(viewModel);
	}


	return {
		getLoginVM: getLoginViewModel,
		getProductsVM: getProductsViewModel,
	    getProductsByIdVM: getProductsByIdViewModel,
		getCategoriesVM: getCategoriesViewModel,
		getCategoriesByIdVM:getCategoriesIdViewModel,
		getNicknameVM: getNicknameViewModel,
	    getBasketVM: getBasketViewModel,
		setPersister: function (persister) {
			data = persister
		}
	};
}());