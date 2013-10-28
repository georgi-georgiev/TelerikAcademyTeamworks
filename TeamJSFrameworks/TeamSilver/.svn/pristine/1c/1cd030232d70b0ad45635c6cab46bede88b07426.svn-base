window.persisters = (function () {

    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");
    var role = localStorage.getItem("role");

    var clearUserData = function () {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        localStorage.removeItem("role");
        nickname = null;
        sessionKey = null;
        role = null;
    };

    var saveUserData = function (userData) {
        localStorage.setItem("nickname", userData.displayName);
        localStorage.setItem("sessionKey", userData.sessionKey);
        localStorage.setItem("role", userData.role)
        nickname = userData.displayName;
        sessionKey = userData.sessionKey;
        role = userData.role;
    };

    var DataPersister = Class.create({
        init: function (apiUrl, id) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl + "users/");
            this.products = new ProductsPersister(apiUrl + "products/");
            this.productsByID = new ProductsPersister(apiUrl + "products/" + id);
            this.categories = new CategoriesPersister(apiUrl + "categories/");
        },
        isUserLoggedIn: function () {
            if (nickname !== null && sessionKey !== null) {
                return true;
            }

            return false;
        },
        getNickname: function () {
            return nickname;
        },
        getSessionKey: function () {
            return sessionKey;
        }
    });
	var UsersPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		login: function (username, password) {
			var user = {
				username: username,
				password: CryptoJS.SHA1(password).toString()
			};

			return requester.postJSON(this.apiUrl + "login", user)
				.then(function (data) {
				    saveUserData(data);
					return data;
				});
		},
		register: function (username, password, firstName, lastName, email) {
		    /*{
		        "username" : "Georgi",
                "firstName" : "Georgi",
                "lastName" : "Georgiev",
                "email": "abv@abv.bg",
                "password": "7c4a8d09ca3762af61e59520943dc26494f8941b"
		    }*/
			var user = {
			    username: username,
			    firstName: firstName,
			    lastName: lastName,
                email: email,
				password: CryptoJS.SHA1(password).toString()
			};

			return requester.postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    saveUserData(data);
				    return data;
				});
		},
		logout: function () {
			if (!sessionKey) {
			    alert("you sessionKey is expired");
			}
			var headers = {
			    "X-sessionKey": sessionKey
			};
			clearUserData();
			return requester.putJSON(this.apiUrl + "logout", headers);
		},

		getProducts: function () {
		    var headers = {
		        "X-sessionKey": sessionKey
		    };

		    return requester.getJSON(this.apiUrl + "my-products", headers);
        }
	});

	var ProductsPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
	    all: function () {
	        var headers = {
	            "X-sessionKey": sessionKey
	        };

	        return requester.getJSON(this.apiUrl, headers);
	    },
	    buy: function (id) {
	        var headers = {
	            "X-sessionKey": sessionKey
	        };

	        return requester.putJSON(this.apiUrl + id, headers);
	    },
	    getById: function (id) {
	        var headers = {
	            "X-sessionKey": sessionKey
	        };

	        return requester.getJSON(this.apiUrl + id, headers);
	    }
	});

	var CategoriesPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
	    all: function () {
	        var headers = {
	            "X-sessionKey": sessionKey
	        };

	        return requester.getJSON(this.apiUrl, headers);
	    },

	    getById: function (id) {
	        var headers = {
	            "X-sessionKey": sessionKey
	        };

	        return requester.getJSON(this.apiUrl + id + "/products", headers);
	    }
	});

	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	}
}());