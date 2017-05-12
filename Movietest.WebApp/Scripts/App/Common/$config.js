(function () {
    angular.module("testX")
           .constant("$config",
                        {
                            endpoints: {
                                api: testXConfig.config_api
                            }
                        });
    }
)();