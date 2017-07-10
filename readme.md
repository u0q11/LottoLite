# Lotto.Lite - .NET Technical Test

### How to run
Just download all the source, open in Visual Studio and hit F5.

The date search endpoint can be accessed here: /Api/LotteryDraws?date=09-07-2017

## Libraries used

### Elmah
Provides general exception logging, along with a UI for useful viewing in a production scenario.  Can be logged to a DB, but in this case it's writing to a log file in App_Data/Logs.  Exceptions are caught in a global exception filter, passed to Elmah, then a API friendly ModelState error can be returned for display to the user.  If you edit the code to force and exception, then go to the url /Elmah.axd you'll see the exception log.

### log4net
Two loggers? Yes, used for a debug log as it can log at very granular levels and plugs in nicely with things like NHibernate. Currently only logs if the log level is set to DEBUG in the web.config (how I've set it). Writes to App_Data/Logs

### Ninject
Lightweight IoC container to take care of dependency injection. Has a WebApi extension to ease configuration.

### AutoMapper
Convention based property mapper with some really powerful functionality. I've used it a lot to reduce the amount of boiler plate required to map models to entities.  I use the Singleton pattern for this as it holds purely configuration details which are initialised on application start, and Ninject injects an instance of it to the controllers.

### AngularJS
Takes care of the interactive UI.  Never used it before as I've exclusively used Knockout, but learnt it for this test and am now a bit of a fan; there are quite a few similarities.

## Other notes
I used the standard Generic Repository pattern for peristing data.  Usually I'd use this in conjuction with the Unit of Work in a real DB scenario to maintain transaction isolation.

A couple of service tests are also included.


