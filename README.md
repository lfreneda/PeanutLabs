PeanutLabs
==========

C# .NET Integration with Peanut Labs social monetization ( http://www.peanutlabs.com )

Samples in ASP.NET MVC and ASP.NET Webforms included

Getting to work
---------------------

### 1. Register your system/application
```
http://www.peanutlabs.com/publisher/
```
 
### 2. Configuration - configure settings @ web.config
```
  <appSettings>
    <add key="peanutlabs.base.url" value="http://www.peanutlabs.com/userGreeting.php" />
    <add key="peanutlabs.application.id" value="12345" />
    <add key="peanutlabs.application.key" value="d7c37372f4c53b1b35ab3ad38XXXXX" />
  </appSettings>
```

### 3. Implement your callback logics
```
	public class PeanutLabsCallbackSample : PeanutLabsCallback
    {
        public PeanutLabsCallbackSample(IPeanutLabsConfiguration configuration)
            : base(configuration)
        {
        }

        protected override bool ProcessCredit(IRequestCallback requestCallback)
        {
            //implement credit logic here.
            return true;
        }

        protected override bool ProcessChargeBack(IRequestCallback requestCallback)
        {
            //implement chargeback logic here.
            return true;
        }

        protected override void ProcessInvalidRequest(IRequestCallback requestCallback) {
            //implement invalid request logic here 
        }
    }
```

### 4. Generate your iframe url
```
    var peanutLabsUrl = new PeanutLabsUrl(new PeanutLabsAppSettings());
    var iframeUrl = peanutLabsUrl.IframeUrl(publisherUserId: 1508);
```

### 5. Create a page or action to be your callback
```
    var callback = new PeanutLabsCallbackSample(new PeanutLabsAppSettings());
    callback.Process(new RequestCallback("customParameter", "customParameter2"));
```

### 6. Done.
