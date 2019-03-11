# TikaService-Installer

This is a windows installer for the [tika windows service](https://github.com/wbicode/TikaService).

## Features

* Install [tika-server](https://github.com/apache/tika/tree/master/tika-server)
* Configure
  * Host
    * SERVICE_HOST
    * defaults to "localhost"
  * Port
    * SERVICE_PORT
    * defaults to 9997
  * Autostart of service (manual or auto)
    * STARTUP_TYPE
    * defaults to auto
  * Log-path
    * LOG_PATH
    * defaults to [SystemFolder]/LogFiles/TikaService
  * Start after setup
    * START_AFTER_SETUP (1 for yes and 0 for no)
    * defaults to 1



## TODO

* procrun does not support log rotation; so the logs folder can get really big under heavy load
  * TODO: have a script/separate thread in [TikaService]() which deletes logs older than n days
* Configure jvm.opts?