# Lotto.Lite - .NET Technical Test

###How to run
Just download all the source, open in Visual Studio and hit F5.

The date search endpoint can be accessed here: /Api/LotteryDraws?date=09-07-2017

## Libraries used

### Elmah
Provides general exception logging, along with a UI for useful viewing in production scenario.  Can be logged to DB, but in this case it's writing to a log file in App_Data/Logs.  Exceptions are caught in a global exception filter, passed to Elmah, then an API friendly ModelState error can be returned for display to the user.  If you edit the code to force and exception, then go to /Elmah.axd you'll see the exception log.

### log4net
Two loggers? Yes, used for a debug log as it can log at very granular levels and plugs in nicely with things like NHibernate. Currently only logs if the log level is set to DEBUG in the web.config (how I've set it). Writes to App_Data/Logs

### Ninject
Lightweight IoC container to take care of dependency injection. Has a WebApi extension which works well.

### Automapper
Convention based property mapper with some really powerful functionality I've used a lot to reduce the amount of boiler plate required to map models to entities.  I use the Singleton pattern for this as it holds purely configuration details which are initialised on application start, and Ninject injects an instance of it to the controllers.

### AngularJS
Takes care of interactive UI.  Learnt it for this test as I've only used Knockout before, but there are similarities.


## Other notes
I used the pretty standard Generic Repository pattern for peristing data.  Usually I'd use this in conjuction with the Unit of Work in a real DB scenario to maintain transaction isolation.

A couple of service tests are included.


