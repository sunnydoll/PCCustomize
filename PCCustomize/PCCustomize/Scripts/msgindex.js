//msgindex.js

var app = angular.module("msgIndex", []);

app.config(function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "topicsController",
        templateUrl: "/messages/topicsView.html"
    });

    $routeProvider.when("/newmessage", {
        controller: "newTopicController",
        templateUrl: "/messages/newTopicsView.html"
    });

    $routeProvider.when("/message/:id", {
        controller: "reTopicController",
        templateUrl: "/messages/reTopicView.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

app.factory("servData", function ($http, $q) {
    var strPath = document.location.toString();
    var id;
    if (strPath.indexOf('#') < 0) {
        var lastSlash = document.location.toString().lastIndexOf('/');
        id = strPath.substring(lastSlash + 1, strPath.length);
    }
    else {
        var jing = document.location.toString().indexOf('#');
        var slash = document.location.toString().indexOf('/', jing - 8);
        id = strPath.substring(slash + 1, jing);
    }
    
    var _msgs = [];
    var _ready = false;

    var _readyOrNot = function () {
        return _ready;
    };

    var _getMsgs = function () {
        var d = $q.defer();

        $http.get("/api/v1/" + id + "/topics?includeReplies=true").then(
        function (result) {
            //Successful
            angular.copy(result.data, _msgs);
            _ready = true;
            d.resolve();
        },
        function () {
            //Failure
            d.reject();
        });

        return d.promise;
    };

    var _addTopic = function (newTopic) {
        var d = $q.defer();

        $http.post("/api/v1/" + id + "/topics", newTopic).then(
        function (result) {
            // success
            var newOne = result.data;
            _msgs.splice(0, 0, newOne);
            d.resolve(newOne);
        },
        function () {
            // error
            d.reject();
        });


        return d.promise;
    };

    function _findTopicById(tid) {
        var found = null;
        $.each(_msgs, function (i, item) {
            if (item.id == tid) {
                found = item;
                return false;
            }
        });
        return found;
    }

    var _getTopicById = function (tid) {
        var d = $q.defer();

        if (_readyOrNot()) {
            var topic = _findTopicById(tid);
            if (topic) {
                d.resolve(topic);
            }
            else {
                d.reject();
            }
        }
        else {
            _getTopicById().then(function () {
                //Success
                var topic = _findTopicById(tid);
                if (topic) {
                    d.resolve(topic);
                }
                else {
                    d.reject();
                }
            },
            function () {
                //Failure
                d.reject();
            });
        }

        return d.promise;
    };

    var _saveReply = function (topic, newReply) {
        var d = $q.defer();

        $http.post("/api/v1/" + id + "/topics/" + topic.id + "/replies", newReply).then(function (result) {
            //Success
            if (topic.replies == null) {
                topic.replies = [];
            }
            topic.replies.push(result.data);
            d.resolve(result.data);
        },
        function () {
            //Failure
            d.reject();
        });

        return d.promise;
    };

    return {
        msgs: _msgs,
        getMsgs: _getMsgs,
        addTopic: _addTopic,
        readyOrNot: _readyOrNot,
        getTopicById: _getTopicById,
        saveReply: _saveReply
    };
});

function topicsController($scope, $http, $routeParams, $location, $route, servData) {
    var strPath = document.location.toString();
    var id;
    if (strPath.indexOf('#') < 0) {
        var lastSlash = document.location.toString().lastIndexOf('/');
        id = strPath.substring(lastSlash + 1, strPath.length);
    }
    else {
        var jing = document.location.toString().indexOf('#');
        var slash = document.location.toString().indexOf('/', jing - 8);
        id = strPath.substring(slash + 1, jing);
    }

    $scope.data = servData.msgs;
    $scope.isBusy = false;

    //$http.get("/api/v1/" + id + "/topics?includeReplies=true").then(
    //    function (result) {
    //        //Successful
    //        angular.copy(result.data, $scope.data);
    //        //$scope.dataCount = result.data.length;
    //    },
    //    function () {
    //        //Failure
    //        alert("Failed to get the data!");
    //    }).then(function () {
    //        $scope.isBusy = false;
    //    });
    if (servData.readyOrNot() == false) {
        $scope.isBusy = false;
        servData.getMsgs().then(function () {
            //Successful

        },
        function () {
            //Failure
            alert("Failed to get the data!");
        }).then(function () {
            $scope.isBusy = false;
        });
    }
}

function newTopicController($scope, $http, $window, servData) {
    var strPath = document.location.toString();
    var id;
    if (strPath.indexOf('#') < 0) {
        var lastSlash = document.location.toString().lastIndexOf('/');
        id = strPath.substring(lastSlash + 1, strPath.length);
    }
    else {
        var jing = document.location.toString().indexOf('#');
        var slash = document.location.toString().indexOf('/', jing - 8);
        id = strPath.substring(slash + 1, jing);
    }

    $scope.newTopic = {};

    $scope.save = function () {
        //$http.post("/api/v1/" + id + "/topics", $scope.newTopic).then(
        //function () {
        //    //Successful
        //    $window.location = "#/";
        //},
        //function () {
        //    //Failure
        //    alert("Failed to save the data!");
        //});

        servData.addTopic($scope.newTopic).then(function () {
            //Successful
            $window.location = "#/";
        },
        function () {
            //Failure
            alert("Could not save the new topic");
        });
    };

}

function reTopicController($scope, $window, $routeParams, servData) {
    $scope.topic = null;
    $scope.newReply = {};

    servData.getTopicById($routeParams.id).then(function (topic) {
        //Successful
        $scope.topic = topic;
    },
    function () {
        //Failure
        $window.location = "#/";
    });

    $scope.addReply = function () {
        servData.saveReply($scope.topic, $scope.newReply).then(function () {
            //Successful
            $scope.newReply.body = "";
        },
        function () {
            //Failure
            alert("Could not save the new reply");
        });
    };
}
