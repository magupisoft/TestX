(function() {
    angular.module("testX")
           .factory('logger', logger);

    function logger() {
        return {
            error: function (msg) {
                console.log("ERROR: " + msg);
            },
            info: function (msg) {
                console.log("INFO: " + msg);
            },
            warn: function (msg) {
                console.log("WARN: " + msg);
            }
        };
    }
 })();