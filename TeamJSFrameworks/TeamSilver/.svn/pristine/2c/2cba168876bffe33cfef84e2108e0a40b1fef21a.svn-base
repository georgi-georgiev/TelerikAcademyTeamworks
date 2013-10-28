/// <reference path="libs/_references.js" />


(function () {
	var appLayout =
		new kendo.Layout('<nav id="nav"></nav><div id="main-content"></div>');
	var data = persisters.get("api/");
	vmFactory.setPersister(data);

	var router = new kendo.Router();

	router.route("/", function () {
	    if (data.isUserLoggedIn()) {
	        router.navigate("/home");
	    }
	    else {
	        viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(
						function () {
						    router.navigate("/home");
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    appLayout.showIn("#main-content", view);
				}, function (error) {
				    console.log(error);
				});
	    }
	});

	router.route("/home", function () {
	    viewsFactory.getMenuView()
            .then(function (menuHTML) {
                var nicknameVm = vmFactory.getNicknameVM();
                var view = new kendo.View(menuHTML,
						{ model: nicknameVm });
                appLayout.showIn("#nav", view);
                $(".menu").kendoMenu();
                var welcome = kendo.View("<div>asd</div>");
                var role = localStorage.getItem("role");
                if (role == "admin") {
                    $(".admin-link").show();
                }
                appLayout.showIn("#main-content", welcome);
                
            });
	});

	router.route("/logout", function () {
	    data.users.logout()
            .then(function (data) {
                router.navigate("/");
            }, function (error) {
                console.log(error);
            });
	});

	
	router.route("/products", function () {
	    console.log("products");
	    viewsFactory.getProductsView()
            .then(function (productsHtml) {
                vmFactory.getProductsVM()
                    .then(function (vm) {
                        var view = new kendo.View(productsHtml,
						{ model: vm });
                        appLayout.showIn("#main-content", view);
                    }, function (err) {
                        console.log(err);
                    });
            }, function (err) {
                console.log(err);
            });
	});
	
	router.route("/categories", function () {
			console.log("categories");
			viewsFactory.getCategoriesView()
				.then(function (categoriesHtml) {
					vmFactory.getCategoriesVM()
						.then(function (vm) {
							console.log(5);
							var view = new kendo.View(categoriesHtml,
							{ model: vm });
							appLayout.showIn("#main-content", view);
						}, function (err) {
							console.log(err);
						});
				}, function (err) {
					console.log(err);
				});
		});

	router.route("/products/:id", function (id) {
	    console.log("products");
	    viewsFactory.getProductsById()
            .then(function (productsHtml) {
                vmFactory.getProductsByIdVM(id)
                    .then(function (vm) {
                        var view = new kendo.View(productsHtml,
						{ model: vm });
                        appLayout.showIn("#main-content", view);
                    }, function (err) {
                        console.log(err);
                    });
            }, function (err) {
                console.log(err);
            });
	});
	
	router.route("/categories/:id", function (id) {
	    console.log("categories_id");
	    console.log(id);
	    viewsFactory.getCategoriesById()
            .then(function (productsHtml) {
                console.log(123);
                vmFactory.getCategoriesByIdVM(id)
                    .then(function (vm) {
                        var view = new kendo.View(productsHtml,
						{ model: vm });
                        appLayout.showIn("#main-content", view);
                    }, function (err) {
                        console.log(err);
                    });
            }, function (err) {
                console.log(err);
            });
	});

	router.route("/basket", function () {
	    viewsFactory.getBasketView()
            .then(function (basketHtml) {
                vmFactory.getBasketVM()
                    .then(function (vm) {
                        var view = new kendo.View(basketHtml,
                        { model: vm });
                        appLayout.showIn("#main-content", view);
                    }, function (err) {
                        console.log(err);
                    });
            }, function (err) {
                console.log(err);
            });
	});


	$(function () {
		appLayout.render("#app");
		router.start();
	});
}());